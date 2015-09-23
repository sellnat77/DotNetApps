using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormEvents
{
    public class OverdrawnEventArgs : EventArgs
    {
        public decimal CurrentBalance, Amount;

        public OverdrawnEventArgs(decimal bal, decimal amt)
        {
            CurrentBalance = bal;
            Amount = amt;
        }
    }
}
