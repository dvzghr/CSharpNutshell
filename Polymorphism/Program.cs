using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Program
    {
        static void Main(string[] args)
        {
            int x, y;

            Console.WriteLine("\nbaseClass = new BaseClass()\n-------------");
            BaseClass baseClass = new BaseClass(2);
            baseClass.Read();
            baseClass.Write();
            baseClass.WritePrivate();   //Private
            baseClass.WriteVirtual();

            x = baseClass.SimpleNumber;
            y = baseClass.ProtectedNumber;  //Protected


            Console.WriteLine("\nbaseClass = new DerivedClass()\n-------------");
            BaseClass baseDerived = new DerivedClass();
            baseDerived.Read();
            baseDerived.Write();
            baseDerived.WritePrivate();     //Private
            baseDerived.WriteVirtual();
            baseDerived.DerivedMethod();    //Compiler error

            x = baseDerived.SimpleNumber;
            y = baseDerived.ProtectedNumber; //Protected


            Console.WriteLine("\nderivedClass = new DerivedClass()\n-------------");
            DerivedClass derived = new DerivedClass();
            derived.Read();
            derived.Write();
            derived.WritePrivate();     //Private
            derived.WriteVirtual();
            derived.DerivedMethod();

            x = baseDerived.SimpleNumber;
            y = baseDerived.ProtectedNumber; //Protected


            Console.WriteLine("\nibaseClass = new BaseClass()\n-------------");
            IInterface iBaseClass = new BaseClass(3);
            iBaseClass.Read();
            iBaseClass.Write();
            //NoVirtualMethod!!!

            Console.WriteLine("=============");
            Console.WriteLine("*************");


            Console.WriteLine("\nderivedAbstract = new DerivedFromAbstractClass()\n-------------");
            var derivedAbstract = new DerivedFromAbstractClass();


            Console.ReadKey();

            var baseClass2 = new BaseClass(33);
            IInterface interfaceClass = baseClass2;
            var baseClass3 = (BaseClass)interfaceClass;
            Console.WriteLine(baseClass3.SimpleNumber);

        }
    }

    public class BaseClass : IInterface
    {
        public BaseClass(int x)
        {
            SimpleNumber = x;
            ProtectedNumber = x + 1;
            WritePrivate();
        }

        public int SimpleNumber { get; set; }
        protected int ProtectedNumber { get; set; }

        public void Write()
        {
            Console.WriteLine("Write BaseClass");
        }

        public void Read() { }

        private void WritePrivate()
        {
            Console.WriteLine("WritePrivate BaseClass");
        }

        public virtual void WriteVirtual()
        {
            Console.WriteLine("WriteVirtual BaseClass");
        }
    }

    public class DerivedClass : BaseClass
    {
        public DerivedClass() : base(2)
        {
            ProtectedNumber = 100;
            //WritePrivate(); //Base: Private
        }

        public void DerivedMethod()
        {
            Console.WriteLine(ProtectedNumber);
        }

        public int DerivedNumber { get; set; }

        public void Write()
        {
            Console.WriteLine("Write DerivedClass");
        }

        public override void WriteVirtual()
        {
            Console.WriteLine("WriteVirtual DerivedClass");
        }
    }

    interface IInterface
    {
        void Write();
        void Read();
    }

    public abstract class AbstractClass
    {
        private int _broj;
        public int BrojDrugi { get; set; }
        protected int BrojProtected { get; set; }
    }

    public class DerivedFromAbstractClass : AbstractClass
    {
        public DerivedFromAbstractClass()
        {

        }
    }

}
