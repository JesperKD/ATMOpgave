using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMOpgaven
{
    public class CreditCard
    {
        public int CardNumber { get; set; }

        public string NameOfOwner { get; set; }

        public int SecurityNumber { get; set; }

        public int PinCode { get; set; }

        public CreditCard(int cardNumber, string nameOfOwner, int securityNumber, int pinCode)
        {
            CardNumber = cardNumber;
            NameOfOwner = nameOfOwner;
            SecurityNumber = securityNumber;
            PinCode = pinCode;
        }

    }
}
