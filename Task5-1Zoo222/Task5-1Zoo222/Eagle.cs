using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_1Zoo222
{
    class Eagle : Bird
    {
        public Eagle(String name, String diet, String location, double weight, int age, String colour, String species, double wingSpan)
            : base(name, diet, location, weight, age, colour, species, wingSpan)
        {
        }

        public override void layEgg()
        {
            Console.WriteLine("Eagle lay an egg");
        }

        public override void fly()
        {
            Console.WriteLine("Eagle take to the sky!");
        }

        public override void makeNoise()
        {
            Console.WriteLine("Eagle Wwhistles");
        }

        public override void eat()
        {
            Console.WriteLine("I can eat 1lb of fish");
        }

        public override void stunt()
        {
            Console.WriteLine("The eagle do a flight show");
        }
    }
}
