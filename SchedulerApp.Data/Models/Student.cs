using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Data
{
  public class Student
  {
    //public const int MAX = 16;
    public int PersonID { get; set; }
    public int Hours { get; set; }
    public int Status { get; set; }
        /*public bool CreditCheck(Courses c)
        {
         if(c.CourseHour + Hours < MAX)
            {
              return true;
            }
         else
            {
              return false;
            }
        }*/


    }
}

