using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
namespace bloGrid.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string json = @"{""type"": ""youtube"", ""url"": ""http://www.youtube.com/embed/SYpsFnhMmcY""}";
            //JavaScriptSerializer a = new JavaScriptSerializer();
            //var dict = a.Deserialize<Dictionary<string, string>>(json);
            ViewBag.Panels = ParsedJsonMockup.getMockup();
            //ViewBag.Panels.Add(dict);
            return View();
        }

        [HttpGet]
        public PartialViewResult NewPanel(string q)
        {
            string json = @"{""type"": ""youtube"", ""url"": ""http://www.youtube.com/embed/SYpsFnhMmcY""}";
            var l = new List<Dictionary<string, string>>();
            JavaScriptSerializer a = new JavaScriptSerializer();
            ViewBag.Panels = l;
            if (q != null)
            {
                var dict = a.Deserialize<Dictionary<string, string>>(q);
                l.Add(dict);
            }
            else
            {
                var mockDict = a.Deserialize<Dictionary<string, string>>(json);  
            }
            return PartialView("_Content");
        }

    }
}
