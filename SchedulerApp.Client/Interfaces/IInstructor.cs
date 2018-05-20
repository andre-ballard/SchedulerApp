using SchedulerApp.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulerApp.Client.Interfaces
{
    public interface IInstructor
    {
        ActionResult CreateCourse(int id);
        ActionResult CreateCourse(CoursesDTO c, int id);
        ActionResult Delete(int courseid, int id);
        ActionResult DeleteStudent(int id, int courseid, int studentid);
        ActionResult ViewStudents(int courseid, int id);
        ActionResult Edit(int courseid, int id);
        ActionResult Edit(CoursesDTO c, int id);

    }
}