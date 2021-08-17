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
        [Theory]
        [InlineData("Peter", 1234)]
        [InlineData("Rasputin", 0101010)]
        [InlineData("Lille Lone", 1251251)]
        [InlineData("Mogens Ackerman", 3333)]
        [InlineData("æææææææææææææææ", 0000000000000)]
        [InlineData("jghsdlaæijghdsilæugh", 1121212121)]
        [InlineData("laaaaaaars", 1)]
        public void Save_ShouldSaveToFile(string x, int y)
        {

            //Arrange
            bool expected = true;

            //Act
            bool actual = false;
            try
            {
                CardBank.SaveNewcard(x, y);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }

            //Assert
            Assert.Equal(expected, actual);
        }


    }
}
