using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class DataAccess
    {
        private string _ConnectionString = "Server=tcp:your-fitness.database.windows.net,1433;Initial Catalog=SchedulerApp;Persist Security Info=False;User ID=andre.ballard;Password=Tamuk2016;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public List<Person> GetStudents(int i)
        {
            var ds = new DataSet();
            var command = new SqlCommand("select Person.Person.PersonID, FirstName, LastName from Person.Person join Person.PersonCourses on Person.PersonCourses.PersonID = Person.Person.PersonID where Not Person.PersonCourses.CourseStatus = 3 and  Person.PersonCourses.CourseID = @id");
            var p = new List<Person>();
            command.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("id", i)
            });
            using (var c = GetConnectionInstance())
            {
                var da = new SqlDataAdapter();

                c.Open();
                command.Connection = c;
                da.SelectCommand = command;
                da.Fill(ds);
            }

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                p.Add(new Person() { PersonID = (Int32) item["PersonID"], FirstName = item["FirstName"].ToString(), LastName = item["LastName"].ToString() });
            }

            return p;
        }


        public List<Courses> GetInstructorCourses(int i)
        {
            var ds = new DataSet();
            var command = new SqlCommand("select PersonCourses.CourseID, CourseName, CourseHour, Capacity from Person.PersonCourses join Person.Courses on Person.Courses.CourseID = Person.PersonCourses.CourseID where Person.PersonCourses.PersonID = @id");
            var p = new List<Courses>();
            command.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("id", i),
            });
            using (var c = GetConnectionInstance())
            {
                var da = new SqlDataAdapter();

                c.Open();
                command.Connection = c;
                da.SelectCommand = command;
                da.Fill(ds);
            }

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                p.Add(new Courses() { CourseID = int.Parse(item["CourseID"].ToString()), CourseName = item["CourseName"].ToString(), CourseHour = int.Parse(item["CourseHour"].ToString()), Capacity = int.Parse(item["Capacity"].ToString()) });
            }

            return p;
        }

        public List<Courses> GetPendingCourses(int i)
        {
            var ds = new DataSet();
            var command = new SqlCommand("select Instructor, PersonCourses.CourseID, CourseName, CourseHour from Person.PersonCourses join Person.Courses on Person.Courses.CourseID = Person.PersonCourses.CourseID where Person.PersonCourses.PersonID = @id AND Person.PersonCourses.CourseStatus = @coursestatus");
            var p = new List<Courses>();
            command.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("id", i),
                    new SqlParameter("coursestatus", Convert.ToInt32(0))
            });
            using (var c = GetConnectionInstance())
            {
                var da = new SqlDataAdapter();

                c.Open();
                command.Connection = c;
                da.SelectCommand = command;
                da.Fill(ds);
            }

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                p.Add(new Courses() { CourseID = int.Parse(item["CourseID"].ToString()), CourseName = item["CourseName"].ToString(), CourseHour = int.Parse(item["CourseHour"].ToString()), Instructor = item["Instructor"].ToString() });
            }

            return p;
        }

        public List<Courses> GetRegisteredCourses(int i)
        {
            var ds = new DataSet();
            var command = new SqlCommand("select Instructor, PersonCourses.CourseID, CourseName, CourseHour from Person.PersonCourses join Person.Courses on Person.Courses.CourseID = Person.PersonCourses.CourseID where Person.PersonCourses.PersonID = @id AND Person.PersonCourses.CourseStatus = @coursestatus");
            var p = new List<Courses>();
            command.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("id", i),
                    new SqlParameter("coursestatus", Convert.ToInt32(1))
            });
            using (var c = GetConnectionInstance())
            {
                var da = new SqlDataAdapter();

                c.Open();
                command.Connection = c;
                da.SelectCommand = command;
                da.Fill(ds);
            }

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                p.Add(new Courses() { CourseID = int.Parse(item["CourseID"].ToString()), CourseName = item["CourseName"].ToString(), CourseHour = int.Parse(item["CourseHour"].ToString()), Instructor = item["Instructor"].ToString() });
            }

            return p;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Person> Persons()
        {
            var ds = new DataSet();
            var command = new SqlCommand("select * from Person.Person;");
            var p = new List<Person>();

            using (var c = GetConnectionInstance())
            {
                var da = new SqlDataAdapter();

                c.Open();
                command.Connection = c;
                da.SelectCommand = command;
                da.Fill(ds);
            }

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                p.Add(new Person() { PersonID = int.Parse(item["PersonId"].ToString()), FirstName = item["FirstName"].ToString(), LastName = item["LastName"].ToString() });
            }

            return p;
        }

        public List<Person> Instructors()
        {
            var ds = new DataSet();
            var command = new SqlCommand("select * from Person.Person where RoleInfoId=2;");
            var p = new List<Person>();

            using (var c = GetConnectionInstance())
            {
                var da = new SqlDataAdapter();

                c.Open();
                command.Connection = c;
                da.SelectCommand = command;
                da.Fill(ds);
            }

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                p.Add(new Person() { PersonID = int.Parse(item["PersonId"].ToString()), FirstName = item["FirstName"].ToString(), LastName = item["LastName"].ToString() });
            }

            return p;
        }

        public List<Courses> Courses()
        {
            var ds = new DataSet();
            var command = new SqlCommand("select * from Person.Courses");
            var p = new List<Courses>();

            using (var c = GetConnectionInstance())
            {
                var da = new SqlDataAdapter();

                c.Open();
                command.Connection = c;
                da.SelectCommand = command;
                da.Fill(ds);
            }

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                p.Add(new Courses() { CourseID = int.Parse(item["CourseID"].ToString()), CourseName = item["CourseName"].ToString(), Instructor = item["Instructor"].ToString(), Capacity = int.Parse(item["Capacity"].ToString()), CourseHour = int.Parse(item["CourseHour"].ToString()) });
            }

            return p;
        }


        public List<Person> Students()
        {
            var ds = new DataSet();
            var command = new SqlCommand("select * from Person.Person where RoleInfoId=1;");
            var p = new List<Person>();

            using (var c = GetConnectionInstance())
            {
                var da = new SqlDataAdapter();

                c.Open();
                command.Connection = c;
                da.SelectCommand = command;
                da.Fill(ds);
            }

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                p.Add(new Person() { PersonID = int.Parse(item["PersonId"].ToString()), FirstName = item["FirstName"].ToString(), LastName = item["LastName"].ToString() });
            }

            return p;
        }

        public List<Person> Registers()
        {
            var ds = new DataSet();
            var command = new SqlCommand("select * from Person.Person where RoleInfoId=3;");
            var p = new List<Person>();

            using (var c = GetConnectionInstance())
            {
                var da = new SqlDataAdapter();

                c.Open();
                command.Connection = c;
                da.SelectCommand = command;
                da.Fill(ds);
            }

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                p.Add(new Person() { PersonID = int.Parse(item["PersonId"].ToString()), FirstName = item["FirstName"].ToString(), LastName = item["LastName"].ToString() });
            }

            return p;
        }

        public bool CreatePerson(Person p)
        {

            var command = new SqlCommand("insert into Person.Person values (@first, @last, @role); SELECT scope_identity()");
            var command2 = new SqlCommand("insert into Person.Student values (@id,@hours,Cast(@status as NVARCHAR(2)))");
            int result = 0;

            command.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("first", p.FirstName),
                    new SqlParameter("last", p.LastName),
                    new SqlParameter("role", p.RoleID)
            });

            using (var c = GetConnectionInstance())
            {
                c.Open();
                command.Connection = c;
                command2.Connection = c;
                result = command.ExecuteNonQuery();
                var test = command.ExecuteScalar();

                if (p.RoleID == 1)
                {

                    command2.Parameters.AddRange(new SqlParameter[]
                    {
                        new SqlParameter("id", test),
                        new SqlParameter("hours", Convert.ToInt32(0)),
                        new SqlParameter("status", Convert.ToInt32(0))
                    });


                    command2.ExecuteNonQuery();
                    //CreateStudent(test);
                }
            }
            return result > 0;
        }

        public bool CreateCourse(Courses co, int id)
        {

            var command = new SqlCommand("insert into Person.Courses values (@coursename, @capacity, @coursehour, @instructor);Select scope_identity();"); 
            var command3 = new SqlCommand("insert into Person.PersonCourses values (@userid,@id,@status)");
            var command2 = new SqlCommand("select FirstName from Person.Person where PersonID = @id");
            

            

            command2.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("id", id)
                }
                );
            using (var c = GetConnectionInstance())
            {
                c.Open();
                command2.Connection = c;
                var instructor = command2.ExecuteScalar();
                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("coursename", co.CourseName),
                    new SqlParameter("capacity", Convert.ToInt32(0)),
                    new SqlParameter("coursehour", co.CourseHour),
                    new SqlParameter("instructor", instructor),
                    
                });

                command.Connection = c;
                
                var id2 = command.ExecuteScalar();
                command3.Connection = c;
                command3.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("userid",id),

                    new SqlParameter("id", id2),
                    new SqlParameter("status", Convert.ToInt32(3))
                });
                command3.ExecuteNonQuery();
            }
            return true;
        }

        public bool EditCourse(Courses cs)
        {

            var command = new SqlCommand("Update Person.Courses set CourseName = @coursename, CourseHour = @courseHour where CourseID = @id;");
            var result = 0;




            command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("coursename", cs.CourseName),
                    new SqlParameter("coursehour", cs.CourseHour),
                    new SqlParameter("id", cs.CourseID)
                }
                );
            using (var c = GetConnectionInstance())
            {
                c.Open();
                command.Connection = c;
                result = command.ExecuteNonQuery();
            }
            return result > 0;
        }

        public bool DeleteCourse(int courseid)
        {
            var command = new SqlCommand("Delete from Person.Courses where CourseID = @courseid");
            var command2 = new SqlCommand("Delete from Person.PersonCourses where CourseID = @courseid");
            int result = 0;

            command2.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("courseid", courseid)
                   
            });

            command.Parameters.AddRange(new SqlParameter[]
             {
                    new SqlParameter("courseid", courseid)

             });
            using (var c = GetConnectionInstance())
            {
                c.Open();
                command2.Connection = c;
                command.Connection = c;
                result = command2.ExecuteNonQuery() + command.ExecuteNonQuery();
            }
            return result == 2;
        }

        public bool DeleteStudent(int studentid, int courseid)
        {
            
            var command = new SqlCommand("Delete from Person.PersonCourses where PersonID = @personid and CourseID = @courseid");
            var command2 = new SqlCommand("Update Person.Courses Set Capacity = Capacity - 1 where CourseID = @courseid");
            int result = 0;

            

            command.Parameters.AddRange(new SqlParameter[]
             {
                    new SqlParameter("personid", studentid),
                    new SqlParameter("courseid", courseid)
             });
            command2.Parameters.AddRange(new SqlParameter[]
             {
                    new SqlParameter("courseid", courseid)
             });
            using (var c = GetConnectionInstance())
            {
                c.Open();
                command.Connection = c;
                command2.Connection = c;
                result = command2.ExecuteNonQuery() + command.ExecuteNonQuery();
                
            }
            return result == 2;
        }

        public bool AddCourse(int courseid, int id)
        {
            if (!PCourse_Exist(id, courseid))
            {
                var command = new SqlCommand("insert into Person.PersonCourses values (@id, @courseid, @status);");
                int result = 0;

                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("id", id),
                    new SqlParameter("courseid", courseid),
                    new SqlParameter("status", Convert.ToInt32(0))
                });

                using (var c = GetConnectionInstance())
                {
                    c.Open();
                    command.Connection = c;
                    result = command.ExecuteNonQuery();
                }
                return result > 0;

            }
            else
            {
                return false;
            }
        }

        public bool RemovePendingCourse(int courseid, int id)
        {
            var command = new SqlCommand("Delete from Person.PersonCourses where PersonID = @id and CourseID = @courseid and CourseStatus = 0");
            int result = 0;

            command.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("id", id),
                    new SqlParameter("courseid", courseid),
            });

            using (var c = GetConnectionInstance())
            {
                c.Open();
                command.Connection = c;
                result = command.ExecuteNonQuery();
            }
            return result > 0;
        }

        public bool DropRegisteredCourse(int courseid, int id)
        {
            var command = new SqlCommand("Delete from Person.PersonCourses where PersonID = @id and CourseID = @courseid and CourseStatus = 1;");
            var command2 = new SqlCommand("select Capacity from Person.Courses where CourseID = @courseid;");

            int result = 0;

            command.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("id", id),
                    new SqlParameter("courseid", courseid),
            });
            command2.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("courseid", courseid),
            });
            using (var c = GetConnectionInstance())
            {
                c.Open();
                command.Connection = c;
                command2.Connection = c;
                result = command.ExecuteNonQuery();
                var capacity = command2.ExecuteScalar();
                var updatecapacity = new SqlCommand("update Person.Courses set Capacity = @ocapacity - 1 where CourseID = @courseid");

                updatecapacity.Parameters.AddRange(new SqlParameter[]
                    {
                            new SqlParameter("ocapacity", capacity),
                            new SqlParameter("courseid", courseid)
                 });
                updatecapacity.Connection = c;
                updatecapacity.ExecuteNonQuery();
            }
            return result > 0;
        }

        
        public bool RegisterCourse(int courseid, int id)
        {
            if (CapacityCheck(courseid) && !Course_Exist(id, courseid))
            {
                var command = new SqlCommand("insert into Person.PersonCourses values (@id, @courseid,@status);");
                var command2 = new SqlCommand("select Capacity from Person.Courses where CourseID = @courseid;");
                var command3 = new SqlCommand("Delete from Person.PersonCourses where CourseID = @courseid and PersonID = @id and CourseStatus = 0;");

                int result = 0;

                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("id", id),
                    new SqlParameter("courseid", courseid),
                    new SqlParameter("status", 1)
                });

                command2.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("courseid", courseid),
                });

                command3.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("courseid", courseid),
                    new SqlParameter("id", id)
                });
                using (var c = GetConnectionInstance())
                {
                    c.Open();
                    command.Connection = c;
                    command2.Connection = c;
                    result = command.ExecuteNonQuery();
                    var capacity = command2.ExecuteScalar();
                    var updatecapacity = new SqlCommand("update Person.Courses set Capacity = @ocapacity + @ncapacity where CourseID = @courseid");

                    updatecapacity.Parameters.AddRange(new SqlParameter[]
                        {
                            new SqlParameter("ocapacity", capacity),
                            new SqlParameter("ncapacity", 1),
                            new SqlParameter("courseid", courseid)
                     });
                    updatecapacity.Connection = c;
                    command3.Connection = c;
                    updatecapacity.ExecuteNonQuery();
                    command3.ExecuteNonQuery();
                }
                return result > 0;
            }
            else { return false; }
        }

        private bool CapacityCheck(int course)
        {

            var command = new SqlCommand("select Capacity from Person.Courses where CourseID = @courseid;");

            var capacity = false;

            command.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("courseid", course)
            });

            using (var c = GetConnectionInstance())
            {
                c.Open();
                command.Connection = c;
                int result = (int)command.ExecuteScalar();
                if (result <= 20)
                {
                    capacity = true;
                }
                else
                {
                    capacity = false;
                }
            }

            return capacity;

        }

        private bool Course_Exist(int id, int courseid)
        {
            var command = new SqlCommand("select Count(*) from Person.PersonCourses where CourseID = @courseid and PersonID = @id and CourseStatus = @status");

            int result = 0;
            bool course;
            command.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("courseid", courseid),
                    new SqlParameter("id", id),
                    new SqlParameter("status", 1)
            });

            using (var c = GetConnectionInstance())
            {
                c.Open();
                command.Connection = c;
                result = (int)command.ExecuteScalar();
                if (result > 0)
                {
                    course = true;
                }
                else
                {
                    course = false;
                }
            }

            return course;
        }

        private bool PCourse_Exist(int id, int courseid)
        {
            var command = new SqlCommand("select Count(*) from Person.PersonCourses where CourseID = @courseid and PersonID = @id and CourseStatus = @status");

            int result = 0;
            bool course;
            command.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("courseid", courseid),
                    new SqlParameter("id", id),
                    new SqlParameter("status", Convert.ToInt32(0))
            });

            using (var c = GetConnectionInstance())
            {
                c.Open();
                command.Connection = c;
                result = (int)command.ExecuteScalar();
                if (result > 0)
                {
                    course = true;
                }
                else
                {
                    course = false;
                }
            }

            return course;
        }
        /* public bool CreateStudent(int id)
         {
             var command = new SqlCommand("insert into Person.Student values(@id,@hours,@status);");


             int result = 0;

             using (var c = GetConnectionInstance())
             {
                 c.Open();
                 command.Connection = c;
               result = command.ExecuteNonQuery();

             }
             return result > 0;
         }*/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private SqlConnection GetConnectionInstance()
        {
            return new SqlConnection(_ConnectionString);
        }
    }
}
    



