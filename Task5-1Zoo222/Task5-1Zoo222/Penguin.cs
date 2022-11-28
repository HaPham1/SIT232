using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_1Zoo222
{
    class Penguin : Bird
    {
        public Penguin(String name, String diet, String location, double weight, int age, String colour, String species, double wingSpan)
            : base(name, diet, location, weight, age, colour, species, wingSpan)
        {
        }
        public override void fly()
        {
            Console.WriteLine("Penguin can't fly!");
        }

        public override void layEgg()
        {
            Console.WriteLine("Penguin lay an egg");
        }
    }
}
