using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVCDemo.Web.Controllers
{
    public class MyConnectionsController : Controller
    {
        // GET: MyConnections
        public ActionResult Index()
        {
            return View("~/Views/Account/MyConnections.cshtml");
        }
    }
}