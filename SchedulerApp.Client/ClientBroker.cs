using AutoMapper;
using SchedulerApp.Client.Mapper;
using SchedulerApp.Client.Models;
using SchedulerApp.Logic;
using SchedulerApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerApp.Client
{
    public class ClientBroker
    {
        private LogicBroker lb = new LogicBroker();
        private DTOMapper mapper = new DTOMapper();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        public List<CoursesDTO> Courses()
        {
            var cl = new List<CoursesDTO>();

            foreach (var item in lb.Courses())
            {
                cl.Add(mapper.CMapToDTO<CoursesDTO>(item));
            }

            return cl;
        }
        public List<PersonDTO> Persons()
        {
            var pl = new List<PersonDTO>();

            foreach (var item in lb.Persons())
            {
                pl.Add(mapper.MapToDTO<PersonDTO>(item));
            }

            return pl;
        }

        public List<PersonDTO> Instructors()
        {
            var pl = new List<PersonDTO>();

            foreach (var item in lb.Instructors())
            {
                pl.Add(mapper.MapToDTO<PersonDTO>(item));
            }

            return pl;
        }

        public List<PersonDTO> Students()
        {
            var pl = new List<PersonDTO>();

            foreach (var item in lb.Students())
            {
                pl.Add(mapper.MapToDTO<PersonDTO>(item));
            }

            return pl;
        }

        public List<PersonDTO> Registers()
        {
            var pl = new List<PersonDTO>();

            foreach (var item in lb.Registers())
            {
                pl.Add(mapper.MapToDTO<PersonDTO>(item));
            }

            return pl;
        }

        public bool AddPerson(PersonDTO p)
        {
            return lb.CreatePerson(mapper.MapToDAO<PersonDAO>(p));
        }

        public bool AddCourse(int courseid, int id)
        {
            return lb.AddCourse(courseid, id);
        }

        public bool CreateCourse(CoursesDTO c, int id)
        {
            return lb.CreateCourse(mapper.CTOMapToDAO<CoursesDAO>(c), id);
        }

        public bool RemovePendingCourse(int courseid, int id)
        {
            return lb.RemovePendingCourse(courseid, id);
        }

        public bool DropRegisteredCourse(int courseid, int id)
        {
            return lb.DropRegisteredCourse(courseid, id);
        }

        public bool RegisterCourse(int courseid, int id)
        {
            return lb.RegisterCourse(courseid, id);
        }

        public bool DeleteCourse(int courseid)
        {
            return lb.DeleteCourse(courseid);
        }

        public bool DeleteStudent(int studentid, int courseid)
        {
            return lb.DeleteStudent(studentid, courseid);
        }

        public bool EditCourse(CoursesDTO c)
        {
            return lb.EditCourse(mapper.CTOMapToDAO<CoursesDAO>(c));
        }

        public List<CoursesDTO> GetStudentPendingCourses(int i)
        {
            var cl = new List<CoursesDTO>();

            foreach (var item in lb.GetPendingCourses(i))
            {
                cl.Add(mapper.CMapToDTO<CoursesDTO>(item));
            }

            return cl;
        }

        public List<PersonDTO> GetStudents(int i)
        {
            var cl = new List<PersonDTO>();

            foreach (var item in lb.GetStudents(i))
            {
                cl.Add(mapper.MapToDTO<PersonDTO>(item));
            }

            return cl;
        }

        public List<CoursesDTO> GetInstructorCourses(int i)
        {
            var cl = new List<CoursesDTO>();

            foreach (var item in lb.GetInstructorCourses(i))
            {
                cl.Add(mapper.CMapToDTO<CoursesDTO>(item));
            }

            return cl;
        }

        public List<CoursesDTO> GetStudentRegisteredCourses(int i)
        {
            var cl = new List<CoursesDTO>();

            foreach (var item in lb.GetRegisteredCourses(i))
            {
                cl.Add(mapper.CMapToDTO<CoursesDTO>(item));
            }

            return cl;
        }
        
    }
}