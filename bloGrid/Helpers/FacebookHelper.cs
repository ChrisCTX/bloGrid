using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bloGrid.Helpers
{
    public static class FacebookHelper
    {
        public static MvcHtmlString Facebook(this HtmlHelper helper, string url)
        {
            var builder = new TagBuilder("iframe");

            // Add attributes
            builder.MergeAttribute("class", "story");

            // '&' character getting HTML encoded as ;amp; extremely annoying
            builder.MergeAttribute("src", "//www.facebook.com/plugins/likebox.php?href=" + url + "&amp;width=292&amp;height=395&amp;show_faces=false&amp;colorscheme=light&amp;stream=true&amp;show_border=false&amp;header=false");
            builder.MergeAttribute("scrolling", "no");
            builder.MergeAttribute("frameborder", "0");
            builder.MergeAttribute("style", "border:none; overflow:hidden; width:292px; height:395px;");


            // Temporary (ugly) solution until ampersand can be fixed
            var tag = "<iframe class=\"story\" src=\"//www.facebook.com/plugins/likebox.php?href=" + url + "&amp;width=292&amp;height=395&amp;show_faces=false&amp;colorscheme=light&amp;stream=true&amp;show_border=false&amp;header=false\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:292px; height:395px;\" allowTransparency=\"true\"></iframe>";

            return MvcHtmlString.Create(tag.ToString());
        }
    }
}