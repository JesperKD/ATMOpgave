using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMOpgaven
{
    public static class CardBank
    {
        /// <summary>
        /// Saves a card in the txt file and returns it to the view
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public static CreditCard SaveNewcard(string name, int pincode)
        {
            Random random = new Random();
            string path = Environment.CurrentDirectory + "\\CardBank.txt";
            try
            {
                CreditCard creditCard = new CreditCard(random.Next(1000000000, int.MaxValue), name, random.Next(100, 999), pincode);
                File.AppendAllText(path, $"{creditCard.CardNumber}; {creditCard.NameOfOwner}; {creditCard.SecurityNumber}; {creditCard.PinCode}\n");
                return creditCard;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Returns a boolean based on if the given object exists in the txt file
        /// </summary>
        /// <param name="creditCard"></param>
        /// <returns></returns>
        public static bool CheckIfCardExists(CreditCard creditCard)
        {
            string path = Environment.CurrentDirectory + "\\CardBank.txt";
            string cardString = $"{creditCard.CardNumber}; {creditCard.NameOfOwner}; {creditCard.SecurityNumber}; {creditCard.PinCode}";

            try
            {
                foreach (string line in File.ReadAllLines(path))
                {
                    if (line == cardString)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

    }
}
