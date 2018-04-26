using SchedulerApp.Client.Models;
using SchedulerApp.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulerApp.Client.Controllers
{
    public class StudentController : Controller
    {
        ClientBroker cb = new ClientBroker();
        // GET: Student
        
        public ActionResult Index(int id)
        {
            TempData["id"] = id;
            return View(new CoursesVM());
        }

        
        public ActionResult Add(int courseid, int id)
        {  //c.UserID = id;
            if (cb.AddCourse(courseid, id))
            {
                return RedirectToAction("PendingCourses", "Student", new { userid = id });

            }
            else
            {
                TempData["id"] = id;
                ViewBag.Error = "This course is already saved to your list!";
                return View("Index", new CoursesVM());
            }
        }

        public ActionResult PendingCourses(int userid)
        {
            ViewBag.ID = userid;
            return View(new CoursesVM(userid));
        }

        public ActionResult RegisterCourse(int id, int courseid)
        {
            ViewBag.ID = id;
            cb.RegisterCourse(courseid, id);
            return View("RegisteredCourses", new CoursesVM(id));
        }

        public ActionResult RemovePendingCourse(int id, int courseid)
        {
            ViewBag.ID = id;
            cb.RemovePendingCourse(courseid, id);
            return View("PendingCourses", new CoursesVM(id));
        }

        public ActionResult DropRegisteredCourse(int id, int courseid)
        {
            ViewBag.ID = id;
            cb.DropRegisteredCourse(courseid, id);
            return View("RegisteredCourses", new CoursesVM(id));
        }

        public ActionResult RegisteredCourses(int userid)
        {
            ViewBag.ID = userid;
            return View(new CoursesVM(userid));
        }
    }
}