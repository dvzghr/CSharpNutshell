using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//NEW FEATURE: using static
using static System.Console;

namespace CSharp7_NewFeatures
{
    public class OutVariables
    {
        public void Run()
        {
            //PRE C#7

            //Can not use var declaration for out params
            //var hour, min, sec;
            int hour, min, sec;
            GetTime(out hour, out min, out sec);
            WriteLine($"{hour}:{min}:{sec}");

            //C#7
            GetTime(out int newHour, out int newMin, out var newSec);   //NOTE: using var at 3rd arg
            WriteLine($"{newHour}:{newMin}:{newSec}");

        }


        public void GetTime(out int hour, out int minutes, out int seconds)
        {
            var currDateTime = DateTime.Now;
            hour = currDateTime.Hour;
            minutes = currDateTime.Minute;
            seconds = currDateTime.Second;
        }
    }
}