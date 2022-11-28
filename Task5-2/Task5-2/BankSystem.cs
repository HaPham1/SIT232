using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_2
{
    //enum
    enum MenuOption
    {
        Withdraw,
        Deposit,
        Transfer,
        Print,
        Quit
    }
    class BankSystem
    {
        static void Main(string[] args)
        {
            //Create the account
            Account Ha = new Account("Ha", 976);
            Account Ha2 = new Account("Ha2", 50);
            Ha.Print();
            Console.ReadLine();
            bool state = true;
            while (state)
            {
                MenuOption option = ReadUserOption();
                switch (option)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(Ha);
                        Console.WriteLine();
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(Ha);
                        Console.WriteLine();
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(Ha, Ha2);
                        Console.WriteLine();
                        break;
                    case MenuOption.Print:
                        Console.WriteLine("Printing...............");
                        DoPrint(Ha);
                        DoPrint(Ha2);
                        Console.WriteLine();
                        break;
                    case MenuOption.Quit:
                        Console.WriteLine("Quitting...............");
                        state = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        Console.WriteLine();
                        break;
                }
            }
        }

        //Print out the menu and prompt user input
        static MenuOption ReadUserOption()
        {
            try
            {
                int option;
                do
                {
                    Console.WriteLine("Please choose one of the options below: ");
                    Console.WriteLine(" -- 1. Withdraw");
                    Console.WriteLine(" -- 2. Deposit");
                    Console.WriteLine(" -- 3. Transfer");
                    Console.WriteLine(" -- 4. Print");
                    Console.WriteLine(" -- 5. Quit");
                    option = Convert.ToInt32(Console.ReadLine());
                }
                while (option < 1 || option > 5);
                Console.WriteLine("Option " + (option) + " selected");
                return (MenuOption)(option - 1);
            }
            catch(Exception)
            {
                Console.WriteLine("Error!Please select an option");
                return ReadUserOption();
            }
        }

        //Perform the withdraw operation
        static void DoWithdraw (Account account)
        {
            String answer;
            decimal amount;
            try
            {
                Console.WriteLine("How much do you want to withdraw?");
                amount = Convert.ToDecimal(Console.ReadLine());
                WithdrawTransaction test = new WithdrawTransaction(account, amount);
                test.Execute();
                test.Print();
                Console.WriteLine("Do you want to finalize this operation? Yes/No");
                answer = Console.ReadLine();
                if (answer == "No" || answer == "no")
                {
                    test.Rollback();
                    test.Print();
                }
                Console.WriteLine("Operation Finished!");
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("The following error detected: " + e.GetType().ToString() + " with message \"" + e.Message + "\"");
            }
            catch (Exception)
            {
                Console.WriteLine("Error! Please enter a number");
            }
        }

        //Perform the deposit operation
        static void DoDeposit(Account account)
        {
            String answer;
            decimal amount;
            try
            {
                Console.WriteLine("How much do you want to deposit?");
                amount = Convert.ToDecimal(Console.ReadLine());
                DepositTransaction test = new DepositTransaction(account, amount);
                test.Execute();
                test.Print();
                Console.WriteLine("Do you want to finalize this operation? Yes/No");
                answer = Console.ReadLine();
                if (answer == "No" || answer =="no")
                {
                    test.Rollback();
                    test.Print();
                }
                Console.WriteLine("Operation Finished!");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("The following error detected: " + e.GetType().ToString() + " with message \"" + e.Message + "\"");
            }
            catch (Exception)
            {
                Console.WriteLine("Error! Please enter a number");
            }

        }

        //Perform the transfer operation
        static void DoTransfer(Account account, Account account2)
        {
            String answer;
            decimal amount;
            try
            {
                Console.WriteLine("How much do you want to transfer?");
                amount = Convert.ToDecimal(Console.ReadLine());
                TransferTransaction test = new TransferTransaction(account, account2, amount);
                test.Execute();
                test.Print();
                Console.WriteLine("Do you want to finalize this operation? Yes/No");
                answer = Console.ReadLine();
                if (answer == "No" || answer == "no")
                {
                    test.Rollback();
                    test.Print();
                }
                Console.WriteLine("Operation Finished!");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("The following error detected: " + e.GetType().ToString() + " with message \"" + e.Message + "\"");
            }
            catch (Exception)
            {
                Console.WriteLine("Error! Please enter a number");
            }

        }
        // Perform print operation
        static void DoPrint(Account account)
        {
            account.Print();
        }
    }
}
