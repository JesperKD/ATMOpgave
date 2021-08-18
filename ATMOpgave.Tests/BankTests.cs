using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMOpgaven;
using Xunit;

namespace ATMOpgaven.Tests
{
    public class BankTests
    {

        [Fact]
        public void Withdraw_ShouldRemoveFromAmount()
        {
            //Test Card
            CreditCard testCard = new CreditCard(1, "Test", 1, 1);
            int withAmount = 5000;

            int initialAmount = Bank.GetCurrentAmount(testCard);
            int newAmount = Bank.WithdrawMoney(testCard, withAmount);

            //Assert
            Assert.True(initialAmount > newAmount);
        }

        [Fact]
        public void Deposit_ShouldAddToAmount()
        {
            //Test Card
            CreditCard testCard = new CreditCard(1, "Test", 1, 1);
            int depositAmount = 5000;

            int initialAmount = Bank.GetCurrentAmount(testCard);
            int newAmount = Bank.DepositMoney(testCard, depositAmount);

            //Assert
            Assert.True(initialAmount < newAmount);

        }

    }
}
