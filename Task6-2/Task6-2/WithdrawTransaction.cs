using System;
using System.Collections.Generic;
using System.Text;

namespace Task6_2
{
    class WithdrawTransaction : Transaction
    {
        private Account _account;
        private Boolean _executed = false;
        private Boolean _reversed = false;

        public WithdrawTransaction(Account account, decimal amount) : base(amount)
        {
            _account = account;
            _amount = amount;
        }
        public override void Print()
        {
            if (_reversed)
            {
                Console.WriteLine("Rolling back....");
                Console.WriteLine(_amount.ToString("C") + " Returned to account " + _account.Name);

            }
            else if (_success)
            {
                Console.WriteLine("Transaction succeed!");
                Console.WriteLine(_amount.ToString("C") + " Withdrawed from account " + _account.Name);
            }
            else
            {
                Console.WriteLine("Transaction failed!");
            }
        }

        public override void Execute()
        {
            base.Execute();
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

        public override void Rollback()
        {
            if (_reversed)
            {
                throw new InvalidOperationException("Already Rolled back");
            }
            else if (!_success)
            {
                throw new InvalidOperationException("Transaction not finalized. Can't roll back");
            }
            if (_success && !_reversed)
            {
                base.Rollback();
                _account.Balance += _amount;
                _reversed = true;
            }
        }

        public bool Executed
        {
            get { return _executed; }
        }

        public override bool Success
        {
            get { return this._success; }
        }

        public bool Reserved
        {
            get { return _reversed; }
        }
    }
}
