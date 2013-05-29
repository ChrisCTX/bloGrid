using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bloGrid.Helpers
{
    public static class InstagramHelper
    {
        // <iframe src="http://snapwidget.com/in/?h=bGludXh8aW58MTAwfDJ8M3x8bm98NXxub25l" allowTransparency="true" frameborder="0" scrolling="no" style="border:none; overflow:hidden; width:210px; height: 315px" ></iframe>

        public static MvcHtmlString Instagram(this HtmlHelper helper, string url)
        {
            var builder = new TagBuilder("iframe");
            builder.MergeAttribute("class", "story");
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("allowTransparency", "true");
            builder.MergeAttribute("frameborder", "0");
            builder.MergeAttribute("scrolling", "no");
            builder.MergeAttribute("style", "width:210px; height: 315px");

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));

        }
    }
}