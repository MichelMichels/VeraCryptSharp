using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VeraCryptSharp;

namespace VeraCryptSharpTests
{
    [TestClass]
    public class VeraCryptArgumentsTests
    {
        [TestMethod]
        public void Init_Test()
        {
            // Arrange

            // Act
            new VeraCryptArguments();

            // Assert
        }

        [TestMethod]
        public void EmptyOptions_Test()
        {
            // Arrange
            var arguments = new VeraCryptArguments();

            // Act
            var output = arguments.ToString();

            // Assert
            Assert.AreEqual(string.Empty, output);
        }

        [TestMethod]
        public void DriveLetter_Test()
        {
            // Arrange
            var arguments = new VeraCryptArguments
            {
                DriveLetter = "X",
            };

            // Act
            var output = arguments.ToString();

            // Assert
            Assert.AreEqual("/letter X", output);
        }

        [TestMethod]
        public void HashAlgorithm_Test()
        {
            // Arrange
            var arguments = new VeraCryptArguments
            {
                HashAlgorithm = VeraCryptSharp.Enums.HashAlgorithm.SHA256,
            };

            // Act
            var output = arguments.ToString();

            // Assert
            Assert.AreEqual("/hash sha256", output);
        }
    }
}
