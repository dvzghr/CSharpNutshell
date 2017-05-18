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
}