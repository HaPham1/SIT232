using System;
using System.Collections.Generic;
using System.Text;

namespace Task6_1
{
    class Duck : Bird
    {
        public double size { get; set; }
        public String kind { get; set; }

        public override string ToString()
        {
            return "A duck named " + base.name + " is a " + size + " inch " + kind;
        }

    }
}
