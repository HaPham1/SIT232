using System;

namespace Task4_1
{

    class Account
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Balance { get; private set; }

        public Account(string firstName, string lastName, int balance)
        {
            if (balance < 0)
            {
                throw new System.ArgumentOutOfRangeException("Account() parameter 'balance' can't be negative");
            }
            if (firstName is null || firstName.Length == 0 || lastName is null || lastName.Length == 0)
            {
                throw new System.ArgumentException("Account() parameter 'firstName' and 'lastName' must be a valid string.");
            }
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public void Withdraw(int amount)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient fund");
            }
            Balance = Balance - amount;
            Console.WriteLine("Operation successful");
        }

        public void check(int[] value)
        {
            if(value == null)
            {
                throw new NullReferenceException("Can't assign a null value");
            }
        }

        public static void Recursive(int value)
        {
            if (value > 1000)
            {
                throw new StackOverflowException("Possible StackOverflow");
            }
            Console.WriteLine(value);
            Recursive(++value);
        }


    }

    class Program
    {
        public static void Main()
        {
            try
            {
                Account account = new Account("Sergey", "P", 100);
                account.Withdraw(1000);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine("The following error detected: " + exception.GetType().ToString() + " with message \"" + exception.Message + "\"");
            }

            Console.ReadKey();

            try
            {
                Account account2 = new Account("Sergey", "P", 100);
                int[] values = null;
                account2.check(values);
                account2.Withdraw(values[0]);
            }
            catch (NullReferenceException exception1)
            {
                Console.WriteLine("The following error detected: " + exception1.GetType().ToString() + " with message \"" + exception1.Message + "\"");
            }

            Console.ReadKey();


            try
            {
                Account.Recursive(0);
            }
            catch (StackOverflowException exception2)
            {
                Console.WriteLine("The following error detected: " + exception2.GetType().ToString() + " with message \"" + exception2.Message + "\"");
            }

            Console.ReadKey();


            try
            {
                string value = new string('a', int.MaxValue);
            }
            catch (OutOfMemoryException exception3)
            {
                Console.WriteLine("The following error detected: " + exception3.GetType().ToString() + " with message \"" + "This String is too large" + "\"");
            }

            Console.ReadKey();


            try
            {
                int test = 1;
                int test1 = 0;
                int test2 = test / test1;
            }
            catch (DivideByZeroException exception4)
            {
                Console.WriteLine("The following error detected: " + exception4.GetType().ToString() + " with message \"" + exception4.Message + "\"");
            }
            Console.ReadKey();

            try
            {
                Account account = new Account("", null, 100);
            }
            catch (ArgumentException exception5)
            {
                Console.WriteLine("The following error detected: " + exception5.GetType().ToString() + " with message \"" + exception5.Message + "\"");
            }
            Console.ReadKey();


            try
            {
                Account account = new Account("a", "b", -5);
            }
            catch (ArgumentOutOfRangeException exception6)
            {
                Console.WriteLine("The following error detected: " + exception6.GetType().ToString() + " with message \"" + exception6.Message + "\"");
            }


            Console.ReadKey();
        }
    }
}
