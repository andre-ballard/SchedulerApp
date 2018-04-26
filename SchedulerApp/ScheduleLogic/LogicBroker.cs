using AutoMapper;
using SchedulerApp.Logic.Models;
using SchedulerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleLogic.Models;

namespace SchedulerApp.Logic
{
    public class LogicBroker
    {
        private DataAccess db = new DataAccess();

        
        public MapperConfiguration pdTop = new MapperConfiguration(p => p.CreateMap<PersonDAO, Person>().ForMember(d=>d.RoleID, c=>c.MapFrom("roleid")));

        /// <summary>
        /// auto mapper seperates configuration from code
        /// if the fields does not match between the two it does not fail 
        /// </summary>
        public MapperConfiguration pToPd = new MapperConfiguration(p => p.CreateMap<Person, PersonDAO>()
        .ForMember(d => d.firstname, c => c.MapFrom("FirstName"))
        .ForMember(d => d.personid, c=> c.MapFrom("PersonID")));
        // public MapperConfiguration p = new MapperConfiguration(p => p.CreateMap<PersonDAO, Person>().ForMember(d => d.FirstName, c => c.MapFrom("FirstName")));
        public MapperConfiguration cToCd = new MapperConfiguration(p => p.CreateMap<Courses, CoursesDAO>()
        .ForMember(d => d.CourseName, c=>c.MapFrom("CourseName"))
        );
        public MapperConfiguration dToCc = new MapperConfiguration(p => p.CreateMap<CoursesDAO, Courses>().ForMember(d => d.CourseName, c => c.MapFrom("CourseName")));

        /// <summary>
        /// Maps word for word
        /// </summary>
        /// <param name="pd"></param>
        /// <returns></returns>
        public Person PersonDAOToPerson(PersonDAO pd)
        {
            return new Person() { FirstName = pd.firstname, LastName = pd.lastname };
        }

        private T PersonDAOToPerson2<T>(PersonDAO pd)
        {
            return pdTop.CreateMapper().Map<T>(pd);
        }


        private T PersonToPersonDAO<T>(Person p)
        {
            return pToPd.CreateMapper().Map<T>(p);

        }

        private T CoursesToCoursesDAO<T>(Courses c)
        {
            return cToCd.CreateMapper().Map<T>(c);
        }

        private T CoursesDAOToCourses<T>(CoursesDAO c)
        {
            return dToCc.CreateMapper().Map<T>(c);
        }

        public List<CoursesDAO> Courses()
        {
            var cd = new List<CoursesDAO>();
            foreach (var item in db.Courses())
            {
                cd.Add(CoursesToCoursesDAO<CoursesDAO>(item));
            }
            return cd;
        }

        public List<PersonDAO> Persons()
        {
            var pd = new List<PersonDAO>();
            foreach (var item in db.Persons())
            {
              pd.Add(PersonToPersonDAO<PersonDAO>(item));
            }
            return pd;
        }

        public List<PersonDAO> Instructors()
        {
            var pd = new List<PersonDAO>();
            foreach (var item in db.Instructors())
            {
                pd.Add(PersonToPersonDAO<PersonDAO>(item));
            }
            return pd;
        }

        public List<PersonDAO> Students()
        {
            var pd = new List<PersonDAO>();
            foreach (var item in db.Students())
            {
                pd.Add(PersonToPersonDAO<PersonDAO>(item));
            }
            return pd;
        }

        public List<PersonDAO> Registers()
        {
            var pd = new List<PersonDAO>();
            foreach (var item in db.Registers())
            {
                pd.Add(PersonToPersonDAO<PersonDAO>(item));
            }
            return pd;
        }

        public bool CreatePerson(PersonDAO p)
        {
            return db.CreatePerson(PersonDAOToPerson2<Person>(p));
        }

        public bool AddCourse(int courseid, int id)
        {
            return db.AddCourse(courseid, id);
        }

        public bool CreateCourse(CoursesDAO c, int id)
        {
            return db.CreateCourse(CoursesDAOToCourses<Courses>(c), id);
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

        public bool EditCourse(CoursesDAO co)
        {
            return db.EditCourse(CoursesDAOToCourses<Courses>(co));
        }

        public List<PersonDAO> GetStudents(int i)
        {
            var cl = new List<PersonDAO>();

            foreach (var item in db.GetStudents(i))
            {
                cl.Add(PersonDAOToPerson2<PersonDAO>(item));
            }

            return cl;
        }

        private T PersonDAOToPerson2<T>(Person item)
        {
            return pToPd.CreateMapper().Map<T>(item);
        }

        public List<CoursesDAO> GetPendingCourses(int i)
        {
            var cd = new List<CoursesDAO>();
            foreach (var item in db.GetPendingCourses(i))
            {
                cd.Add(CoursesToCoursesDAO<CoursesDAO>(item));
            }
            return cd;
        }

        public List<CoursesDAO> GetInstructorCourses(int i)
        {
            var cd = new List<CoursesDAO>();
            foreach (var item in db.GetInstructorCourses(i))
            {
                cd.Add(CoursesToCoursesDAO<CoursesDAO>(item));
            }
            return cd;
        }

        public List<CoursesDAO> GetRegisteredCourses(int i)
        {
            var cd = new List<CoursesDAO>();
            foreach (var item in db.GetRegisteredCourses(i))
            {
                cd.Add(CoursesToCoursesDAO<CoursesDAO>(item));
            }
            return cd;
        }
    }
}
