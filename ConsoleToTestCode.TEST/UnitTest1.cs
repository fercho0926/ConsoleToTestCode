using System;
using Xunit;

namespace ConsoleToTestCode.TEST
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange

            var x = 5;
            var y = 2;
            var expected = 7;

            //Act
            var sum = x + y;

            //Assert
            Assert.Equal(expected, sum);

        }
    }
}
