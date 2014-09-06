using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebMVCDemo.Web.DAL;
using WebMVCDemo.Web.Models;

namespace WebMVCDemo.Web.Controllers
{
    public class TaskManagerController : Controller
    {
        private WebMVCDemoDbEntities db = new WebMVCDemoDbEntities();

        // GET: TaskManager
        public ActionResult Index()
        {
            return View();
        }

        // GET: TaskManager
        public ActionResult GetAllTasks()
        {
            IEnumerable<WebMVCDemo.Web.Models.TaskDetails> dept = from d in db.Tasks
                                                                  select new WebMVCDemo.Web.Models.TaskDetails { TaskId = d.TaskId, Title = d.Title, Description = d.Description, DueDate = d.DueDate};

            return Json(dept, JsonRequestBehavior.AllowGet);
        }

        // GET: TaskManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskManager/Create
        [HttpPost]
        public ActionResult Create(TaskDetails newTask)
        {
            if (ModelState.IsValid)
            {
                DAL.Task task = Translator.TaskBalToTaskDal(newTask);
                db.Tasks.Add(task);
                db.SaveChanges();

                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, task);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = friend.FriendId }));
                return View();
            }
            else
            {
                return View();// Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // GET: TaskManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaskManager/Edit/5
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

        // GET: TaskManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskManager/Delete/5
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
