using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVCDemo.Web.Controllers
{
    public class InRiverSettingsController : Controller
    {
        // GET: InRiverSettings
        public ActionResult Index()
        {
            return View();
        }

        // GET: InRiverSettings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InRiverSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InRiverSettings/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InRiverSettings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InRiverSettings/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InRiverSettings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InRiverSettings/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
