using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutogearWeb.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Package()
        {
            return View();
        }
        public ActionResult RTA()
        {
            return View();
        }
        public ActionResult Postcodes()
        {
            return View();
        }
    }
}