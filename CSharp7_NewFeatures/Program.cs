using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//NEW FEATURE: using static
using static System.Console;

namespace CSharp7_NewFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*** out variables ***");
            new OutVariables().Run();
            WriteLine("---------------------\n");


            ReadKey();
        }
    }
}
