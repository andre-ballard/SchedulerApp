using SchedulerApp.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerApp.Client.ViewModels
{
    public class CoursesVM
    {
        private ClientBroker cb = new ClientBroker();

        int User;

        public CoursesVM()
        {
        }

        public CoursesVM(int user)
        {
            User = user;
        }

        public List<CoursesDTO> Courses
        {
            get
            {
                return cb.Courses();
            }
        }

        public List<CoursesDTO> PendingCourses
        {
            get
            {
                return cb.GetStudentPendingCourses(User);
            }
        }

        public List<CoursesDTO> RegisteredCourses
        {
            get
            {
                return cb.GetStudentRegisteredCourses(User);
            }
        }

        public List<CoursesDTO> InstructorCourses
        {
            get
            {
                return cb.GetInstructorCourses(User);
            }
        }

        


    }
}