using System;

namespace Task5_1OVerload
{
    class Overloading
    {
        static void Main(string[] args)
        {
            methodToBeOverloaded("Ha");
            methodToBeOverloaded("Ha", 18);
        }
        public static void methodToBeOverloaded(String name)
        {
            Console.WriteLine("Name: " + name);
        }

        public static void methodToBeOverloaded(String name, int age)
        {
            Console.WriteLine("Name: " + name + "\nAge: " + age);
        }
    }
}
