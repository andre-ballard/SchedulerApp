using AutoMapper;
using ScheduleLogic.Models;
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
        private MapperConfiguration pDTOTopDAO = new MapperConfiguration(m => m.CreateMap<PersonDTO, PersonDAO>().ForMember(d => d.roleid, c=> c.MapFrom("Role")));
        private MapperConfiguration pDAOTopDTO = new MapperConfiguration(m => m.CreateMap<PersonDAO, PersonDTO>());
        private MapperConfiguration cDAOTocDTO = new MapperConfiguration(m => m.CreateMap<CoursesDAO, CoursesDTO>());
        private MapperConfiguration cDTOTocDAO = new MapperConfiguration(m => m.CreateMap<CoursesDTO, CoursesDAO>());

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
                cl.Add(CMapToDTO<CoursesDTO>(item));
            }

            return cl;
        }
        public List<PersonDTO> Persons()
        {
            var pl = new List<PersonDTO>();

            foreach (var item in lb.Persons())
            {
                pl.Add(MapToDTO<PersonDTO>(item));
            }

            return pl;
        }

        public List<PersonDTO> Instructors()
        {
            var pl = new List<PersonDTO>();

            foreach (var item in lb.Instructors())
            {
                pl.Add(MapToDTO<PersonDTO>(item));
            }

            return pl;
        }

        public List<PersonDTO> Students()
        {
            var pl = new List<PersonDTO>();

            foreach (var item in lb.Students())
            {
                pl.Add(MapToDTO<PersonDTO>(item));
            }

            return pl;
        }

        public List<PersonDTO> Registers()
        {
            var pl = new List<PersonDTO>();

            foreach (var item in lb.Registers())
            {
                pl.Add(MapToDTO<PersonDTO>(item));
            }

            return pl;
        }

        public bool AddPerson(PersonDTO p)
        {
            return lb.CreatePerson(MapToDAO<PersonDAO>(p));
        }

        public bool AddCourse(int courseid, int id)
        {
            return lb.AddCourse(courseid, id);
        }

        public bool CreateCourse(CoursesDTO c, int id)
        {
            return lb.CreateCourse(CTOMapToDAO<CoursesDAO>(c), id);
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

        public bool EditCourse(CoursesDTO c)
        {
            return lb.EditCourse(CTOMapToDAO<CoursesDAO>(c));
        }

        public List<CoursesDTO> GetStudentPendingCourses(int i)
        {
            var cl = new List<CoursesDTO>();

            foreach (var item in lb.GetPendingCourses(i))
            {
                cl.Add(CMapToDTO<CoursesDTO>(item));
            }

            return cl;
        }

        public List<PersonDTO> GetStudents(int i)
        {
            var cl = new List<PersonDTO>();

            foreach (var item in lb.GetStudents(i))
            {
                cl.Add(MapToDAO<PersonDTO>(item));
            }

            return cl;
        }

        private T MapToDAO<T>(PersonDAO item)
        {
            return pDAOTopDTO.CreateMapper().Map<T>(item);
        }

        public List<CoursesDTO> GetInstructorCourses(int i)
        {
            var cl = new List<CoursesDTO>();

            foreach (var item in lb.GetInstructorCourses(i))
            {
                cl.Add(CMapToDTO<CoursesDTO>(item));
            }

            return cl;
        }

        public List<CoursesDTO> GetStudentRegisteredCourses(int i)
        {
            var cl = new List<CoursesDTO>();

            foreach (var item in lb.GetRegisteredCourses(i))
            {
                cl.Add(CMapToDTO<CoursesDTO>(item));
            }

            return cl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p"></param>
        /// <returns></returns>
        private T MapToDTO<T>(PersonDAO p)
        {
            return pDAOTopDTO.CreateMapper().Map<T>(p);
        }
        private T CMapToDTO<T>(CoursesDAO p)
        {
            return cDAOTocDTO.CreateMapper().Map<T>(p);
        }

        private T CTOMapToDAO<T>(CoursesDTO c)
        {
            return cDTOTocDAO.CreateMapper().Map<T>(c);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p"></param>
        /// <returns></returns>
        private T MapToDAO<T>(PersonDTO p)
        {
            return pDTOTopDAO.CreateMapper().Map<T>(p);
        }
    }
}