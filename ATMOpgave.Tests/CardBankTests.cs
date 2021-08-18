using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ATMOpgaven.Tests
{
    public class CardBankTests
    {
        [Fact]
        public void Generate_ShouldGenerateNewCard()
        {
            string[] initialCollection = CardBank.GetAllCards();

            CardBank.GenerateNewCard("Test", 1234);

            string[] updatedCollection = CardBank.GetAllCards();

            //Assert
            Assert.True(initialCollection != updatedCollection);
        }

    }
}
