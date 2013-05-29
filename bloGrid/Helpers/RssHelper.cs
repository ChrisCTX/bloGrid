using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bloGrid.Helpers
{
    public static class RssHelper
    {
        // <iframe src="http://us1.rssfeedwidget.com/getrss.php?time=1369713266894&amp;x=http%3A%2F%2Fwww.nasa.gov%2Frss%2Fbreaking_news.rss&amp;w=200&amp;h=500&amp;bc=333333&amp;bw=1&amp;bgc=transparent&amp;m=20&amp;it=true&amp;t=(default)&amp;tc=333333&amp;ts=15&amp;tb=transparent&amp;il=true&amp;lc=0000FF&amp;ls=14&amp;lb=false&amp;id=true&amp;dc=333333&amp;ds=14&amp;idt=true&amp;dtc=284F2D&amp;dts=12"></iframe>
        public static MvcHtmlString Rss(this HtmlHelper helper, string feed)
        {
            var tag = "<iframe class=\"story\" src=\"http://us1.rssfeedwidget.com/getrss.php?time=1369713266894&amp;x=" + feed + "&amp;w=200&amp;h=500&amp;bc=333333&amp;bw=1&amp;bgc=transparent&amp;m=20&amp;it=true&amp;t=(default)&amp;tc=333333&amp;ts=15&amp;tb=transparent&amp;il=true&amp;lc=0000FF&amp;ls=14&amp;lb=false&amp;id=true&amp;dc=333333&amp;ds=14&amp;idt=true&amp;dtc=284F2D&amp;dts=12\"></iframe>";
            return MvcHtmlString.Create(tag.ToString());
        }
    }
}