using System;
using System.Collections.Generic;
using System.Text;

namespace Task6_2
{
    class DepositTransaction : Transaction
    {
        //Variables
        private Account _account;
        private Boolean _executed = false;
        private Boolean _reversed = false;

        //Constructor
        public DepositTransaction(Account account, decimal amount) : base(amount)
        {
            _account = account;
            _amount = amount;
        }

        //Print method
        override public void Print()
        {
            if (_reversed)
            {
                Console.WriteLine("Rolling back....");
                Console.WriteLine(_amount.ToString("C") + " Removed from account " + _account.Name);

            }
            else if (_success)
            {
                Console.WriteLine("Transaction succeed!");
                Console.WriteLine(_amount.ToString("C") + " Deposited to account " + _account.Name);
            }
            else
            {
                Console.WriteLine("Transaction failed!");
            }
        }

        //methods
        public override void Execute()
        {
            base.Execute();
            if (_executed)
            {
                throw new InvalidOperationException("Transaction already made.");
            }
            if (_amount <= 0)
            {
                throw new InvalidOperationException("Please deposit a positive number.");
            }
            else
            {
                _account.Balance += _amount;
                _success = true;
                _executed = true;
            }
        }

        public override void Rollback()
        {
            if (_reversed)
            {
                throw new InvalidOperationException("Already Rolled back");
            }
            if (!_success)
            {
                throw new InvalidOperationException("Transaction not finalized. Can't roll back.");
            }
            if (_account.Balance < _amount)
            {
                throw new InvalidOperationException("Insufficient balance to reverse");
            }
            if (_success && !_reversed)
            {
                base.Rollback();
                _account.Balance -= _amount;
                _reversed = true;
            }
        }

        public bool Executed
        {
            get { return _executed; }
        }

        override public bool Success
        {
            get { return this._success; }
        }

        public bool Reserved
        {
            get { return _reversed; }
        }
    }
}
