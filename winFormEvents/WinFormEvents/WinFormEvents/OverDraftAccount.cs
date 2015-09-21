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
        public BankAccount overDraftAccount { get; set; }

        double balance { get; set; }

        public new void debit(double amount)
        {
            if ( balance + savingsAccount.balance < amount)
            {
                //do something
            }

        }
    }
}
