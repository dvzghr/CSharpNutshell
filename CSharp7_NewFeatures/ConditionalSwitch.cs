using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp7_NewFeatures
{
    class ConditionalSwitch
    {
        public void Run()
        {
            Person boss = new Boss
                          {
                              Age = 50,
                              Exp = 30,
                              NumberManaged = 10,
                              NumberOwned = 50
                          };

            SwitchPersons(boss);
            SwitchPersons(new Person
                          {
                              Age = 1
                          });

            SwitchPersons(new object());
            SwitchPersons(null);
        }

        private void SwitchPersons(Object person)
        {
            switch (person)
            {
                default: //NOTE: Always checked last, irrelevant of position
                    WriteLine();
                    break;

                case Boss b when b.NumberOwned > 10:
                    WriteLine($"NoOwned: {b.NumberOwned} HIGH");
                    break;
                case Boss b when b.NumberOwned <= 10:
                    WriteLine($"NoOwned: {b.NumberOwned} LOW");
                    break;
                case Manager m:
                    WriteLine($"NoManaged: {m.NumberManaged}");
                    break;

                case Person p:
                    WriteLine($"Age: {p.Age}");
                    break;

                case null: //NOTE: if null, this is going to be hit first, irrelevant of position
                    WriteLine();
                    break;
            }
        }
    }

    class Person
    {
        public int Age { get; set; }
        public int Exp { get; set; }
    }

    class Manager : Person
    {
        public int NumberManaged { get; set; }
    }

    class Boss : Manager
    {
        public int NumberOwned { get; set; }
    }
}