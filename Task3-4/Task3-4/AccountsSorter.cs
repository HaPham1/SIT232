using System;
using System.Collections.Generic;
using System.Text;

namespace Task3_4
{
    static class AccountsSorter
    {
        /*function BucketSort(b, array)
            {
                buckets ← new array of b empty lists
                M ← the maximum key value in the array
                for i = 1 to length(array) do
                    insert array[i] into buckets[floor(b × array[i] / M)]
                for i = 1 to b do
                    nextSort(buckets[i])
                return the concatenation of buckets[1], ...., buckets[b]
                } pseudocode*/

        /*Sorts the specified one‐dimensional array of accounts in the ascending order of their balances.Each element of
        the accounts array is an instance of the class Account. */
        public static void Sort(Account[] accounts, int b)
        {
            //check the array
            if (Check(accounts))
            {
                //Create new empty buckets based on the number we want
                List<Account>[] buckets = new List<Account>[b];
                for (int i = 0; i < b; i++)
                {
                    buckets[i] = new List<Account>();
                }

                //Get the maximum key value in the array
                Decimal M = 0;
                for (int i = 0; i < accounts.Length; i++)
                {
                    if (M < accounts[i].Balance)
                    {
                        M = accounts[i].Balance;
                    }
                }

                // Get the bucket number and put in.
                for (int i = 0; i < accounts.Length; i++)
                {
                    int choice = (int)Math.Floor((b - 1) * accounts[i].Balance / M);
                    buckets[choice].Add(accounts[i]);
                }

                // Create new empty list to add in after sort
                List<Account> NewList = new List<Account>();
                for (int i = 0; i < b; i++)
                {
                    Account[] New = InsertionSort(buckets[i]);
                    NewList.AddRange(New);
                }
                
                //Change new list to array
                Account[] NewAccounts = NewList.ToArray();


                // Change the value in the original array with sorted values
                for (int i = 0; i < accounts.Length; i++)
                {
                    accounts[i] = NewAccounts[i];
                    accounts[i] = NewAccounts[i];
                }
            }
            else
            {
                Console.WriteLine("Error! Please don't pass in NULL value or empty array");
            }
        }

        /* Sorts the specified collection of accounts in the ascending order of their balances.Each element of the accounts
        array is an instance of the class Account. */

        //Almost the same as above
        public static void Sort(List<Account> accounts, int b)
        {
            if (Check(accounts))
            {
                List<Account>[] buckets = new List<Account>[b];
                for (int i = 0; i < b; i++)
                {
                    buckets[i] = new List<Account>();
                }


                Decimal M = 0;
                for (int i = 0; i < accounts.Count; i++)
                {
                    if (M < accounts[i].Balance)
                    {
                        M = accounts[i].Balance;
                    }
                }

                for (int i = 0; i < accounts.Count; i++)
                {
                    int choice = (int)Math.Floor((b - 1) * accounts[i].Balance / M);
                    buckets[choice].Add(accounts[i]);
                }

                List<Account> NewList = new List<Account>();
                for (int i = 0; i < b; i++)
                {
                    Account[] New = InsertionSort(buckets[i]);
                    NewList.AddRange(New);
                }

                for (int i = 0; i < accounts.Count; i++)
                {
                    accounts[i] = NewList[i];
                }
            }
            else
            {
                Console.WriteLine("Error! Please don't pass in NULL value or empty list");
            }
        }

        /*implement the required nextSort function of the pseudocode either by calling the
        respective version of the Sort method from the above list or by delegating this task to a respective native
        method of the .NET Framework, e.g.the Array.Sort or the List<T>.Sort. */

        //Simple insertion sort modified to work with list and return array
        static Account[] InsertionSort(List<Account> bucket)
        {
            for (int i = 0; i < bucket.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (bucket[j-1].Balance > bucket[j].Balance)
                    {
                        Account temp = bucket[j - 1];
                        bucket[j - 1] = bucket[j];
                        bucket[j] = temp;
                    }
                }
            }
            return bucket.ToArray();
        }
        ////Check if the array passed in is null or empty
        public static bool Check (Account[] accounts)
        {
            bool state = true;
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i] == null)
                {
                    state = false;
                }
            }
            if (accounts.Length == 0)
            {
                state = false;
            }
            return state;
        }

        //////Check if the list passed in is null or empty
        public static bool Check(List<Account> accounts)
        {
            bool state = true;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i] == null)
                {
                    state = false;
                }
            }
            if (accounts.Count == 0)
            {
                state = false;
            }
            return state;
        }
    }
}
