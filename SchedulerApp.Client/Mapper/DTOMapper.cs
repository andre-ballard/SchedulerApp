using AutoMapper;
using SchedulerApp.Client.Models;
using SchedulerApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerApp.Client.Mapper
{
    public class DTOMapper
    {
        private MapperConfiguration pDTOTopDAO = new MapperConfiguration(m => m.CreateMap<PersonDTO, PersonDAO>().ForMember(d => d.roleid, c => c.MapFrom("Role")));
        private MapperConfiguration pDAOTopDTO = new MapperConfiguration(m => m.CreateMap<PersonDAO, PersonDTO>());
        private MapperConfiguration cDAOTocDTO = new MapperConfiguration(m => m.CreateMap<CoursesDAO, CoursesDTO>());
        private MapperConfiguration cDTOTocDAO = new MapperConfiguration(m => m.CreateMap<CoursesDTO, CoursesDAO>());

        public T MapToDTO<T>(PersonDAO p)
        {
            return pDAOTopDTO.CreateMapper().Map<T>(p);
        }
        public T CMapToDTO<T>(CoursesDAO p)
        {
            return cDAOTocDTO.CreateMapper().Map<T>(p);
        }

        public T CTOMapToDAO<T>(CoursesDTO c)
        {
            return cDTOTocDAO.CreateMapper().Map<T>(c);
        }

        public T MapToDAO<T>(PersonDTO p)
        {
            return pDTOTopDAO.CreateMapper().Map<T>(p);
        }

        private T MapToDAO<T>(PersonDAO item)
        {
            return pDAOTopDTO.CreateMapper().Map<T>(item);
        }
    }
}