using System;
using System.Collections.Generic;
using System.Text;

namespace Task3_4
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create array and list to test
            decimal[] TestArray = { 10.0m, 20.0m, 55.6m, 40.5m, 25.30m, 15.80m, 90.00m, 5.00m, 50.00m, 60.00m, 55.4m };
            Account[] accounts = new Account[TestArray.Length];
            List<Account> accountsList = new List<Account>();
            for (int i = 0; i < TestArray.Length; i++)
            {
                accounts[i] = new Account("Ha" + i, TestArray[i]);
                accountsList.Add(accounts[i]);
            }

            //Use the sort 
            AccountsSorter.Sort(accounts, 5);
            AccountsSorter.Sort(accountsList, 5);


            //Print out after sort
            foreach (Account account in accounts)
            {
                Console.Write(account.Balance + "\t");
            }
            Console.WriteLine();


            for (int i = 0; i < accountsList.Count; i++)
            {
                Console.Write(accountsList[i].Balance + "\t");
            }
            Console.WriteLine();



            // Create null and empty array, list to test check
            Console.WriteLine();
            Account[] accountNull = new Account[10];
            AccountsSorter.Sort(accountNull, 5);

            Console.WriteLine();
            List<Account> accountsListNull = new List<Account>();
            AccountsSorter.Sort(accountsListNull, 5);
        }
    }
}
