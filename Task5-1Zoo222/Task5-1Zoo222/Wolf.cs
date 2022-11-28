using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_1Zoo222
{
    class Wolf : Animal
    {
        public Wolf(String name, String diet, String location, double weight, int age, String colour)
            : base(name, diet, location, weight, age, colour)
        {
        }

        public override void makeNoise()
        {
            Console.WriteLine("Wolf howls");
        }

        public override void eat()
        {
            Console.WriteLine("I can eat 10lbs of meat");
        }

        public override void stunt()
        {
            Console.WriteLine("The wolf do the puppy eyes");
        }
    }
}
