using AutoMapper;
using SchedulerApp.Logic.Models;
using SchedulerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleLogic.Mapper;

namespace SchedulerApp.Logic
{
    public class LogicBroker
    {
        private DataAccess db = new DataAccess();
        private DAOMapper dm = new DAOMapper();

        public List<CoursesDAO> Courses()
        {
            var cd = new List<CoursesDAO>();
            foreach (var item in db.Courses())
            {
                cd.Add(dm.CoursesToCoursesDAO<CoursesDAO>(item));
            }
            return cd;
        }

        public List<PersonDAO> Persons()
        {
            var pd = new List<PersonDAO>();
            foreach (var item in db.Persons())
            {
              pd.Add(dm.PersonToPersonDAO<PersonDAO>(item));
            }
            return pd;
        }

        public List<PersonDAO> Instructors()
        {
            var pd = new List<PersonDAO>();
            foreach (var item in db.Instructors())
            {
                pd.Add(dm.PersonToPersonDAO<PersonDAO>(item));
            }
            return pd;
        }

        public List<PersonDAO> Students()
        {
            var pd = new List<PersonDAO>();
            foreach (var item in db.Students())
            {
                pd.Add(dm.PersonToPersonDAO<PersonDAO>(item));
            }
            return pd;
        }

        public List<PersonDAO> Registers()
        {
            var pd = new List<PersonDAO>();
            foreach (var item in db.Registers())
            {
                pd.Add(dm.PersonToPersonDAO<PersonDAO>(item));
            }
            return pd;
        }

        public bool CreatePerson(PersonDAO p)
        {
            return db.CreatePerson(dm.PersonDAOToPerson2<Person>(p));
        }

        public bool AddCourse(int courseid, int id)
        {
            return db.AddCourse(courseid, id);
        }

        public bool CreateCourse(CoursesDAO c, int id)
        {
            return db.CreateCourse(dm.CoursesDAOToCourses<Courses>(c), id);
        }

        public bool RemovePendingCourse(int courseid, int id)
        {
            return db.RemovePendingCourse(courseid, id);
        }

        public bool DropRegisteredCourse(int courseid, int id)
        {
            return db.DropRegisteredCourse(courseid, id);
        }

        public bool RegisterCourse(int courseid, int id)
        {
            return db.RegisterCourse(courseid, id);
        }

        public bool DeleteCourse(int courseid)
        {
            return db.DeleteCourse(courseid);
        }

        public bool DeleteStudent(int studentid, int courseid)
        {
            return db.DeleteStudent(studentid,courseid);
        }

        public bool EditCourse(CoursesDAO co)
        {
            return db.EditCourse(dm.CoursesDAOToCourses<Courses>(co));
        }

        public List<PersonDAO> GetStudents(int i)
        {
            var cl = new List<PersonDAO>();

            foreach (var item in db.GetStudents(i))
            {
                cl.Add(dm.PersonToPersonDAO<PersonDAO>(item));
            }

            return cl;
        }

        public List<CoursesDAO> GetPendingCourses(int i)
        {
            var cd = new List<CoursesDAO>();
            foreach (var item in db.GetPendingCourses(i))
            {
                cd.Add(dm.CoursesToCoursesDAO<CoursesDAO>(item));
            }
            return cd;
        }

        public List<CoursesDAO> GetInstructorCourses(int i)
        {
            var cd = new List<CoursesDAO>();
            foreach (var item in db.GetInstructorCourses(i))
            {
                cd.Add(dm.CoursesToCoursesDAO<CoursesDAO>(item));
            }
            return cd;
        }

        public List<CoursesDAO> GetRegisteredCourses(int i)
        {
            var cd = new List<CoursesDAO>();
            foreach (var item in db.GetRegisteredCourses(i))
            {
                cd.Add(dm.CoursesToCoursesDAO<CoursesDAO>(item));
            }
            return cd;
        }
    }
}
