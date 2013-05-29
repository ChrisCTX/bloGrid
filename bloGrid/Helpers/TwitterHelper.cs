using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bloGrid.Helpers
{
    public static class TwitterHelper
    {
        public static MvcHtmlString Twitter(this HtmlHelper helper, string username)
        {
            string s = "<ul id=\"twitter_update_list\" class=\"story\"></ul>";
            return MvcHtmlString.Create(s.ToString());
        }
    }
}