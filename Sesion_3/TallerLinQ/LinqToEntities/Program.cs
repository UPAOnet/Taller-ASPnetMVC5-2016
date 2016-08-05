using LinqToEntities.Model; // Add our Model
using LinqToObject;
using System;
using System.Linq; // Add Linq

namespace LinqToEntities
{
    class Program
    {
        static void Main(string[] args)
        {
            //Presentation Message
            Presentation.Init("Entities");

            // Add  DataContext for obtain data of our Database
            DemoEntities bd = new DemoEntities();

            // Use query and set in your Model 
            var query = from s in bd.Students
                        select new StudentModel()
                        {
                            Name = s.Name,
                            Lastname = s.Lastname                           
                        };

            // Iteration and get our data 

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item.Name + " " + item.Lastname);
            //}
            //Console.ReadLine();


            //We use lambda expressions and select all your data
            var lista = query.Select(s => s.Name);

            // Iteration and get data 

            foreach (var item in lista)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
    }
}
