using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_2
{
    class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;

        public WithdrawTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
            _executed = false;
            _success = false;
            _reversed = false;
        }
        public void Print()
        {
            if (_reversed)
            {
                Console.WriteLine("Rolling back....");
                Console.WriteLine(_amount.ToString("C") + " Returned");

            }
            else if (_success)
            {
                Console.WriteLine("Transaction succeed!");
                Console.WriteLine(_amount.ToString("C") + " Withdrawed");
            }
            else
            {
                Console.WriteLine("Transaction failed!");
            }
        }

        public void Execute()
        {
            if (_executed)
            {
                throw new InvalidOperationException("Transaction already made.");
            }
            if( _amount > _account.Balance)
            {
                throw new InvalidOperationException("Insufficient balance.");
            }
            else
            {
                _account.Balance -= _amount;
                _success = true;
                _executed = true;
            }
        }

        public void Rollback()
        {
            if (_reversed)
            {
                throw new InvalidOperationException("Already Rolled back");
            }
            else if (!_success)
            {
                throw new InvalidOperationException("Transaction not finalized");
            }
            if (_success && !_reversed)
            {
                _account.Balance += _amount;
                _reversed = true;
            }
        }

        public bool Executed
        {
            get { return _executed; }
        }

        public bool Success
        {
            get { return _success; }
        }

        public bool Reserved
        {
            get { return _reversed; }
        }
    }
}
