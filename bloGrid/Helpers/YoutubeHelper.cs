using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bloGrid.Helpers
{
    public static class YoutubeHelper
    {
        public static MvcHtmlString Youtube(this HtmlHelper helper, string url)
        {
            var builder = new TagBuilder("iframe");
            builder.MergeAttribute("class", "story");
            builder.MergeAttribute("width", "300");
            builder.MergeAttribute("height", "200");
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("frameborder", "0");

            // var tag = "<iframe class=\"story\" width=\"300\" height=\"200\" src=\"" + url + "\" frameborder=\"0\" allowfullscreen></iframe>";
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
    }
}