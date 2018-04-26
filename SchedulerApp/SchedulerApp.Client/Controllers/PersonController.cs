using SchedulerApp.Client.Models;
using SchedulerApp.Client.ViewModels;
using SchedulerApp.Data;
using SchedulerApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SchedulerApp.Client.Controllers
{
    public class PersonController : Controller
    {
        private ClientBroker cb = new ClientBroker();
        // GET: Person
        public ActionResult Index()
        {
            var pvm = new PersonVM();
            return View(new PersonVM());
        }
     
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonDTO p)
        {
            if (ModelState.IsValid)
            {
                ClientBroker cb = new ClientBroker();
                if (RoleCheck(p.Role) < 1)
                {
                    return View();
                }
                p.Role = RoleCheck(p.Role).ToString();
                cb.AddPerson(p);
                //ViewBag.Success = "Successful";
            }
            else
            {
                return View(p);
            }
                return RedirectToAction("Index","Person");
            
        }

        public ActionResult Modify()
        {
            return View();
        }

        public ActionResult Remove()
        {
            return View();
        }

        public int RoleCheck(string role)
        {
            int result;
            if (role == "student")
            {
                result = 1;
            }
            else if (role == "instructor")
            {
                result = 2;
            }
            else {
                ModelState.AddModelError("Role", "Please insert valid role!");
                result = 0;
            }

            return result;
        }
    }
}