using LinqToObject;
using LinqToSql.Model;
using System;
using System.Data;
using System.Linq;

namespace LinqToSql
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //Presentation Message
            Presentation.Init("Sql");

            // Add our Data Context
            DataClassesDataContext bd = new DataClassesDataContext();

            var query = from s in bd.Students
                        where s.Id == 3
                        select new StudentModel() //Select our Model
                        {
                            Name = s.Name,
                            Lastname = s.Lastname
                        };

            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " " + item.Lastname);
            }
            Console.ReadLine();
        }
    }
}
