using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    interface IAccount
    {
        void MakeWithDrawal(double amount);
        void MakeDeposit(double amount);
        void CalculateInterest();
        string CloseAndReport();
    }
}
