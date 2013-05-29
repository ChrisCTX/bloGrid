using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bloGrid.Controllers
{
    public class ParsedJsonMockup
    {
        public static List<Dictionary<string, string>> getMockup()
        {
            // Example of how a JSON array of objects, once parsed back to a list of dictionaries
            // can be used to add elements to the grid in a dynamic fashion

            List<Dictionary<string, string>> parsedJson = new List<Dictionary<string, string>>();
            Dictionary<string, string> facebook = new Dictionary<string, string>();
            Dictionary<string, string> youtube = new Dictionary<string, string>();
            Dictionary<string, string> rss = new Dictionary<string, string>();
            Dictionary<string, string> instagram = new Dictionary<string, string>();


            facebook["type"] = "facebook";
            facebook["url"] = "https://www.facebook.com/gopro";
            youtube["type"] = "youtube";
            youtube["url"] = "http://www.youtube.com/embed/SYpsFnhMmcY";
            rss["type"] = "rss";
            rss["url"] = "http://www.nasa.gov/rss/breaking_news.rss";
            instagram["type"] = "instagram";
            instagram["url"] = "http://snapwidget.com/in/?h=bGludXh8aW58MTAwfDJ8M3x8bm98NXxub25l";

            parsedJson.Add(facebook);
            parsedJson.Add(youtube);
            parsedJson.Add(rss);
            parsedJson.Add(instagram);

            return parsedJson;
        }
    }
}
