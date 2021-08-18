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
        public static CreditCard GenerateNewCard(string name, int pincode)
        {
            Random random = new Random();
            CreditCard creditCard = new CreditCard(random.Next(1000000000, int.MaxValue), name, random.Next(100, 999), pincode);
            SaveNewcard(creditCard);
            return creditCard;
        }

        /// <summary>
        /// Saves a card in the txt file and returns it to the view
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public static void SaveNewcard(CreditCard creditCard)
        {
            string path = Environment.CurrentDirectory + "\\CardBank.txt";
            try
            {
                File.AppendAllText(path, $"{ConvertCardToString(creditCard)}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Returns a boolean based on if the given object exists in the txt file
        /// </summary>
        /// <param name="creditCard"></param>
        /// <returns></returns>
        public static bool CheckIfCardExists(CreditCard creditCard)
        {
            string[] allCards = GetAllCards();
            try
            {
                foreach (string line in allCards)
                {
                    if (line == ConvertCardToString(creditCard))
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

        /// <summary>
        /// Returns a string array of all saved cards
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllCards()
        {
            string path = Environment.CurrentDirectory + "\\CardBank.txt";
            return File.ReadAllLines(path);
        }

        /// <summary>
        /// Returns all creditCard data as a single string
        /// </summary>
        /// <param name="creditCard"></param>
        /// <returns></returns>
        public static string ConvertCardToString(CreditCard creditCard)
        {
            return $"{creditCard.CardNumber}; {creditCard.NameOfOwner}; {creditCard.SecurityNumber}; {creditCard.PinCode}";
        }
    }
}
