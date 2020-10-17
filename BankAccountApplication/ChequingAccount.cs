using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    class ChequingAccount : Account, IAccount
    {
        public ChequingAccount(double bal, double int_rate): base(bal, int_rate)
        {

        }

        public override void MakeWithDrawal(double amount)
        {
           if (MonthCurrentBalance - amount < 0)
            {
                monthServiceCharge += 15;
                Console.WriteLine("Not enough funds to make withdrawal");
                Console.WriteLine("Added a $15 monthly charge fee to your account");
            }
            else
            {
                base.MakeWithDrawal(amount);
                Console.WriteLine(string.Format("{0:C}", amount) + " withdrawed successfully");

            }
        }

        public override void MakeDeposit(double amount)
        {
            base.MakeDeposit(amount);
        }

        public override string CloseAndReport()
        {
            monthServiceCharge += 5 + (0.10 * withdrawalCount);
            return base.CloseAndReport();
        }
    }
}
