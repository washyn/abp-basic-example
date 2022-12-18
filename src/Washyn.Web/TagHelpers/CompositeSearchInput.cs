using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Extensions;

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
        [HtmlAttributeName("asp-for")]
        public ModelExpression AspFor { get; set; }
        
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
            
            
            if (AspFor != null)
            {
                input.Attributes.Add("name", AspFor.Name);
                var typeModel = AspFor.ModelExplorer.ModelType == typeof(string);
                var modelValue = AspFor.ModelExplorer.Model != null;
                if (typeModel && modelValue)
                {
                    input.Attributes.Add("value", AspFor.ModelExplorer.Model.ToString());
                }
            }

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
    
    
    // supress un used attributes
    [HtmlTargetElement("wsh-search", TagStructure = TagStructure.WithoutEndTag)]
    public class CompositeSearch : InputTagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            var input = new TagBuilder("input");
            input.AddCssClass("form-control");
            input.AddCssClass("py-2");
            input.AddCssClass("border-right-0");
            input.AddCssClass("border");
            input.Attributes.Add("type", "search");
            
            
            var attributes = output.Attributes
                .Select(attribute => new KeyValuePair<string, object>(attribute.Name, attribute.Value))
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            input.MergeAttributes(attributes: attributes, replaceExisting: false);
            
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "div";
            output.Attributes.Clear();
            output.AddClass("input-group", HtmlEncoder.Default);
            
            
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

        public CompositeSearch(IHtmlGenerator generator) : base(generator)
        {
        }
    }
    
    
    
    [HtmlTargetElement("wsh-search-input-simple", TagStructure = TagStructure.WithoutEndTag)]
    public class CompositeSearchInputOld : TagHelper
    {
        [HtmlAttributeName("value")] public string Value { get; set; } = string.Empty;
        [HtmlAttributeName("name")] public string Name { get; set; } = string.Empty;
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

            if (!string.IsNullOrEmpty(Name))
            {
                input.Attributes.Add("name", Name);
            }

            if (!string.IsNullOrEmpty(Value))
            {
                input.Attributes.Add("value", Value);
            }
           
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