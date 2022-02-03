using ConsoleToTestCode.Basic;
using System;
using System.Collections.Generic;
using Xunit;

namespace ConsoleToTestCode.TEST.Basic
{

    public class FirstClassTest
    {
        [Fact]
        public void ShouldInstanciateTheClass()
        {
            //Arrange
            var name = "CLASE";
            var firstClass = new FirstClass(name);

            
            //Act
            for (int i = 0; i < 10; i++)
            {
                var rdm = new Random();
                double randonNumber = rdm.Next(1, 100);
               firstClass.AddDoubleList(randonNumber);
            }
             List<double> ListResult = new List<double>();
    
            //Assert
            Assert.Equal(firstClass.name,name);
        }
    }
}
