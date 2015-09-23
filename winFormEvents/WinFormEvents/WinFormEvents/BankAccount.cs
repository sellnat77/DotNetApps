using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormEvents
{
    public class BankAccount
    {
        public delegate void OverDrawnEventHandler(object sender, OverdrawnEventArgs args);
        public event OverDrawnEventHandler Overdrawn;
        public decimal Balance { get; set; }

        public BankAccount()
        {
            Balance = 0;
        }

        public void credit(decimal amount)
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

        public virtual void OnOverdrawn(OverdrawnEventArgs overDraw)
        {
            if (Overdrawn != null)
            {
                OverdrawnEventArgs args = new OverdrawnEventArgs(overDraw.CurrentBalance, overDraw.Amount);
                Overdrawn(this,args);
            }
        }
    }
}
