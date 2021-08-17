using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMOpgaven
{
    public static class Bank
    {
        /// <summary>
        /// Returns current amount on bank account
        /// </summary>
        /// <param name="creditCard"></param>
        /// <returns></returns>
        public static int GetCurrentAmount(CreditCard creditCard)
        {
            string path = Environment.CurrentDirectory + $"\\{creditCard.CardNumber}.txt";
            int currentAmount = 0;

            if (File.Exists(path))
            {
                currentAmount = int.Parse(File.ReadAllText(path));
            }

            return currentAmount;
        }

        /// <summary>
        /// removes specific amount from bank account
        /// </summary>
        /// <param name="creditCard"></param>
        /// <param name="withdrawAmount"></param>
        /// <returns></returns>
        public static int WithdrawMoney(CreditCard creditCard, int withdrawAmount)
        {
            string path = Environment.CurrentDirectory + $"\\{creditCard.CardNumber}.txt";
            int newTotal = 0;

            try
            {
                newTotal = GetCurrentAmount(creditCard) - withdrawAmount;

                File.WriteAllText(path, newTotal.ToString());

                return newTotal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        /// <summary>
        /// Adds specific amount to bank account
        /// </summary>
        /// <param name="creditCard"></param>
        /// <param name="depositAmount"></param>
        /// <returns></returns>
        public static int DepositMoney(CreditCard creditCard, int depositAmount)
        {
            string path = Environment.CurrentDirectory + $"\\{creditCard.CardNumber}.txt";
            int newTotal = 0;

            try
            {
                newTotal = GetCurrentAmount(creditCard) + depositAmount;

                File.WriteAllText(path, newTotal.ToString());
                return newTotal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

    }
}
