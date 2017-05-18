using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            WriteLine("*** patterns ***");
            new Patterns().Run();
            WriteLine("---------------------\n");

            WriteLine("*** conditional switch ***");
            new ConditionalSwitch().Run();
            WriteLine("---------------------\n");

            WriteLine("*** tuples ***");
            new Tuples().Run();
            WriteLine("---------------------\n");

            WriteLine("*** local func ***");
            new LocalFunc().Run();
            WriteLine("---------------------\n");

            WriteLine("*** enhancements ***");
            new Enhancements().Run();
            WriteLine("---------------------\n");

            ReadKey();
        }
    }
}
