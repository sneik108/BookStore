using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.HelpPages.Controllers
{
    public class HelpController : Controller
    {
        // GET: HelpPages/Help
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Map()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}