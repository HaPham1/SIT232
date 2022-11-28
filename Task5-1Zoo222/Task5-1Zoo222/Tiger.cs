using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_1Zoo222
{
    class Tiger : Feline
    {
        private String colourStripes;

        public Tiger(String name, String diet, String location, double weight, int age, String colour, String species, String colourStripes)
            : base(name, diet, location, weight, age, colour, species)
        {
            this.colourStripes = colourStripes;
        }

        public override void makeNoise()
        {
            Console.WriteLine("ROARRRRRRRR");
        }

        public override void eat()
        {
            Console.WriteLine("I can eat 20lbs of meat");
        }
        public override void stunt()
        {
            Console.WriteLine("The tiger meow like a cat");
        }
    }
}
