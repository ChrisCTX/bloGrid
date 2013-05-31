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

        public ActionResult Delete()
        {
            var db = new AccountDBContext();
            Account acc = db.Accounts.Where(p => p.Name == "blog").FirstOrDefault();
            JavaScriptSerializer marshal = new JavaScriptSerializer();
            var clear = new List<Dictionary<string, string>>();
            string emptyJson = marshal.Serialize(clear);
            acc.layoutJSON = emptyJson;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Account acc)
        {
            var db = new AccountDBContext();
            Account blog = db.Accounts.Where(p => p.Name == "blog").FirstOrDefault();
            string name = acc.Name;
            string pass = acc.Password;
            if (name == "blog")
            {
                if (Hashing.VerifyMd5Hash(MD5.Create(), pass, blog.Password) == true)
                {
                    ViewBag.Logged = true;
                }
            }
            JavaScriptSerializer marshal = new JavaScriptSerializer();
            ViewBag.Panels = marshal.Deserialize<List<Dictionary<string, string>>>(blog.layoutJSON);
            return View("Index");
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
            return View("Index");
        }

    }
}
