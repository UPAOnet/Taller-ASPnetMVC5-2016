using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using WcfService.Models;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //Instantance Database
        DBDemoEntities db = new DBDemoEntities();
        public string CreateEmployee(Stream JsonStream)
        {
            try
            {
                //initialise a new instance of the StreamReader class for the specified stream
                StreamReader reader = new StreamReader(JsonStream);
                              
                //Read Contennt json
                string json = reader.ReadToEnd();
                
                //initialise Serializer of JSON
                JavaScriptSerializer jss = new JavaScriptSerializer();
                
                //Deserializaer json and save in our Model
                EmployeeModel employee = jss.Deserialize<EmployeeModel>(json);

                //Save our serialized data to Model Mapping of our database
                var emp = new Employee
                {
                    Name = employee.Name,
                    Lastname = employee.Lastname,
                    Age = employee.Age,
                    Address = employee.Address,
                    Phone = employee.Phone
                };

                //Add a data entity emp
                db.Employees.Add(emp);

                //Save Changes to our database
                db.SaveChanges();

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public EmployeeModel FindEmployee(string id)
        {
            // Use  Linq for database, Use "where" for an id existing and get data

            var query = from e in db.Employees
                            where e.Id.ToString().Equals(id)
                            select new EmployeeModel()
                            {
                                Name = e.Name,
                                Lastname = e.Lastname,
                                Age = e.Age,
                                Address = e.Address,
                                Phone = e.Phone
                            };

                return query.FirstOrDefault();
        }

        public List<EmployeeModel> ListEmployees()
        {
            // Use  Linq for database, save the data in our Models and get data

            var query = from e in db.Employees
                        select new EmployeeModel()
                        {
                            Name = e.Name,
                            Lastname = e.Lastname,
                            Age = e.Age,
                            Address = e.Address,
                            Phone = e.Phone
                        };
            return query.ToList();
        }
    }
}
