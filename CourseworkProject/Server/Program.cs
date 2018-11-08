using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database = CourseworkProject.Backend.Data.Database;

namespace CourseworkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Backend.Init.Start();
            Console.ReadLine();
        }
    }
}
