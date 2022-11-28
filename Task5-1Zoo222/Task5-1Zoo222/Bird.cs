using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_1Zoo222
{
    class Bird : Animal
    {
        private String species;
        private double wingSpan;

        public Bird(String name, String diet, String location,
            double weight, int age, String colour, String species, double wingSpan)
            : base(name, diet, location, weight, age, colour)
        {
            this.species = species;
            this.wingSpan = wingSpan;
        }
        public override void sleep()
        {
            Console.WriteLine("A Bird sleep");
        }

        public virtual void fly()
        {
            Console.WriteLine("A bird fly");
        }
        public virtual void layEgg()
        {
            Console.WriteLine("A bird lay egg");
        }
    }
}
