using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Logic.Models
{
    public class CoursesDAO
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Instructor { get; set; }
        public int Capacity { get; set; }
        public int CourseHour { get; set; }
        public int UserID { get; set; }
    }
}
