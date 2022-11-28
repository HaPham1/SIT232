using System;

namespace GuessingNumber
{
    class GuessingNumber
    {
        static void Main(string[] args)
        {
            try
            {
                // Prompt for first user input
                Console.WriteLine("Please enter a secret number between 1 and 10: ");
                int number = Convert.ToInt32(Console.ReadLine());

                //Making sure that the input is between 1 and 10
                while (number < 1 || number > 10)
                {
                    Console.WriteLine("Please enter a secret number between 1 and 10: ");
                    number = Convert.ToInt32(Console.ReadLine());
                }

                //Prompt for second user input as guesses
                Console.WriteLine("Please guess a number between 1 and 10: ");
                int guess = Convert.ToInt32(Console.ReadLine());

                //Make sure the guess also stay between 1 and 10
                while (guess < 1 || guess > 10)
                {
                    Console.WriteLine("The number is only between 1 and 10, try again!");
                    guess = Convert.ToInt32(Console.ReadLine());
                }

                // If guess right, prompt the message
                if (guess == number)
                {
                    Console.WriteLine("You have guessed the number! Well done!");
                }

                // If guess wrong, ask for input again
                else
                {
                    do
                    {
                        Console.WriteLine("Please enter a number between 1 and 10: ");
                        guess = Convert.ToInt32(Console.ReadLine());
                        while (guess < 1 || guess > 10)
                        {
                            Console.WriteLine("The number is only between 1 and 10, try again!");
                            guess = Convert.ToInt32(Console.ReadLine());
                        }
                    } while (guess != number);
                    // Prompt message after finally correct
                    Console.WriteLine("You have guessed the number! Well done!");
                }
            }
            // Error out when user try to enter character or no input at all
            catch (Exception)
            {
                Console.WriteLine("Error! Need to enter a number");
            }
        }
    }
}
