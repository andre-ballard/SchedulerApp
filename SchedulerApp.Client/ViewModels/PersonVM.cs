using SchedulerApp.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerApp.Client.ViewModels
{
    public class PersonVM

    {
        private ClientBroker cb = new ClientBroker();

        int User;

        public PersonVM()
        {


        }
        public PersonVM(int user)
        {
            User = user;
        }
        public List<PersonDTO> Persons
        {
            get
            {
                return cb.Persons();
            }
        }

        public List<PersonDTO> Instructors
        {
            get
            {
                return cb.Instructors();
            }
        }

        public List<PersonDTO> Students
        {
            get
            {
                return cb.Students();
            }
        }

        public List<PersonDTO> Registers
        {
            get
            {
                return cb.Registers();
            }
        }

        public List<PersonDTO> AllStudents
        {
            get
            {
                return cb.GetStudents(User);
            }
        }
    }
}