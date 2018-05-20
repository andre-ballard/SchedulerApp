using SchedulerApp.Client.Interfaces;
using SchedulerApp.Client.Models;
using SchedulerApp.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulerApp.Client.Controllers
{
    public class InstructorController : Controller, IInstructor
    {
        ClientBroker cb = new ClientBroker();
        // GET: Instructor
        public ActionResult Index(int id)
        {
            ViewBag.ID = id;
            return View(new CoursesVM(id));
        }

        public ActionResult CreateCourse(int id)
        {
            ViewBag.ID = id;
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(CoursesDTO c, int id)
        {

            ViewBag.ID = id;
            cb.CreateCourse(c, id);
            return View("Index", new CoursesVM(id));
        }

        public ActionResult Delete(int courseid, int id)
        {
            ViewBag.ID = id;
            cb.DeleteCourse(courseid);
            return View("Index", new CoursesVM(id));
        }

        public ActionResult DeleteStudent(int id, int courseid, int studentid)
        {
            ViewBag.ID = id;
            ViewBag.CourseId = courseid;
            cb.DeleteStudent(studentid, courseid);
            return View("ViewStudents", new PersonVM(courseid));
        }

        public ActionResult ViewStudents(int courseid, int id)
        {
            ViewBag.ID = id;
            ViewBag.CourseId = courseid;
            return View(new PersonVM(courseid));
        }

        public ActionResult Edit(int courseid, int id)
        {
            ViewBag.ID = id;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(CoursesDTO c, int id)
        {
            ViewBag.ID = id;
            cb.EditCourse(c);
            return View("Index", new CoursesVM(id));
        }
    }
}