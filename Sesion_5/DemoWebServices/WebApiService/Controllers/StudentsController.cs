using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

// New usings
using System.Threading.Tasks;
using WebApiService.Models;
using System.Web.Script.Serialization;

namespace WebApiService.Controllers
{
    public class StudentsController : ApiController
    {
        //Instantance Local Database
        //DBDemoRestEntities db = new DBDemoRestEntities();

        //Instantance Azure Database
        DBDemoApiEntities db = new DBDemoApiEntities();

        //GET --> api/Students
        public List<StudentModel> GetStudents()
        {
            var query = from s in db.Students
                        select new StudentModel()
                        {
                            Name = s.Name,
                            Lastname = s.Lastname,
                            Age = s.Age,
                            Address = s.Address,
                            Phone = s.Phone
                        };

            return query.ToList();
        }
        //GET --> api/Students/{id}
        public StudentModel GetStudents(int id)
        {
            var query = from s in db.Students
                        where s.Id == id
                        select new StudentModel()
                        {
                            Name = s.Name,
                            Lastname = s.Lastname,
                            Age = s.Age,
                            Address = s.Address,
                            Phone = s.Phone
                        };

            return query.FirstOrDefault();
        }

        //POST --> api/Students
        public async Task<bool> PostStudents(HttpRequestMessage request)
        {
            // The ModelState represents a collection of name and value pairs that were submitted 
            // to the server during a POST
            if (ModelState.IsValid)
            {
                //Read pur Json
                var jsonString = await request.Content.ReadAsStringAsync();

                //Instance Serializer 
                var jss = new JavaScriptSerializer();

                //Deserialize our json
                StudentModel student = jss.Deserialize<StudentModel>(jsonString);

                //save the deserialized data in our Model generated with Entity Framework
                var _student = new Student()
                {
                    Name = student.Name,
                    Lastname = student.Lastname,
                    Age = student.Age,
                    Address = student.Address,
                    Phone = student.Phone
                };

                //Add a new element
                db.Students.Add(_student);
                //Save changes of our table
                db.SaveChanges();

                return true;

            }
            else
            {
                return false;
            }

        }

        //PUT --> api/Students/{id}
        public async Task<string> PutStudents(int id, HttpRequestMessage request)
        {

            //Read pur Json
            var jsonString = await request.Content.ReadAsStringAsync();

            //Instance Serializer 
            var jss = new JavaScriptSerializer();

            //Deserialize our json
            StudentModel student = jss.Deserialize<StudentModel>(jsonString);

            var query = from st in db.Students
                        where st.Id == id
                        select st;

            //Iterate and assign a new data for our table
            foreach (Student item in query)
            {
                item.Name = student.Name;
                item.Lastname = student.Lastname;
                item.Age = student.Age;
                item.Address = student.Address;
                item.Phone = student.Phone;
            };

            try
            {
                //Save changes
                db.SaveChanges();
                return "OK";

            }catch(Exception ex)
            {
                return ex.Message;
            }
            
        }

        //Delete --> api/GetStudents/{id}
        public string DeleteStudents(int id)
        {
            try
            {

                var query = from st in db.Students
                             where st.Id == id
                             select st;

                foreach (var item in query)
                {
                    db.Students.Remove(item);
                }

                db.SaveChanges();

                return "OK";

            }catch(Exception ex)
            {
                return ex.Message;
            }
            
            
           
        }

    }
}
