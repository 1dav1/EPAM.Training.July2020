using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace GCDClassLibrary.Tests
{
    public class GCDTests
    {
        private const int MULTIPLIER = 1000;

        [Theory]
        [InlineData(642, 252, 6)]
        [InlineData(252, 105, 21)]
        [InlineData(147, 63, 21)]
        public void CalculateGCD_ForTwoParameters_ShouldReturnCorrectResult(uint number1, uint number2, uint expectedResult)
        {
            // Arrange - Act
            GCDCalculator gcdCalculator = new GCDCalculator();

            // Assert
            gcdCalculator.CalculateGCD(number1, number2)
                .Should()
                .Be(expectedResult);
        }

        [Theory]
        [InlineData(642, 252, 6)]
        [InlineData(252, 105, 21)]
        [InlineData(147, 63, 21)]
        public void CalculateBinaryGCD_ForTwoParameters_ShouldReturnCorrectResult(uint number1, uint number2, uint expectedResult)
        {
            // Arrange - Act
            GCDCalculator gcdCalculator = new GCDCalculator();

            // Assert
            gcdCalculator.CalculateBinaryGCD(out _, number1, number2)
                .Should()
                .Be(expectedResult);
        }

        [Theory]
        [InlineData(642, 252, 6)]
        [InlineData(252, 105, 21)]
        [InlineData(147, 63, 21)]
        public void CalculateGCD_ForTwoParametersWithOutParameter_ShouldReturnCorrectResult(uint number1, uint number2, uint expectedResult)
        {
            // Arrange - Act
            GCDCalculator gcdCalculator = new GCDCalculator();

            // Assert
            gcdCalculator.CalculateGCD(out _, number1, number2)
                .Should()
                .Be(expectedResult);
        }

        [Theory]
        [InlineData(642, 390, 252, 6)]
        [InlineData(252, 147, 105, 21)]
        [InlineData(147, 84, 63, 21)]
        public void CalculateGCD_ForThreeParameters_ShouldReturnCorrectResult(uint number1, uint number2, uint number3, uint expectedResult)
        {
            // Arrange - Act
            GCDCalculator gcdCalculator = new GCDCalculator();

            // Assert
            gcdCalculator.CalculateGCD(number1, number2, number3)
                .Should()
                .Be(expectedResult);
        }

        [Theory]
        [InlineData(12, 10, 9, 3, 1)]
        [InlineData(252, 147, 105, 84, 21)]
        [InlineData(317, 189, 128, 61, 1)]
        public void CalculateGCD_ForFourParameters_ShouldReturnCorrectResult(uint number1, uint number2, uint number3, uint number4, uint expectedResult)
        {
            // Arrange - Act
            GCDCalculator gcdCalculator = new GCDCalculator();

            // Assert
            gcdCalculator.CalculateGCD(number1, number2, number3, number4)
                .Should()
                .Be(expectedResult);
        }

        [Theory]
        [InlineData(2916, 972, 324, 108, 36, 36)]
        [InlineData(176, 165, 154, 143, 132, 11)]
        [InlineData(427, 366, 305, 244, 183, 61)]
        public void CalculateGCD_ForFiveParameters_ShouldReturnCorrectResult(uint number1, uint number2, uint number3, uint number4, uint number5, uint expectedResult)
        {
            // Arrange - Act
            GCDCalculator gcdCalculator = new GCDCalculator();

            // Assert
            gcdCalculator.CalculateGCD(number1, number2, number3, number4, number5)
                .Should()
                .Be(expectedResult);
        }

        [Theory]
        [InlineData(252, 105, 21)]
        public void GetHistogram_AfterTwoWaysCalculation_ShouldReturnCorrectData(uint number1, uint number2, uint expectedResult)
        {
            // Arrange 
            GCDCalculator gcdCalculator = new GCDCalculator();
            double time, timeBin;

            // Act
            uint result = gcdCalculator.CalculateGCD(out time, number1, number2);
            uint binResult = gcdCalculator.CalculateBinaryGCD(out timeBin, number1, number2);
            SortedDictionary<string, double> histogram = gcdCalculator.GetHistogram();

            // Assert
            result.Should().Be(expectedResult);
            binResult.Should().Be(expectedResult);

            histogram
                .Should()
                .NotBeEmpty()
                .And.ContainKeys("GCD", "BinaryGCD");

            (histogram["GCD"] / MULTIPLIER)
                .Should()
                .Equals(time);

            (histogram["BinaryGCD"] / MULTIPLIER)
                .Should()
                .Equals(timeBin);
        }

        [Theory]
        [InlineData(252, 105, 21)]
        public void CalculateGCD_InTwoAlgorythms_ConsumedTimeShouldVary(uint number1, uint number2, uint expectedResult)
        {
            // Arrange 
            GCDCalculator gcdCalculator = new GCDCalculator();
            double time, timeBin;

            // Act
            uint result = gcdCalculator.CalculateGCD(out time, number1, number2);
            uint binResult = gcdCalculator.CalculateBinaryGCD(out timeBin, number1, number2);

            // Assert
            result.Should().Be(expectedResult);
            binResult.Should().Be(result);

            gcdCalculator.GetHistogram()["GCD"]
                .Should()
                .NotBe(gcdCalculator.GetHistogram()["BinaryGCD"]);
        }
    }
}
