using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAndContraVariance
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            Animal animalCat = new Cat();

            Cat cat = new Cat();
            Cat catAnimal = new Animal();   //Compiler error

            //=====================================

            IEnumerable<Animal> animals = new List<Cat>();  //COVARIANCE
            IEnumerable<Cat> cats = new List<Animal>();     //Compiler error

            //=====================================

            IGenericInVariant<Animal> animalInVariant = new HandleCatsInVariant();  //Compiler error
            IGenericCovariant<Animal> animalCovariant = new HandleCatsCovariant();  //COVARIANCE
            IGenericContravariant<Animal> animalContravariant = new HandleCatsContravariant();  //Compiler error

            IGenericInVariant<Cat> catInVariant = new HandleAnimalsInVariant();     //Compiler error
            IGenericInVariant<Cat> catCovariant = new HandleAnimalsCovariant();     //Compiler error
            IGenericContravariant<Cat> catContravariant = new HandleAnimalsContravariant();  //CONTRAVARIANCE

        }
    }

    interface IGenericInVariant<T>
    {
        T GetAnimal();
    }

    interface IGenericCovariant<out T>
    {
        T GetAnimal();
    }

    interface IGenericContravariant<in T>
    {
        void TakeAnimal(T animal);
    }

    public class Animal { }

    public class Cat : Animal { }

    public class HandleAnimalsCovariant : IGenericCovariant<Animal>
    {
        public Animal GetAnimal()
        {
            return new Animal();
        }
    }

    public class HandleCatsCovariant : IGenericCovariant<Cat>
    {
        public Cat GetAnimal()
        {
            return new Cat();
        }
    }
    
    public class HandleAnimalsInVariant : IGenericInVariant<Animal>
    {
        public Animal GetAnimal()
        {
            return new Animal();
        }
    }

    public class HandleCatsInVariant : IGenericInVariant<Cat>
    {
        public Cat GetAnimal()
        {
            return new Cat();
        }
    }

    public class HandleAnimalsContravariant : IGenericContravariant<Animal>
    {
        public void TakeAnimal(Animal animal)
        {
        }
    }

    public class HandleCatsContravariant : IGenericContravariant<Cat>
    {
        public void TakeAnimal(Cat animal)
        {
        }
    }
}