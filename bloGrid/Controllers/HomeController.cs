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
            //JavaScriptSerializer marshal = new JavaScriptSerializer();
            List<Dictionary<string, string>> panelList = new List<Dictionary<string, string>>();
            ViewBag.Panels = ParsedJsonMockup.getMockup();
            //string j = marshal.Serialize(ViewBag.Panels);
            //ViewBag.json = j;
            return View();
        }

        [HttpGet]
        public ActionResult NewPanel(string q)
        {
            List<Dictionary<string, string>> panelList = new List<Dictionary<string, string>>();
            JavaScriptSerializer marshal = new JavaScriptSerializer();
            ViewBag.Panels = panelList;
            if (q != null)
            {
                var dict = marshal.Deserialize<Dictionary<string, string>>(q);
                ViewBag.Panels.Add(dict);
            }
            //string j = marshal.Serialize(panelList);
            //ViewBag.json = j;
            return View("Index");
        }

    }
}
