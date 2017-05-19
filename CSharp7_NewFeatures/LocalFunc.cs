using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp7_NewFeatures
{
    class LocalFunc
    {
        public void Run()
        {
            WriteLine($"Sum square: {SumSquare(3)}");


            // 1,1,2,3,5,8,13
            WriteLine($"Fib 0: {Fibonnacci(0)}");
            WriteLine($"Fib 1: {Fibonnacci(1)}");
            WriteLine($"Fib 6: {Fibonnacci(6)}");
        }

        public int SumSquare(int number)
        {
            var sum = 0;
            for (int i = 0; i < number; i++)
            {
                sum += Square(i);
            }

            int Square(int x)
            {
                return x * x;
            }

            return sum;
        }

        public int Fibonnacci(int x)
        {
            if (x < 0) throw new ArgumentException("Must be at least 0");

            return Fib(x).curr;

            //local function
            (int curr, int prev) Fib(int i)
            {
                if (i == 0) return (1, 0);

                var (curr, prev) = Fib(i - 1);
                return (curr + prev, curr);
            }
        }
    }
}