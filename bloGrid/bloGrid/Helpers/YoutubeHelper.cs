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
            var tag = "<iframe class=\"story\" width=\"300\" height=\"200\" src=\"" + url + "\" frameborder=\"0\" allowfullscreen></iframe>";
            return MvcHtmlString.Create(tag.ToString());
        }
    }
}