using SchedulerApp.Client.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchedulerApp.Client.Models
{
    
    public class PersonDTO
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }   
        //[Display(Name = "Surname")]

        [DataType(DataType.Text, ErrorMessage = "Text Only")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public string Role { get; set; }
    }
}