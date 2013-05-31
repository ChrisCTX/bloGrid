using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using bloGrid.Models;
using System.Security.Cryptography;

namespace bloGrid.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            var db = new AccountDBContext();
            Account acc = db.Accounts.Where(p => p.Name == "blog").FirstOrDefault();
            JavaScriptSerializer marshal = new JavaScriptSerializer();
            ViewBag.Panels = marshal.Deserialize<List<Dictionary<string, string>>>(acc.layoutJSON);
            //ViewBag.Panels = ParsedJsonMockup.getMockup();
            return View();
        }

        [HttpGet]
        public ActionResult NewPanel(string q)
        {
            var db = new AccountDBContext();
            Account acc = db.Accounts.Where(p => p.Name == "blog").FirstOrDefault();
            JavaScriptSerializer marshal = new JavaScriptSerializer();
            ViewBag.Panels = marshal.Deserialize<List<Dictionary<string, string>>>(acc.layoutJSON);
            if (q != null)
            {
                var dict = marshal.Deserialize<Dictionary<string, string>>(q);
                ViewBag.Panels.Add(dict);
                string newJson = marshal.Serialize(ViewBag.Panels);
                acc.layoutJSON = newJson;
                db.SaveChanges();
            }
            //string j = marshal.Serialize(panelList);
            //ViewBag.json = j;
            return View("Index");
        }

    }
}
