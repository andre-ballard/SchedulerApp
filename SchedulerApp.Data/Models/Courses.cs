using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Data
{
  public class Courses
  {
    public int CourseID { get; set; }
    public string CourseName { get; set; }
    public string Instructor { get; set; }
    public int Capacity { get; set; }
    public int CourseHour { get; set; }
    public int UserID { get; set; }
    

    //When using initializer optional items must come last..
    public Courses()
    {
    }

    public Courses(string coursename, int coursehour)
    {
      Initializer(coursename, coursehour);
    }
    public Courses(string coursename, int coursehour, int capacity)
    {
      Initializer(coursename, coursehour, capacity);
    }

    public void Initializer(string coursename = "Physics", int coursehour = 1, int capacity = 0)
    {
      CourseName = coursename;
      CourseHour = coursehour;
      Capacity = capacity;
      //"??" null operator used to reutrn a value for you (simple if else statement in one line ) if its true return the value if not return false
    }

    public override string ToString()
    {
      return string.Format("{0}, {1}", CourseName, CourseHour);
    }
  }
}
