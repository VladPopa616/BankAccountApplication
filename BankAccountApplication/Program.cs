using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instances of all classes
            SavingsAccount savings = new SavingsAccount(10, 0.1);
            ChequingAccount cheques = new ChequingAccount(10, 0.1);
            GlobalSavingsAccount globals = new GlobalSavingsAccount(10, 0.1);

            //Login prompt for usability
            Console.WriteLine("This is a console based banking program");
            Console.WriteLine("Enter log in credentials to continue (Anything works, it's just an extra usability feature)");
            Console.WriteLine("Username: ");
            string user = Console.ReadLine();
            Console.WriteLine("Password: ");
            Console.ReadLine();
            Console.WriteLine("Welcome, " + user + ". Let's get started");

            //Initialization of boolean variables
            bool menuExit = false;
            bool subMenuExit = false;
            bool validDeposit = false;
            bool validWithdrawal = false;

            
            //main menu loop
            while(menuExit == false)
            {
                subMenuExit = false;
                try
                {
                    Console.WriteLine("Please choose an option from the main menu: ");
                    Console.WriteLine("A: Savings Account");
                    Console.WriteLine("B: Chequing Account");
                    Console.WriteLine("C: Global Savings Account");
                    Console.WriteLine("Q: Exit");
                    

                    string accountChoice = Console.ReadLine();
                    string letterChoice;

                    //main menu switch statement
                    switch (accountChoice.Trim().ToLower())
                    {
                        case "a":
                        case "savings":
                        case "savings account": 
                            while (subMenuExit == false)
                            {
                                try
                                {
                                    Console.WriteLine("Please choose an option from the Savings Menu: ");
                                    Console.WriteLine("A: Deposit");
                                    Console.WriteLine("B: Withdrawal");
                                    Console.WriteLine("C: Close and Report");
                                    Console.WriteLine("R: Return to main menu");
                                    string balance = string.Format("{0:C}", savings.MonthCurrentBalance);
                                    Console.WriteLine("Current balance : " + balance);
                                    letterChoice = Console.ReadLine();

                                    validDeposit = false;
                                    validWithdrawal = false;

                                    //start of switch statement in Savings menu
                                    switch (letterChoice.Trim().ToLower())
                                    {
                                        case "a":
                                        case "deposit":
                                            
                                            //deposit validation loop
                                            while(validDeposit == false)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter the amount to deposit: ");
                                                    string depAmount = Console.ReadLine().Trim(new char[] { '$', ' ' });
                                                    double deposit = Convert.ToDouble(depAmount);

                                                    if(deposit < 0)
                                                    {
                                                        NegativeNumberError();
                                                    }
                                                    else
                                                    {
                                                        savings.MakeDeposit(deposit);
                                                        Console.WriteLine(string.Format("{0:C}", deposit) + " deposited successfully");
                                                        validDeposit = true; //loop exited
                                                    }
                                                }
                                                catch(NegativeNumberException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                    Console.WriteLine("Please retry");
                                                }

                                                catch (FormatException)
                                                {
                                                    try
                                                    {
                                                        NotNumberError();
                                                    }
                                                    catch(NotNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }
                                                

                                                
                                            }
                                            break;

                                        case "b":
                                        case "withdraw":

                                            //withdrawal validation loop
                                            while(validWithdrawal == false)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter the amount to withdraw: ");
                                                    string drawAmount = Console.ReadLine().Trim(new char[] { '$', ' ' });
                                                    double withdraw = Convert.ToDouble(drawAmount);

                                                    if (withdraw < 0)
                                                    {
                                                        NegativeNumberError();
                                                    }
                                                    else
                                                    {
                                                        savings.MakeWithDrawal(withdraw);
                                                        Console.WriteLine(string.Format("{0:C}", withdraw) + " withdrawn successfully");
                                                        validWithdrawal = true; //loop exited
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    try
                                                    {
                                                        NotNumberError();
                                                    }
                                                    catch (NotNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }
                                            }
                                            break;

                                        case "c":
                                        case "close and report":
                                            Console.WriteLine("Closing and giving Report...");
                                            Console.WriteLine(savings.CloseAndReport());
                                            break;
                                        case "r":
                                        case "return to main menu":
                                            subMenuExit = true;
                                            break;
                                        default:
                                            WrongMenuChoice();
                                            break;
                                    }
                                    //End of switch Savings Menu
                                }
                                
                                catch(WrongMenuChoiceException e) 
                                {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine("Try again! Write A,B,C,R or write out the option");
                                }
                            }
                            break;

                        case "b":
                        case "chequing":
                        case "chequing account":
                            while (subMenuExit == false)
                            {
                                try
                                {
                                    Console.WriteLine("Please choose an option from the chequing Menu: ");
                                    Console.WriteLine("A: Deposit");
                                    Console.WriteLine("B: Withdrawal");
                                    Console.WriteLine("C: Close and Report");
                                    Console.WriteLine("R: Return to main menu");
                                    string balance = string.Format("{0:C}", cheques.MonthCurrentBalance);
                                    Console.WriteLine("Current balance : " + balance);
                                    letterChoice = Console.ReadLine();

                                    validDeposit = false;
                                    validWithdrawal = false;

                                    //start of switch statement in Savings menu
                                    switch (letterChoice.Trim().ToLower())
                                    {
                                        case "a":
                                        case "deposit":

                                            //deposit validation loop
                                            while (validDeposit == false)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter the amount to deposit: ");
                                                    string depAmount = Console.ReadLine().Trim(new char[] { '$', ' ' });
                                                    double deposit = Convert.ToDouble(depAmount);

                                                    if (deposit < 0)
                                                    {
                                                        NegativeNumberError();
                                                    }
                                                    else
                                                    {
                                                        cheques.MakeDeposit(deposit);
                                                        Console.WriteLine(string.Format("{0:C}", deposit) + " deposited successfully");
                                                        validDeposit = true; //loop exited
                                                    }
                                                }
                                                catch (NegativeNumberException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                    Console.WriteLine("Please retry");
                                                }

                                                catch (FormatException)
                                                {
                                                    try
                                                    {
                                                        NotNumberError();
                                                    }
                                                    catch (NotNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }



                                            }
                                            break;

                                        case "b":
                                        case "withdraw":

                                            //withdrawal validation loop
                                            while (validWithdrawal == false)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter the amount to withdraw: ");
                                                    string drawAmount = Console.ReadLine().Trim(new char[] { '$', ' ' });
                                                    double withdraw = Convert.ToDouble(drawAmount);

                                                    if (withdraw < 0)
                                                    {
                                                        NegativeNumberError();
                                                    }
                                                    else
                                                    {
                                                        cheques.MakeWithDrawal(withdraw);
                                                        Console.WriteLine(string.Format("{0:C}", withdraw) + " withdrawn successfully");
                                                        validWithdrawal = true; //loop exited
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    try
                                                    {
                                                        NotNumberError();
                                                    }
                                                    catch (NotNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }
                                            }
                                            break;

                                        case "c":
                                        case "close and report":
                                            Console.WriteLine("Closing and giving Report...");
                                            Console.WriteLine(cheques.CloseAndReport());
                                            break;
                                        case "r":
                                        case "return to main menu":
                                            subMenuExit = true;
                                            break;
                                        default:
                                            WrongMenuChoice();
                                            break;
                                    }
                                    //End of switch Chequing Menu
                                }

                                catch (WrongMenuChoiceException e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine("Try again! Write A,B,C,R or write out the option");
                                }
                            }
                            break;

                        case "c":
                        case "global":
                        case "global savings":
                        case "global savings account":
                            while (subMenuExit == false)
                            {
                                try
                                {
                                    Console.WriteLine("Please choose an option from the Savings Menu: ");
                                    Console.WriteLine("A: Deposit");
                                    Console.WriteLine("B: Withdrawal");
                                    Console.WriteLine("C: Close and Report");
                                    Console.WriteLine("R: Return to main menu");
                                    string balance = string.Format("{0:C}", globals.MonthCurrentBalance);
                                    Console.WriteLine("Current balance : " + balance);
                                    letterChoice = Console.ReadLine();

                                    validDeposit = false;
                                    validWithdrawal = false;

                                    //start of switch statement in Global Savings menu
                                    switch (letterChoice.Trim().ToLower())
                                    {
                                        case "a":
                                        case "deposit":

                                            //deposit validation loop
                                            while (validDeposit == false)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter the amount to deposit: ");
                                                    string depAmount = Console.ReadLine().Trim(new char[] { '$', ' ' });
                                                    double deposit = Convert.ToDouble(depAmount);

                                                    if (deposit < 0)
                                                    {
                                                        NegativeNumberError();
                                                    }
                                                    else
                                                    {
                                                        globals.MakeDeposit(deposit);
                                                        Console.WriteLine(string.Format("{0:C}", deposit) + " deposited successfully");
                                                        validDeposit = true; //loop exited
                                                    }
                                                }
                                                catch (NegativeNumberException e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                    Console.WriteLine("Please retry");
                                                }

                                                catch (FormatException)
                                                {
                                                    try
                                                    {
                                                        NotNumberError();
                                                    }
                                                    catch (NotNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }



                                            }
                                            break;

                                        case "b":
                                        case "withdraw":

                                            //withdrawal validation loop
                                            while (validWithdrawal == false)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter the amount to withdraw: ");
                                                    string drawAmount = Console.ReadLine().Trim(new char[] { '$', ' ' });
                                                    double withdraw = Convert.ToDouble(drawAmount);

                                                    if (withdraw < 0)
                                                    {
                                                        NegativeNumberError();
                                                    }
                                                    else
                                                    {
                                                        globals.MakeWithDrawal(withdraw);
                                                        Console.WriteLine(string.Format("{0:C}", withdraw) + " withdrawn successfully");
                                                        validWithdrawal = true; //loop exited
                                                    }
                                                }
                                                catch (FormatException)
                                                {
                                                    try
                                                    {
                                                        NotNumberError();
                                                    }
                                                    catch (NotNumberException ex)
                                                    {
                                                        Console.WriteLine(ex.Message);
                                                    }
                                                }
                                            }
                                            break;

                                        case "c":
                                        case "close and report":
                                            Console.WriteLine("Closing and giving Report...");
                                            Console.WriteLine(globals.CloseAndReport());
                                            break;
                                        case "r":
                                        case "return to main menu":
                                            subMenuExit = true;
                                            break;
                                        default:
                                            WrongMenuChoice();
                                            break;
                                    }
                                    //End of switch Global Savings Menu
                                }

                                catch (WrongMenuChoiceException e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine("Try again! Write A,B,C,R or write out the option");
                                }
                            }
                            break;

                        case "q":
                        case "exit":
                            menuExit = true;
                            break;
                        default:
                            WrongMenuChoice();
                            break;

                    }
                }
                catch(WrongMenuChoiceException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try again! A,B,C,Q or write out the account you wish to go to");
                }
                

            }
        }

        public static void WrongMenuChoice()
        {
            WrongMenuChoiceException e = new WrongMenuChoiceException("The selected choice is invalid. An error occured");
            throw e;
        }
        public static void NegativeNumberError()
        {
            NegativeNumberException e = new NegativeNumberException("Currency amounts cannot be a negative number. An error occured");
            throw e;
        }

        public static double NotNumberError()
        {
            NotNumberException e = new NotNumberException("Currency inputs must be a number value. An error occured");
            throw e;
        }
    }
}
