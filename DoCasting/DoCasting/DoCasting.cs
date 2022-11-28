using System;

namespace DoCasting
{
    class DoCasting
    {
        static void Main(string[] args)
        {
            // Create sum and count integer
            int sum = 17;
            int count = 5;

            //create, calculate and print out intAverage
            int intAverage;
            intAverage = sum / count;
            Console.WriteLine(intAverage);

            //create, calculate and print out doubleAverage 
            double doubleAverage;
            doubleAverage = sum / count;
            Console.WriteLine(doubleAverage);

            //casting sum to double and calculate the new result
            double dsum = (double) sum;
            Console.WriteLine(dsum / count);
        }
    }
}
