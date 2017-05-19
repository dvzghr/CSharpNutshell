using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp7_NewFeatures
{
    class Enhancements
    {
        public void Run()
        {
            //literals
            var bigNumber = 1_234_567;
            WriteLine(bigNumber);

            //return by reference
            int[] numbers = { 2, 7, 1, 9, 12, 8, 15 };
            ref int position = ref Substitute(12, numbers);
            position = -12;
            WriteLine(numbers[4]);

            //Throwing ex as an expr
            string name = null;

            //Pre C#7
            try
            {
                if (name == null)
                    throw new NullReferenceException("Old way");
                WriteLine(name);
            }
            catch { }

            //C#7
            try
            {
                WriteLine(name ?? throw new NullReferenceException("new way"));
            }
            catch { }
        }

        public ref int Substitute(int value, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == value)
                    return ref numbers[i];
            }

            throw new IndexOutOfRangeException("Not found!");
        }
    }

    class Car
    {
        //Expression constructor
        public Car() => Name = "default";

        private string name;

        //Expression body
        public string Name
        {
            get => name;
            set => name = value;
        }
    }
}