using System;
using System.Collections.Generic;
using System.Text;

namespace Task6_1
{
    class Bird
    {
        public String name { get; set; }

        public Bird()
        {

        }

        public virtual void fly()
        {
            Console.WriteLine("Flap, Flap, Flap");
        }

        public override string ToString()
        {
            return "A bird called " + name;
        }


    }
}
