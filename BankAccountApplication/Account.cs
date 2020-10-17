using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    abstract class Account : IAccount
    {
        private double startBalance;
        private double currentBalance;

        protected double totalDeposits;
        protected int depositCount;

        protected double totalWithdrawals;
        protected int withdrawalCount;

        protected double annualInterest;
        protected double monthServiceCharge;


        public double MonthStartingBalance
        {
            get
            {
                return startBalance;
            }
        }

        public double MonthCurrentBalance
        {
            get
            {
                return currentBalance;
            }
        }

        public enum AccountStatus
        {
            active = 1,
            inactive = 0
        }


        public Account(double bal, double int_rate)
        {
            startBalance = bal;
            currentBalance = bal;
            annualInterest = int_rate;
        }

        public void CalculateInterest()
        {
            double monthInterest = annualInterest / 12;
            monthInterest = currentBalance * monthInterest;
            currentBalance += monthInterest;
        }

        public double PercentChange()
        {
            double per_diff = Math.Round(((currentBalance - startBalance) / startBalance), 2);
            return per_diff;
        }

        public virtual string CloseAndReport()
        {
            currentBalance -= monthServiceCharge;
            CalculateInterest();

            double monthInterest = annualInterest / 12;
            string formattedIntRate = string.Format("{0:0.00}%",monthInterest * 100);
            double intAmount = currentBalance * monthInterest;
            string formattedIntAmount = monthInterest.NAMoneyFormat(true);

            string balance = "Starting balance: " + startBalance.NAMoneyFormat(true) +
                "\nCurrent Balance: " + currentBalance.NAMoneyFormat(true);

            string percentage = "Percent difference between starting and current balance: " + PercentChange();
            string intPay = "Month's interest rate: (" + formattedIntRate + ") paid: " + formattedIntAmount;
            string serviceCharge = " Monthly Service charge paid: " + monthServiceCharge.NAMoneyFormat(true);

            string str = string.Format("{0}\n{1}\n{2}\n{3}\n", balance,percentage,intPay,serviceCharge);

            withdrawalCount = 0;
            depositCount = 0;

            totalWithdrawals = 0;
            totalDeposits = 0;

            monthServiceCharge = 0;

            return str;

        }


        public virtual void MakeDeposit(double amount)
        {
            currentBalance += amount;
            totalDeposits += amount;
            depositCount++;
        }

        public virtual void MakeWithDrawal(double amount)
        {
            currentBalance -= amount;
            totalWithdrawals += amount;
            withdrawalCount++;
        }
    }
}
