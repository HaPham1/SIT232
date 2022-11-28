using System;
using System.Collections.Generic;
using System.Text;

namespace Task6_2
{
    //enum
    enum MenuOption
    {
        Withdraw,
        Deposit,
        Transfer,
        Print,
        Add,
        PrintTransactionHistory,
        Quit
    }
    class BankSystem
    {
        static void Main(string[] args)
        {
            //Create the account
            Account Ha = new Account("Ha", 976);
            Account Ha2 = new Account("Ha2", 50);

            Bank bank = new Bank();
            bank.AddAccount(Ha);
            bank.AddAccount(Ha2);
            Console.ReadLine();
            bool state = true;
            while (state)
            {
                MenuOption option = ReadUserOption();
                switch (option)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(bank);
                        Console.WriteLine();
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(bank);
                        Console.WriteLine();
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(bank);
                        Console.WriteLine();
                        break;
                    case MenuOption.Print:
                        Console.WriteLine("Printing...............");
                        DoPrint(bank);
                        Console.WriteLine();
                        break;
                    case MenuOption.Add:
                        DoAdd(bank);
                        break;
                    case MenuOption.PrintTransactionHistory:
                        DoPrintTransactionHistory(bank);
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
                    Console.WriteLine(" -- 5. Add");
                    Console.WriteLine(" -- 6. History");
                    Console.WriteLine(" -- 7. Quit");
                    option = Convert.ToInt32(Console.ReadLine());
                }
                while (option < 1 || option > 7);
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
        static void DoWithdraw (Bank bank)
        {
            String answer;
            decimal amount;
            try
            {
                //search for the account in bank
                Account account = FindAccount(bank);
                if (account == null)
                {
                    throw new NullReferenceException("Can't find the account specified");
                }

                //Ask for amount
                Console.WriteLine("How much do you want to withdraw?");
                amount = Convert.ToDecimal(Console.ReadLine());

                //Create new withdraw transaction then execute
                WithdrawTransaction test = new WithdrawTransaction(account, amount);
                bank.ExecuteTransaction(test);
                Console.WriteLine(test.DateStamp);
                test.Print();

                //Ask to finalize or rollback
                Console.WriteLine("Do you want to finalize this operation? Yes/No");
                answer = Console.ReadLine();
                if (answer == "No" || answer == "no")
                {
                    bank.RollbackTransaction(test);
                    Console.WriteLine(test.DateStamp);
                    test.Print();
                }

                //Indicate the finish of operation
                Console.WriteLine("Operation Finished!");
            }

            //Catch exceptions
            catch(InvalidOperationException e)
            {
                Console.WriteLine("The following error detected: " + e.GetType().ToString() + " with message \"" + e.Message + "\"");
            }
            catch (NullReferenceException e1)
            {
                Console.WriteLine("The following error detected: " + e1.GetType().ToString() + " with message \"" + e1.Message + "\"");
            }
            catch (Exception)
            {
                Console.WriteLine("Error! Please enter a number");
            }
        }




        //Perform the deposit operation
        static void DoDeposit(Bank bank)
        {
            String answer;
            decimal amount;
            try
            {
                //Find account
                Account account = FindAccount(bank);
                if (account == null)
                {
                    throw new NullReferenceException("Can't find the account specified");
                }

                //Specify amount
                Console.WriteLine("How much do you want to deposit?");
                amount = Convert.ToDecimal(Console.ReadLine());

                //Create deposit transaction
                DepositTransaction test = new DepositTransaction(account, amount);
                bank.ExecuteTransaction(test);
                Console.WriteLine(test.DateStamp);
                test.Print();

                //Ask for confirmation
                Console.WriteLine("Do you want to finalize this operation? Yes/No");
                answer = Console.ReadLine();
                if (answer == "No" || answer =="no")
                {
                    bank.RollbackTransaction(test);
                    Console.WriteLine(test.DateStamp);
                    test.Print();
                }
                Console.WriteLine("Operation Finished!");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("The following error detected: " + e.GetType().ToString() + " with message \"" + e.Message + "\"");
            }
            catch(NullReferenceException e1)
            {
                Console.WriteLine("The following error detected: " + e1.GetType().ToString() + " with message \"" + e1.Message + "\"");
            }
            catch (Exception)
            {
                Console.WriteLine("Error! Please enter a number");
            }

        }




        //Perform the transfer operation
        static void DoTransfer(Bank bank)
        {
            String answer;
            decimal amount;
            try
            {
                // Find 1st account
                Console.WriteLine("From Account");
                Account account = FindAccount(bank);
                if (account == null)
                {
                    throw new NullReferenceException("Can't find the account specified");
                }
                Console.WriteLine();

                //Find 2nd account
                Console.WriteLine("To Account");
                Account account2 = FindAccount(bank);
                if (account2 == null)
                {
                    throw new NullReferenceException("Can't find the account specified");
                }
                if (account2 == account)
                {
                    throw new InvalidOperationException("Can't transfer money from and to a same account");
                }

                //Specify amount
                Console.WriteLine("How much do you want to transfer?");
                amount = Convert.ToDecimal(Console.ReadLine());

                //create transfer transaction
                TransferTransaction test = new TransferTransaction(account, account2, amount);
                bank.ExecuteTransaction(test);
                Console.WriteLine(test.DateStamp);
                test.Print();

                //Ask for confirm
                Console.WriteLine("Do you want to finalize this operation? Yes/No");
                answer = Console.ReadLine();
                if (answer == "No" || answer == "no")
                {
                    bank.RollbackTransaction(test);
                    Console.WriteLine(test.DateStamp);
                    test.Print();
                }
                Console.WriteLine("Operation Finished!");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("The following error detected: " + e.GetType().ToString() + " with message \"" + e.Message + "\"");
            }
            catch (NullReferenceException e1)
            {
                Console.WriteLine("The following error detected: " + e1.GetType().ToString() + " with message \"" + e1.Message + "\"");
            }
            catch (Exception)
            {
                Console.WriteLine("Error! Please enter a number");
            }

        }




        //Perform the add operation
        static void DoAdd(Bank bank)
        {
            try
            {
                String name;
                Decimal balance;

                Console.WriteLine("Please enter your account name: ");
                name = Console.ReadLine();
                Console.WriteLine("Please enter starting balance: ");
                balance = Convert.ToDecimal(Console.ReadLine());
                Account account = new Account(name, balance);
                bank.AddAccount(account);
                Console.WriteLine("Account added.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error! Please enter both valid value");
            }
        }




        // Perform print operation
        static void DoPrint(Bank bank)
        {
            foreach (Account account in bank.List)
            {
                account.Print();
            }
        }




        //Print history of transactions.
        static void DoPrintTransactionHistory(Bank bank)
        {
            try
            {
                bank.PrintTransactionHistory();
                DoRollBack(bank);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("The following error detected: " + e.GetType().ToString() + " with message \"" + e.Message + "\"");
            }
        }






        //Do the rollback base on history
        static void DoRollBack(Bank bank)
        {
            int result;
            do
            {
                Console.WriteLine("Enter transaction number to rollback (0 to quit)");
                result = Convert.ToInt32(Console.ReadLine());
                if (result == 0)
                {
                    return;
                }
            }
            while (result < 0 || result > bank.TranList.Count);
            Console.WriteLine("Option " + (result) + " selected");
            bank.RollbackTransaction(bank.TranList[result - 1]);
        }





        // Find account operation
        private static Account FindAccount(Bank bank)
        {
            String name;
            Console.WriteLine("Please enter the account name you want: ");
            name = Console.ReadLine();
            Account test = bank.GetAccount(name);
            if (test == null)
            {
                Console.WriteLine("No account found.");
                return test;
            }
            else
            {
                Console.WriteLine("Account found");
                return test;
            }
        }
    }
}
