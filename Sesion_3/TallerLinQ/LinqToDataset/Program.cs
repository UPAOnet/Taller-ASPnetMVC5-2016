using LinqToDataset.Model; // Add our Model
using LinqToObject;
using System;
using System.Data;
using System.Data.SqlClient; // Add SqlClient and obtain all your data
using System.Linq; // Add Linq

namespace LinqToSql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Presentation Message
            Presentation.Init("DataSet");

            //Connection Database
            string connectString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //Query from Database
            string sqlSelect = "SELECT * FROM Student;";

            // Create the data adapter to retrieve data from the database
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, connectString);

            // Create table mappings
            da.TableMappings.Add("Table", "Student");

            // A DataSet represents a complete set of data including the tables that contain,
            // order, and constrain the data, as well as the relationships 
            DataSet ds = new DataSet();

            //The Fill method retrieves the data from the data source using a SELECT statement
            da.Fill(ds);

            //You can think of it as having columns and rows in the same way
            DataTable Store = ds.Tables["Student"];

            // Example LINQ
            var query = from p in Store.AsEnumerable()
                        where p.Field<int>("Id") >0
                        select new StudentModel()
                        {
                            Name = p.Field<string>("Name"),
                            Lastname = p.Field<string>("Lastname")

                        };

            // Foreach or Iteration of your query with our data
            foreach (var q in query)
            {
                Console.WriteLine($"{q.Name} {q.Lastname}");
            }

            Console.ReadLine();

        }
    }
}
