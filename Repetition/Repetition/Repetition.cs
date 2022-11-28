using System;

namespace Repetition
{
    class Repetition
    {
        static void Main(string[] args)
        {
            //Create sum, average and upperbound
            int sum = 0;
            double average;
            int upperbound = 100;

            //Loop through and add the number between 0 and upperbound to the sum
            int number = 1;
            do
            {
                sum += number;
                number++;
                Console.WriteLine("Current number: " + number + " the sum is " + sum);
            } while (number <= 100);

            // Cast sum to type double to calculate correct average
            double dsum = (double) sum;
            average = dsum / upperbound;

            //Print out result
            Console.WriteLine("The sum is " + sum);
            Console.WriteLine("The average is " + average);
        }
    }
}


/*  for (int number = 1; number <= upperbound; number++)
    {
       sum += number;
       Console.WriteLine("Current number: " + number + " the sum is " + sum);
    }
           

            int number = 1;
            while (number <= upperbound)
            {
                sum += number;
                number++;
                Console.WriteLine("Current number: " + number + " the sum is " + sum);
            }



            int number = 1;
            do
            {
                sum += number;
                number++;
                Console.WriteLine("Current number: " + number + " the sum is " + sum);
            } while (number <= 100);

*/


