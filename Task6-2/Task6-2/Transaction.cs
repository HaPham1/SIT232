using System;
using System.Collections.Generic;
using System.Text;

namespace Task6_2
{
    abstract class Transaction
    {
        //variables
        protected decimal _amount;
        protected Boolean _success;

        private Boolean _executed;
        private Boolean _reversed;
        private DateTime _dateStamp;


        //Properties
        public abstract bool Success
        {
            get;
        }

        public bool Executed
        {
            get { return _executed; }
        }

        public bool Reversed
        {
            get { return _reversed; }
        }

        public DateTime DateStamp
        {
            get { return _dateStamp; }
        }

        //Constructor
        public Transaction(decimal amount)
        {
            _amount = amount;
        }

        //Methods
        public abstract void Print();

        public virtual void Execute()
        {
            if(_executed)
            {
                throw new InvalidOperationException("Transaction already made.");
            }
            else
            {
                _executed = true;
                _dateStamp = DateTime.Now;
            }
        }

        public virtual void Rollback()
        {
            if (_reversed)
            {
                throw new InvalidOperationException("Already Rolled back");
            }
            else if (!_success)
            {
                throw new InvalidOperationException("Transaction not finalized");
            }
            else
            {
                _reversed = true;
                _dateStamp = DateTime.Now;
            }
        }
    }
}
