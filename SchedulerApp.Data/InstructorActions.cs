using System;
using System.Collections.Generic;
using SchedulerApp.Data;
namespace SchedulerApp.Controllers
{

  public class InstructorActions 
  {
    public static List<Student> _Students = new List<Student>();
    public static List<Courses> _Courses = new List<Courses>();
    
  public bool CreateCourse(string name, int hour)
  {
    try{
    _Courses.Add(new Courses(name,hour));
    return true;
    }catch{
      return false;
    }
  }
  //* 
  //this is for the registra  
  public void ListAllStudents()
  {
      foreach(var o in _Students)
      {
        System.Console.WriteLine(o.ToString());
      }
  }

  public bool UpdateCourse()
  {
            return true;
    
  }

  public bool DeleteCourse()
  {
            return true;

  }
  public void ListAllCourses()
  {
    foreach(var o in _Courses)
    {
      System.Console.WriteLine(o.ToString());
    }
  }
    
  }

}