using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulerApp.Client.Interfaces
{
    public interface IStudent
    {
        ActionResult Add(int courseid, int id);
        ActionResult PendingCourses(int userid);
        ActionResult RegisterCourse(int id, int courseid);
        ActionResult RemovePendingCourse(int id, int courseid);
        ActionResult DropRegisteredCourse(int id, int courseid);
        ActionResult RegisteredCourses(int userid);
    }
}