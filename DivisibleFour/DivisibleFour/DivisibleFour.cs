using System;

namespace DivisibleFour
{
    class DivisibleFour
    {
        static void Main(string[] args)
        {
            try
            {
                //Prompt for user input
                Console.WriteLine("Please enter a number: ");
                int n = Convert.ToInt32(Console.ReadLine());

                // Want it to be larger than 1
                while (n <= 1)
                {
                    Console.WriteLine("Make it larger than 1 at least: ");
                    n = Convert.ToInt32(Console.ReadLine());
                }

                // Print only the numbers that is divisible by 4 and not by 5
                for (int i = 1; i < n; i++)
                {
                    if (i % 4 == 0)
                    {
                        if (!(i % 5 == 0))
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
            }

            // Handle error in case no input or not integer
            catch (Exception)
            {
                Console.WriteLine("Error! Not an integer");
            }
        }
    }
}
