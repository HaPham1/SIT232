using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_1Zoo222
{
    class Animal
    {
        private String name;
        private String diet;
        private String location;
        private double weight;
        private int age;
        private String colour;

        public Animal(String name, String diet, String location, double weight, int age, String colour)
        {
            this.name = name;
            this.diet = diet;
            this.location = location;
            this.weight = weight;
            this.age = age;
            this.colour = colour;
        }
        public virtual void eat()
        {
            Console.WriteLine("An animal eats");
        }

        public virtual void sleep()
        {
            Console.WriteLine("An animal sleep");
        }

        public virtual void makeNoise()
        {
            Console.WriteLine("An animal makes a noise");
        }

        public virtual void stunt()
        {
            Console.WriteLine("An animal did some trick");
        }
    }
}
