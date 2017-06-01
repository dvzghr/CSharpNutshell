using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Int32;

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
            int[] numbers = {2, 7, 1, 9, 12, 8, 15};
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
            catch
            {
            }

            //C#7
            try
            {
                WriteLine(name ?? throw new NullReferenceException("new way"));
            }
            catch
            {
            }


            //Expression methods
            ConvertStringToInt();
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

        void ConvertStringToInt()
        {
            var someString = "11";
            int someNumberFromString = 0;

            someNumberFromString = someString.ToIntFromString();
            someNumberFromString = someString.ToIntWithDelegate();
            someNumberFromString = someString.ToIntWithDelegateGeneric();

            someNumberFromString = someString.ToIntWithDelegateGenericFinal();
            someNumberFromString = someString.ToIntWithDelegateGenericFinal();
        }
    }

    static class StringExtension
    {
        public static int ToIntFromString(this string str)
        {
            return TryParse(str, out int number) ? number : 0;
        }
    }

    static class DelegateExtension
    {
        private delegate bool TryParseDelegate(string s, out int i);

        private static int ToInt(string s, TryParseDelegate func) => func(s, out int i) ? i : 0;

        public static int ToIntWithDelegate(this string str) => ToInt(str, int.TryParse);
    }

    static class GenericExtension
    {
        private delegate bool TryParseDelegate<T>(string s, out T i);

        private static int ToInt(string s, TryParseDelegate<int> func) => func(s, out int i) ? i : 0;
        private static DateTime ToDate(string s, TryParseDelegate<DateTime> func) => func(s, out DateTime dt) ? dt : DateTime.Now;

        public static int ToIntWithDelegateGeneric(this string str) => ToInt(str, int.TryParse);

        public static DateTime ToDateWithDelegateGeneric(this string str) => ToDate(str, DateTime.TryParse);
    }

    static class GenericExtensionFinal
    {
        private delegate bool TryParseDelegate<T>(string s, out T i);
        private static T To<T>(string s, TryParseDelegate<T> func) => func(s, out T i) ? i : default(T);


        public static int ToIntWithDelegateGenericFinal(this string str) => To<int>(str, int.TryParse);

        public static DateTime ToDateWithDelegateGenericFinal(this string str) => To<DateTime>(str, DateTime.TryParse);
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