using System.Collections.Generic;
using System.Data.SqlClient;

namespace SchedulerApp.Data
{

  
   public class StudentActions : Student
  {
   /* public static List<Courses> _Courses = new List<Courses>();
    public static List<Courses> _PendingCourses = new List<Courses>();
    private const string CONNECTION_STRING = @"data source = adventureworks.ctwemdjpages.us-east-2.rds.amazonaws.com; initial catalog = adventureworks; user id = andre; password = password;"; // where the connection is
                                                                                                                                                                                                //public static Course Course = new Course();

    public bool AddPendingCourse(Courses c, Person p)
    {
      var con = GetConnection();
      var cid = new SqlParameter("cid", c.CourseID);  //this way protects from injections
      var pid = new SqlParameter("pid", p.PersonID);
      SqlCommand com = new SqlCommand(string.Format("insert into Person.Person({0}) values(@cid, @pid)", "CourseID, PersonID"));
      //SqlDataAdapter da = new SqlDataAdapter();     //-sql connection is not on continuously connected
      //c.Open();
      //com.Connection = c;
      var affected = com.ExecuteNonQuery();
      //c.Close();
      if (affected > 1)
      {
        return true;
      }
      else
      {
        return false;
      }
    
    }

    //register individual pending course
   /* public bool RegisterPendingCourse(Courses c)
    {
      if(CreditCheck(c)){
      try{
        _Courses.Add(c);
        return true;
      }
      catch
      {
        return false;
      }
      }
      System.Console.WriteLine("You are over the cred hour limit!");
      return false;
    }
    
    //Register single course
    public bool SubmitCourse(Courses c)
    {
        if(CreditCheck(c))
        {
          try{
                if(_PendingCourses.Exists(o=>o.CourseName==c.CourseName))
                    {       
                      _Courses.Add(_PendingCourses.Find(o=>o.CourseName==c.CourseName));
                    }
                else
                    {
                      _Courses.Add(c);
                    }
                    _PendingCourses.Remove(_PendingCourses.Find(o=>o.CourseName==c.CourseName));
              return true;  
              }
          catch{
              return false;
               }
        }
      else{
        System.Console.WriteLine("You have reached the max amount of credits!");
      }
      return false;
    }
    
    //Register all courses in pending list
     public bool SubmitAllCourses()
    {
      List<Courses> tmp= new List<Courses>();  
        foreach(var o in _PendingCourses)
        {
          //System.Console.WriteLine("Code reached here!");
          if(o.CourseHour+CalculateStudentCredits()<=MAX)
          { 
            System.Console.WriteLine(o.CourseHour+CalculateStudentCredits());
            tmp.Add(o);
            _Courses.Add(o);
          }
          else
          {
            foreach(var p in tmp)
            {
            _Courses.Remove(p);
            System.Console.WriteLine("Courses exceed credit hour limit");
            }
            return false;
          }
        }   
          _PendingCourses.Clear();
          System.Console.WriteLine("Added!");   
          return true;
    }
    //list of submitted classes
    public void ListStudentSubmittedCourses()
    {
      foreach(var o in _Courses)
      {
      System.Console.WriteLine(o.ToString());
      }
    }
    //List pending classes(not submitted)
    public void ListStudentPendingCourses()
    {
      foreach(var o in _PendingCourses)
      {
      System.Console.WriteLine(o.ToString());
      }
    }
    //calculates submitted total credit hours
    public double CalculateStudentCredits()
    {
      var hours = Hours;
      foreach(var o in _Courses)
      {
        hours += o.CourseHour;
      }
      return hours;
    }
    //checks if course is already in list
    public bool CourseExist()
    {
      return true;
    }
    //calculates Pending credit hours
    public double CalculatePendingCredits()
    {
      var hours = Hours;
      foreach(var o in _PendingCourses)
      {
        hours += o.CourseHour;
      }
      //System.Console.WriteLine(hours);
      //System.Console.WriteLine(hours);
      return hours;
    }
    //finds and drop student course
    public void DopCourse(Courses c)
    {
      if(_Courses.Exists(o => o.CourseName == c.CourseName))
      {
      _Courses.Remove(_Courses.Find(o=>o.CourseName == c.CourseName));
      }else
      {
        _PendingCourses.Remove(_PendingCourses.Find(o =>o.CourseName == c.CourseName));
      }
    }
    //check if student has max credits
    private SqlConnection GetConnection()
    {
      SqlConnection con = new SqlConnection(CONNECTION_STRING);
      return con;
    } */
        

  }
}