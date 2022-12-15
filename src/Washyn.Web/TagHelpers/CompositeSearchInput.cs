using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace Washyn.Web.TagHelpers
{

    // <div class="input-group">
    //     <input class="form-control py-2 border-right-0 border" type="search" value="search" id="">
    //     <span class="input-group-append">
    //         <button class="btn btn-light border-left-0 border" type="button">
    //             <i class="fa fa-search text-secondary"></i>
    //         </button>
    //     </span>
    // </div>
    
    [HtmlTargetElement("wsh-search-input", TagStructure = TagStructure.WithoutEndTag)]
    public class CompositeSearchInput : TagHelper
    {
        [HtmlAttributeName("value")] public string Value { get; set; } = string.Empty;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "div";
            output.AddClass("input-group", HtmlEncoder.Default);
            
            var input = new TagBuilder("input");
            input.AddCssClass("form-control");
            input.AddCssClass("py-2");
            input.AddCssClass("border-right-0");
            input.AddCssClass("border");
            input.Attributes.Add("type", "search");
            // check
            input.Attributes.Add("name", "filter");
            input.Attributes.Add("value", Value);
            
            var span = new TagBuilder("span");
            span.AddCssClass("input-group-append");
            
            var button = new TagBuilder("button");
            button.AddCssClass("btn");
            button.AddCssClass("btn-light");
            button.AddCssClass("border-left-0");
            button.AddCssClass("border");
            // check
            // button.Attributes.Add("type", "button");
            button.Attributes.Add("type", "submit");
            
            var icon = new TagBuilder("i");
            icon.AddCssClass("fa");
            icon.AddCssClass("fa-search");
            icon.AddCssClass("text-secondary");
            
            button.InnerHtml.AppendHtml(icon);
            span.InnerHtml.AppendHtml(button);
            
            output.Content.AppendHtml(input).AppendHtml(span);
        }
    }
}