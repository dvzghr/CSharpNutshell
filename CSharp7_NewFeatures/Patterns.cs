using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp7_NewFeatures
{
    class Patterns
    {
        public void Run()
        {
            PatternMatching(null);
            PatternMatching(1);
            PatternMatching("2");

            PatternMatching(new Tank());
        }

        public void PatternMatching(object o)
        {
            int i;


            //Pre C#7
            if (o == null)
            {
                WriteLine("null");
            }

            //C#7
            if (o is null) // constant pattern
            {
                WriteLine("null");
            }


            //Pre C#7
            if (o is int)
            {
                WriteLine((int) o + 1);
            }

            //C#7
            if (o is int j) //type pattern (int)
            {
                WriteLine(j + 1);
            }


            //Pre C#7
            if (o is string && int.TryParse(o.ToString(), out i))
            {
                WriteLine(i + 2);
            }

            //C#7
            if (o is string s && int.TryParse(s, out int k)) //type pattern (string)
            {
                WriteLine(k + 2);
            }

            //Pre C#7
            if (o is Tank)
            {
                var tankOld = o as Tank;
                if (tankOld.IsReady) tankOld.Fire();
            }

            //C#7
            if (o is Tank tankNew && tankNew.IsReady) tankNew.Fire();
        }
    }

    abstract class Enemy { }

    class Tank : Enemy
    {
        public bool IsReady { get; set; } = true;

        public void Fire()
        {
            WriteLine("BOOM");
        }
    }

    class Trooper : Enemy { }
}