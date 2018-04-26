using System;
using System.Collections.Generic;
using SchedulerApp.Data;

namespace SchedulerApp.Controllers
{
  public class CourseActions
  {
    private const int MAX = 20;

    public static List<Person> Students = new List<Person>();
    public double RollCount()
    {
      System.Console.WriteLine(Students.Count);
      return Students.Count;
    }

    public bool CapacityCheck()
    {
        if(Students.Count<MAX)
        {
          System.Console.WriteLine("Class is still available");
          return true;
        }
        else
        {
          System.Console.WriteLine("Class is closed");
          return false;
        }

    }

   
  
  }
}