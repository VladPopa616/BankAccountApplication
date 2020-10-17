using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    public static class ExtensionClass
    {
        public static string NAMoneyFormat(this double n, Boolean b)
        {
            double money = n * 100;

            if(b == true)
            {
                if (money < 0)
                {
                    money *= -1;
                    string str = string.Format("{0:C}", (Decimal.Ceiling((decimal)money)) / 100); //rounds number
                    return str;
                }
                else
                {
                    string str = string.Format("{0:C}", (Decimal.Ceiling((decimal)money)) / 100); //rounds number
                    return str;
                }
            }
            else
            {
                if (money < 0)
                {
                    money *= -1;
                    string str = string.Format("{0:C}", (Decimal.Ceiling((decimal)money)) / 100); //rounds number
                    return str;
                }
                else
                {
                    string str = string.Format("{0:C}", (Decimal.Ceiling((decimal)money)) / 100); //rounds number
                    return str;
                }
            }
        }

        public static double NAMoneyFormatD(this double n, Boolean b) //Method to avoid discrepancies
        {
            double money = n * 100;
            if (b == true)
            {
                if (money < 0)
                {
                    money *= -1;
                    decimal d = (Decimal.Ceiling((decimal)money)) / 100;
                    return ((double) d);
                }
                else
                {
                    decimal d = (Decimal.Ceiling((decimal)money)) / 100;
                    return ((double)d);
                }
            }
            else
            {
                if (money < 0)
                {
                    money *= -1;
                    decimal d = (Decimal.Ceiling((decimal)money)) / 100;
                    return ((double)d);
                }
                else
                {
                    decimal d = (Decimal.Ceiling((decimal)money)) / 100;
                    return ((double)d);
                }
            }
        }
    }
}
