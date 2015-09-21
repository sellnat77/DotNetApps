using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormEvents
{
    public class BankAccount
    {
        public double balance { get; set; }

        public BankAccount()
        {
            balance = 0;
        }

        void credit(double amount)
        {
            balance += amount;
        }

        public void debit(double amount)
        {
            if (balance == 0)
            {
                Console.WriteLine("Balance is zero!");
            }
            else
            {
                balance -= amount;
            }
        }
    }
}
