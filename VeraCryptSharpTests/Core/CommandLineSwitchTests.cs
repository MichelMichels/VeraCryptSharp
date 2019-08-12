using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VeraCryptSharp.Core;

namespace VeraCryptSharpTests.Core
{
    [TestClass]
    public class CommandLineSwitchTests
    {
        private enum TestValue
        {
            Red,
            Green,
            Blue
        }

        [TestMethod]
        public void EmptySwitch_ToString_Test()
        {
            // Arrange
            var cliSwitch = new CommandLineSwitch("/test");

            // Act
            var output = cliSwitch.ToString();

            // Assert
            Assert.AreEqual("/test", output);
        }

        [TestMethod]
        public void StringSwitch_ToString_Test()
        {
            // Arrange
            var cliSwitch = new CommandLineSwitch<string>("/test", "debug");

            // Act
            var output = cliSwitch.ToString();

            // Assert
            Assert.AreEqual("/test debug", output);
        }

        [TestMethod]
        public void EnumSwitch_ToString_Test()
        {
            // Arrange
            var cliSwitch = new CommandLineSwitch<TestValue>("/test", TestValue.Blue);

            // Act
            var output = cliSwitch.ToString();

            // Assert
            Assert.AreEqual("/test Blue", output);
        }

        [TestMethod]
        public void IntSwitch_ToString_Test()
        {
            // Arrange
            var cliSwitch = new CommandLineSwitch<int>("/test", 52);

            // Act
            var output = cliSwitch.ToString();

            // Assert
            Assert.AreEqual("/test 52", output);
        }
    }
}
