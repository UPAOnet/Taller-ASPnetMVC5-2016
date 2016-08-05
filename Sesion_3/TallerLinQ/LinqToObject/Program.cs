using LinqToObject.Model; //Add our Model
using System;
using System.Collections.Generic; //Add Collections
using System.Linq; // Add Linq

namespace LinqToObject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ////Presentation Message
            Presentation.Init("Object");

            //Method
            ListStudents();
        }

        public static void ListStudents()
        {
            //IENumerable and Array

            IEnumerable<Student> students1 = new Student[]
            {
               new Student { Id = 1, Name = "Nelson", Lastname = "Valverde La Torre", Age = 24, College = "Sistemas" },
               new Student {  Id = 2, Name = "Yordi", Lastname = "Agustin Paredes", Age = 18, College = "Sistemas" },
               new Student {  Id = 3, Name = "Javier", Lastname = "Escobar Espinoza", Age = 19, College = "Sistemas" }
            };

            //IEnumerable and List Students
            IEnumerable<Student> students2 = new List<Student>()
            {
               new Student { Id = 1, Name = "Nelson", Lastname = "Valverde La Torre", Age = 24, College = "Sistemas" },
               new Student {  Id = 2, Name = "Yordi", Lastname = "Agustin Paredes", Age = 18, College = "Sistemas" },
               new Student {  Id = 3, Name = "Javier", Lastname = "Escobar Espinoza", Age = 19, College = "Sistemas" }
            };


            // List and List
            List<Student> students3 = new List<Student>()
           {
               new Student { Id = 1, Name = "Nelson", Lastname = "Valverde La Torre", Age = 24, College = "Sistemas" },
               new Student {  Id = 2, Name = "Yordi", Lastname = "Agustin Paredes", Age = 18, College = "Sistemas" },
               new Student {  Id = 3, Name = "Javier", Lastname = "Escobar Espinoza", Age = 19, College = "Sistemas" }
           };


            //Lambda Expressions in foreach and where with a condition
            foreach (var item in students1.Where(l=>l.Id > 0))
            {
                Console.WriteLine($"{item.Name} {item.Lastname}");
            }

            Console.ReadLine();
           
        }
    }
}