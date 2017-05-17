using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DelegateFactories
{
    public class Program
    {
        static void Main(string[] args)
        {
            IVehicle vehicle;
            Test test;

            //Instantiate vehicle in test class directly
            test = new Test();
            test.Vehicle = new Car { Name = "property" };
            test.UseVehicleProperty();


            //Instantiate through factory delegate
            Test.CreateVehicle = () => new Car { Name = "lambda" };
            test = new Test();
            test.UseVehicleFactory();


            Test.CreateVehicle = CreateCar;
            test.UseVehicleFactory();

            Console.ReadKey();


            //Classic delegate usage
            var x = new CreateCarDelegate(CreateCar);
            x += CreateCar;
            var carX = x();
        }

        public static Car CreateCar()
        {
            return new Car { Name = "method" };
        }
    }

    public delegate Car CreateCarDelegate();

    public interface IVehicle
    {
        void Drive();
    }

    public class Car : IVehicle
    {
        public string Name { get; set; }

        public void Drive()
        {
            Console.WriteLine($"I am driving....{Name}");
        }
    }

    public class Test
    {
        public IVehicle Vehicle { get; set; }
        public static Func<IVehicle> CreateVehicle { get; set; }

        public void UseVehicleFactory()
        {
            Vehicle = CreateVehicle();
            Vehicle.Drive();
        }

        public void UseVehicleProperty()
        {
            Vehicle.Drive();
        }
    }
}