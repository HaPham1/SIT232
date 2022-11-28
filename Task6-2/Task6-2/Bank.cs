using System;
using System.Collections.Generic;
using System.Text;

namespace Task6_2
{
    class Bank
    {
        //list
        private List<Account> _accounts;
        private List<Transaction> _transactions;

        public Bank()
        {
            _accounts = new List<Account>();
            _transactions = new List<Transaction>();
        }

        //Add account to list
        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        //search and return
        public Account GetAccount(String name)
        {
            foreach (Account account in _accounts)
            {
                if(account.Name == name)
                {
                    return account;
                }
            }
            return null;
        }


        //Execute transaction method
        public void ExecuteTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            transaction.Execute();
        }

        public void RollbackTransaction(Transaction transaction)
        {
            transaction.Rollback();
            _transactions.Remove(transaction);
        }

        public void PrintTransactionHistory()
        {
            Console.WriteLine("List of Transaction");
            for(int i = 0; i < _transactions.Count; i++)
            {
                Console.Write(i + 1 + ": ");
                _transactions[i].Print();
                Console.WriteLine(_transactions[i].DateStamp);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //property to access the list of account.
        public List<Account> List
        {
            get { return _accounts; } 
        }

        //property to access list of transactions
        public List<Transaction> TranList
        {
            get { return _transactions;  }
        }
    }
}
