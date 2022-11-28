using System;
using System.Collections.Generic;
using System.Text;

namespace Task6_1
{
    class Penguin : Bird
    {
        public override void fly()
        {
            Console.WriteLine("Penguins cannot fly");
        }

        public override string ToString()
        {
            return "A penguin named " + base.name;
        }
    }
}
