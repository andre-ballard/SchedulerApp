using AutoMapper;
using SchedulerApp.Data;
using SchedulerApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleLogic.Mapper
{
    public class DAOMapper
    {
        public MapperConfiguration pdTop = new MapperConfiguration(p => p.CreateMap<PersonDAO, Person>().ForMember(d => d.RoleID, c => c.MapFrom("roleid")));

        /// <summary>
        /// auto mapper seperates configuration from code
        /// if the fields does not match between the two it does not fail 
        /// </summary>
        public MapperConfiguration pToPd = new MapperConfiguration(p => p.CreateMap<Person, PersonDAO>()
        .ForMember(d => d.firstname, c => c.MapFrom("FirstName"))
        .ForMember(d => d.personid, c => c.MapFrom("PersonID")));
        // public MapperConfiguration p = new MapperConfiguration(p => p.CreateMap<PersonDAO, Person>().ForMember(d => d.FirstName, c => c.MapFrom("FirstName")));
        public MapperConfiguration cToCd = new MapperConfiguration(p => p.CreateMap<Courses, CoursesDAO>()
        .ForMember(d => d.CourseName, c => c.MapFrom("CourseName"))
        );
        public MapperConfiguration dToCc = new MapperConfiguration(p => p.CreateMap<CoursesDAO, Courses>().ForMember(d => d.CourseName, c => c.MapFrom("CourseName")));

        

        public T PersonDAOToPerson2<T>(PersonDAO pd)
        {
            return pdTop.CreateMapper().Map<T>(pd);
        }


        public T PersonToPersonDAO<T>(Person p)
        {
            return pToPd.CreateMapper().Map<T>(p);

        }

        public T CoursesToCoursesDAO<T>(Courses c)
        {
            return cToCd.CreateMapper().Map<T>(c);
        }

        public T CoursesDAOToCourses<T>(CoursesDAO c)
        {
            return dToCc.CreateMapper().Map<T>(c);
        }

        private T PersonDAOToPerson2<T>(Person item)
        {
            return pToPd.CreateMapper().Map<T>(item);
        }

    }
}
