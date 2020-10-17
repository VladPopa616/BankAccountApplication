using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    interface IExchangeable
    {
        double USValue(double rate);
    }
}
