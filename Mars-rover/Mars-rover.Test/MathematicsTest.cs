using System;
using System.Collections.Generic;
using System.Text;
using Test;
using Xunit;

namespace Mars_rover.Test
{
    public class MathematicsTest
    {
        [Fact]
        public void SubtractTest()
        {
            #region Arrange
            //Kaynaklar hazırlanıyor.
            int number1 = 10;
            int number2 = 20;
            int expected = -10;
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            //İlgili metot Arrange'de ki kaynaklarla test ediliyor.
            int result = mathematics.Subtract(number1, number2);
            #endregion
            #region Assert
            //Test neticesinde gelen data doğrulanıyor.
            Assert.Equal(expected, result);
            #endregion
        }
    }
}
