using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bloGrid.Controllers
{
    public class StyleController : Controller
    {
        public string Index()
        {
            /*
             * This Controller is a rather hacky way to use the Razor Engine
             * to create dynamically generated CSS files based on whatever computation we desire.
             * Originally described in: http://www.codeproject.com/Articles/171695/Dynamic-CSS-using-Razor-Engine
             * 
             * In this project, we attempt to stick with the MVC pattern as much as possible so
             * we only use some simple calculations in here, but it is entirely possible to do much more
             * since we're essencially allowing the execution of C# code inside the CSS file.
             * 
             * Also worth to note, don't expect Visual Studio to help you much with propper auto-complete
             * and all that other stuff while editing the CSS file since it dosn't understand that it has
             * the power of Razor with it.
             * 
             */

            Response.ContentType = "text/css";
            return RazorEngine.Razor.Parse(System.IO.File.ReadAllText(Server.MapPath("/Content/Site.css")));

        }

    }
}
