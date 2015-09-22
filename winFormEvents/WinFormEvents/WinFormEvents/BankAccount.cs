using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormEvents
{
    public class BankAccount
    {
        public event OverdrawnEventArgs Overdrawn;
        public decimal Balance { get; set; }

        public BankAccount()
        {
            Balance = 0;
        }

        void credit(decimal amount)
        {
            Balance += amount;
        }

        public void Debit(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                OnOverdrawn(new OverdrawnEventArgs(Balance,amount));
            }
        }

        protected virtual void OnOverdrawn(OverdrawnEventArgs overDraw)
        {
            if (Overdrawn != null)
            {
                Overdrawn(overDraw.CurrentBalance, overDraw.Amount);
            }
        }
    }
}
