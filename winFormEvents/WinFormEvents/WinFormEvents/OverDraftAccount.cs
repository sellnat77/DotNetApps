using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormEvents
{
    class OverDraftAccount : BankAccount
    {
        public BankAccount savingsAccount { get; set; }

        public new void Debit(decimal amount)
        {
            if ( Balance + savingsAccount.Balance < amount)
            {
                OnOverdrawn(new OverdrawnEventArgs(savingsAccount.Balance, amount));
            }
            else
            {
                if(Balance >= amount)
                {
                    Balance -= amount;
                }
                else
                {
                    amount -= Balance;
                    Balance = 0m;

                    if ( amount > 0m )
                    {
                        savingsAccount.Balance -= amount;
                    }
                }
            }

        }
    }
}
