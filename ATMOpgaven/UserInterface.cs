using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMOpgaven
{
    public static class UserInterface
    {

        public static void ATM()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Are you already registered with a card in our system?");
                Console.WriteLine("Y / N");
                string response1 = Console.ReadKey().Key.ToString().ToUpper();
                if (response1 == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Would you like to register yourself and get granted a CreditCard and Bank account?");
                    Console.WriteLine("Y / N");
                    string response2 = Console.ReadKey().Key.ToString().ToUpper();
                    if (response2 == "N")
                    {
                        Console.Clear();
                        Console.WriteLine("Have a lovely day.");
                        Console.ReadKey();
                        running = false;
                    }
                    else if (response2 == "Y")
                    {
                        Console.Clear();
                        Console.WriteLine("Please type your name:");
                        string actorName = Console.ReadLine();
                        Console.WriteLine("\nPlease type your Pincode:");
                        try
                        {
                            int pincode = int.Parse(Console.ReadLine());
                            CreditCard credit = CardBank.SaveNewcard(actorName, pincode);

                            Console.Clear();
                            Console.WriteLine("Your new card has now been registered.");
                            Console.WriteLine("Here's your new Card info:\n");
                            Console.WriteLine($"Cardnumber: {credit.CardNumber}");
                            Console.WriteLine($"Name of Owner: {credit.NameOfOwner}");
                            Console.WriteLine($"Security Number: {credit.SecurityNumber}");
                            Console.WriteLine($"Pin: {credit.PinCode}");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                    }
                }
                else if(response1 == "Y")
                {
                    Console.Clear();
                    Console.WriteLine("Please type in your cardnumber:\n");
                    int cardNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please type in your name:\n");
                    string nameOfOwner = Console.ReadLine();
                    Console.WriteLine("Please type in your SecurityNumber:\n");
                    int securityNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("please type your pincode:");
                    int pincode = int.Parse(Console.ReadLine());

                    CreditCard credit = new CreditCard(cardNumber, nameOfOwner, securityNumber, pincode);
                    bool cardExists = CardBank.CheckIfCardExists(credit);

                    if (!cardExists)
                    {
                        Console.WriteLine("No card with this information exists in our system.");
                        Console.WriteLine("Please try again.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Welcome back {credit.NameOfOwner}.\n");
                        Console.WriteLine("Please choose an option:\n");
                        Console.WriteLine("W. Withdraw money from account.\n");
                        Console.WriteLine("D. Deposit money into account");
                        string response3 = Console.ReadKey().Key.ToString().ToUpper();

                        if(response3 == "W")
                        {
                            Console.Clear();
                            Console.WriteLine($"Your balance: {Bank.GetCurrentAmount(credit)}\n");
                            Console.WriteLine("Please enter an amount to withdraw from your bank account:");
                            int withdrawAmmount = int.Parse(Console.ReadLine());
                            int newamount = Bank.WithdrawMoney(credit, withdrawAmmount);

                            Console.Clear();

                            Console.WriteLine("Withdrawal successfull!\n");

                            Console.WriteLine($"Your new account balance is: {newamount}\n");
                            Console.WriteLine("Have a lovely day.");
                            Console.ReadKey();
                            running = false;
                        }
                        else if(response3 == "D")
                        {
                            Console.Clear();
                            Console.WriteLine($"Your Balance: {Bank.GetCurrentAmount(credit)}\n");
                            Console.WriteLine("Please enter an amount to deposit into your account:");
                            int depositAmount = int.Parse(Console.ReadLine());
                            int newamount = Bank.DepositMoney(credit, depositAmount);

                            Console.Clear();

                            Console.WriteLine("Deposit Succesfull!\n");

                            Console.WriteLine($"Your new account balance is: {newamount}");
                            Console.WriteLine("Have a lovely day.");
                            Console.ReadKey();
                            running = false;
                        }
                        else
                        {
                            Console.WriteLine("Not a valid input.");
                        }
                    }
                }
            }
        }
    }
}
