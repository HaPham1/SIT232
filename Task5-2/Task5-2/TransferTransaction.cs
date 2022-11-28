using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_2
{
    class TransferTransaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        private decimal _amount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private Boolean _executed;
        private Boolean _reversed;

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;
            _withdraw = new WithdrawTransaction(_fromAccount, _amount);
            _deposit = new DepositTransaction(_toAccount, _amount);

        }

        public void Print()
        {
            if (_reversed)
            {
                Console.WriteLine("Rolling back....");
                Console.WriteLine(_amount.ToString("C") + " Returned from " + _toAccount.Name + "'s account to " + _fromAccount.Name + "'s account.");

            }
            else if (Success)
            {
                Console.WriteLine("Transferred " + _amount.ToString("C") + " from " + _fromAccount.Name + "'s account to " + _toAccount.Name + "'s account.");
                _withdraw.Print();
                _deposit.Print();
            }
            else
            {
                Console.WriteLine("Transfer failed!");
            }
        }

        public void Execute()
        {
            if (_executed)
            {
                throw new InvalidOperationException("Transfer already made.");
            }
            if (_amount > _fromAccount.Balance)
            {
                throw new InvalidOperationException("Insufficient fund");
            }
            else
            {
                _withdraw.Execute();
                _executed = true;
                _deposit.Execute();
                if (!_deposit.Success)
                {
                    _withdraw.Rollback();
                }
            }
            
        }

        public void Rollback()
        {
            if (_reversed)
            {
                throw new InvalidOperationException("Already reverse");
            }
            if (!Success)
            {
                throw new InvalidOperationException("Transfer not completed");
            }
            if (_toAccount.Balance < _amount)
            {
                throw new InvalidOperationException("Insufficient balance to reverse");
            }
            if(Success && !_reversed)
            {
                _withdraw.Rollback();
                _deposit.Rollback();
                _reversed = true;
            }

        }

        public bool Executed
        {
            get { return _executed; }
        }

        public bool Success
        {
            get { return _deposit.Success && _withdraw.Success; }
        }

        public bool Reserved
        {
            get { return _reversed; }
        }
    }
}
