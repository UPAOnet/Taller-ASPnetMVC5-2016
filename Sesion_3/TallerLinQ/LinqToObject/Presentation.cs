using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject
{
    public class Presentation
    {
        public static void Init(string type)
        {
            string Message =  "//////////////////////////\n"
                             + "//////////////////////////\n"
                             + "//\tUPAO.net \t//\n"
                             + "//////////////////////////\n"
                             + "//////////////////////////\n\n"
                             + "Example with Linq to "+type+": \n"
                             + "\nPress Enter!\n";
            Console.WriteLine(Message);
            Console.ReadLine();
        }
    }
}
