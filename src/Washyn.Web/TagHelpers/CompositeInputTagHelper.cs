using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace Washyn.Web.TagHelpers
{
    
    // <div class="input-group">
    //     <input type="text" class="form-control">
    //     <div class="input-group-prepend">
    //         <span class="input-group-text">-</span>
    //     </div>
    //     <input type="text" class="form-control">
    // </div>
    
    [HtmlTargetElement("wsh-serie-input", TagStructure = TagStructure.WithoutEndTag)]
    public class CompositeInputTagHelper : TagHelper
    {
        [HtmlAttributeName("p-name")] public string PrependInputName { get; set; } = string.Empty;
        [HtmlAttributeName("a-name")] public string AppendInputName { get; set; } = string.Empty;
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // this works with "TagStructure = TagStructure.WithoutEndTag" this are related
            output.TagMode = TagMode.StartTagAndEndTag;
                
            output.TagName = "div";
            output.AddClass("input-group", HtmlEncoder.Default);
            
            var prependInput = new TagBuilder("input");
            prependInput.Attributes.Add("type", "text");
            prependInput.AddCssClass("form-control");
            prependInput.AddCssClass("border-right-0");
            if (!string.IsNullOrEmpty(PrependInputName))
            {
                prependInput.Attributes.Add("name", PrependInputName);
            }
            
            var appendInput = new TagBuilder("input");
            appendInput.Attributes.Add("type", "text");
            appendInput.AddCssClass("form-control");
            if (!string.IsNullOrEmpty(AppendInputName))
            {
                appendInput.Attributes.Add("name", AppendInputName);
            }
            
            var groupText = new TagBuilder("span");
            groupText.AddCssClass("input-group-text");
            groupText.TagRenderMode = TagRenderMode.Normal;
            groupText.InnerHtml.SetContent("-");
            
            var prependGroup = new TagBuilder("div");
            prependGroup.AddCssClass("input-group-prepend");
            prependGroup.InnerHtml.AppendHtml(groupText);

            output.Content.AppendHtml(prependInput).AppendHtml(prependGroup).AppendHtml(appendInput);
        }
    }
}