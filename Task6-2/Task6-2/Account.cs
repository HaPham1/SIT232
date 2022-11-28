using System;
using System.Collections.Generic;
using System.Text;

namespace Task6_2
{
    class Account
    {
        //Variables
        private String _name;
        private decimal _balance;


        public Account(String name, decimal balance)
        {
            _name = name;
            _balance = balance;
        }


        public String Name
        {
            get { return _name; }
        }

        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }


        //Mutator methods
        public bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine(amount.ToString("C") + " added to the account");
                return true;
            }
            else
            {
                Console.WriteLine("Can't deposit a non-positive amount");
                return false;
            }
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= _balance)
            {
                _balance -= amount;
                Console.WriteLine(amount.ToString("C") + " removed the account");
                return true;
            }
            else
            {
                Console.WriteLine("Error! Your account don't have sufficient balance");
                return false;
            }

        }

        //Methods
        public void Print()
        {
            Console.WriteLine("The account named " + Name + " have a balance of " + _balance.ToString("C"));
        }

    }
}
