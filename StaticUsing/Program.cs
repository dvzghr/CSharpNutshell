using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Something;
using static Something.SomeClass;

namespace StaticUsing
{
    class Program
    {
        static void Main(string[] args)
        {
            //var someClass = new SomeClass();
            //someClass.Print();

            Print();
        }
    }
}

namespace Something
{
    class SomeClass
    {
        public static void Print()
        {
            Console.WriteLine("Printing...");
        }
    }
}
