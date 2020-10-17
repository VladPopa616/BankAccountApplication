using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    class SavingsAccount : Account, IAccount
    {
        AccountStatus stat;
        public SavingsAccount(double bal, double int_rate): base(bal, int_rate)
        {
            if(bal < 25)
            {
                stat = AccountStatus.inactive;
            }
            else
            {
                stat = AccountStatus.active;
            }
        }

        public override string CloseAndReport()
        {
            if (withdrawalCount > 4)
            {
                monthServiceCharge += (withdrawalCount - 4) * 1;
                return base.CloseAndReport();
            }
            else
            {
                return base.CloseAndReport();
            }
            
        }

        public override void MakeDeposit(double amount)
        {
            if(stat == AccountStatus.inactive && MonthCurrentBalance + amount > 25)
            {
                base.MakeDeposit(amount);
                stat = AccountStatus.active;
            }
            else
            {
                base.MakeDeposit(amount);
            }
        }

        public override void MakeWithDrawal(double amount)
        {
            if(stat == AccountStatus.inactive)
            {
                Console.WriteLine("This bank account is inactive");
                Console.WriteLine("If you want to make a withdrawal, you must have a balance over $25");
            }

            else
            {
                if(MonthCurrentBalance - amount > 25)
                {
                    base.MakeWithDrawal(amount);
                    Console.WriteLine(string.Format("{0:C}", amount) + " withdrawed successfully");
                    stat = AccountStatus.inactive;
                }
            }
        }
    }
}
