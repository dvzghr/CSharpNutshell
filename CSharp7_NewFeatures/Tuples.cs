using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp7_NewFeatures
{
    class Tuples
    {
        public void Run()
        {
            var tuple = GetTime();
            WriteLine($"{tuple.Item1}:{tuple.Item2}:{tuple.Item3}");

            var tupleNamed = GetTimeNamed();
            WriteLine($"{tupleNamed.hour}:{tupleNamed.min}:{tupleNamed.sec}");

            //Deconstruction
            (var hour, var min, var sec) = GetTime();
            WriteLine($"{hour}:{min}:{sec}");

            //Deconstruction into existing variables
            int hour2, min2, sec2;
            (hour2, min2, sec2) = GetTime();
            WriteLine($"{hour2}:{min2}:{sec2}");
        }

        //NOTE: nuget pckg System.ValueTuple needed
        public (int, int, int) GetTime()
        {
            var currDateTime = DateTime.Now;
            var hour = currDateTime.Hour;
            var minutes = currDateTime.Minute;
            var seconds = currDateTime.Second;

            return (hour, minutes, seconds);    //tuple literal
        }

        public (int hour, int min, int sec) GetTimeNamed()
        {
            var currDateTime = DateTime.Now;
            var hour = currDateTime.Hour;
            var minutes = currDateTime.Minute;
            var seconds = currDateTime.Second;

            return (hour, minutes, seconds);
        }
    }
}