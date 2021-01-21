using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class ConsoleOutputTests
    {
        [TestMethod]
        public void WriteLine_WithLine_OutputsStandardOut()
        {
            //Arrange
            StringBuilder stringBuilder = new();
            StringWriter stringWriter = new(stringBuilder);

            Console.SetOut(stringWriter);

            ConsoleOutput consoleOutput = new();

            //Act
            consoleOutput.WriteLine("Test");

            //Assert
            Assert.AreEqual("Test" + Environment.NewLine, stringBuilder.ToString());
        }
    }
}
