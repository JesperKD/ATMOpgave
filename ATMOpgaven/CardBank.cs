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
        /// Returns a randomly generated card
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public static CreditCard GenerateNewCard(string name, int pincode)
        {
            Random random = new Random();
            int cardNumber = random.Next(1000000000, int.MaxValue);
            if (IsCardNumberNew(cardNumber))
            {
                CreditCard creditCard = new CreditCard(cardNumber, name, random.Next(100, 999), pincode);
                SaveNewcard(creditCard);
                return creditCard;
            }
            return null;
        }

        /// <summary>
        /// Returns a boolean to see if a cardnumber has been used before
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsCardNumberNew(int number)
        {
            foreach (String item in GetAllCards())
            {
                string[] splitItem = item.Split(';');
                if (number == int.Parse(splitItem[0]))
                {
                    return false;
                }
            }
            return true;
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
                File.AppendAllText(path, $"{ConvertCardToString(creditCard)}");
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
