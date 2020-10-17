using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    class GlobalSavingsAccount : SavingsAccount, IExchangeable, IAccount
    {
        public GlobalSavingsAccount(double bal, double int_rate) : base(bal, int_rate)
        {

        }

        public double USValue(double rate)
        {
            return MonthCurrentBalance * rate;
        }
    }
}
