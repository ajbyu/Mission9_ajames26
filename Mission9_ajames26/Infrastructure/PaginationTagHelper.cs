﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission9_ajames26.Models.ViewModels;

namespace Mission9_ajames26.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-num")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory _uhf; //Ultra High Frequency Factory

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        public PageInfo PageNum { get; set; }

        public string PageAction { get; set; }

        public PaginationTagHelper(IUrlHelperFactory uhf)
        {
            _uhf = uhf;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper helper = _uhf.GetUrlHelper(vc);

            TagBuilder result = new TagBuilder("div");

            for (int i = 1; i <= PageNum.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");

                tag.Attributes["href"] = helper.Action(PageAction, new { pageNum = i });
                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
