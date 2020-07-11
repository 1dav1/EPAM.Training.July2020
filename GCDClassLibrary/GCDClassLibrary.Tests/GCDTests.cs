using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace GCDClassLibrary.Tests
{
    public class GCDTests
    {
        private const int NUMBER1 = 252;
        private const int NUMBER2 = 105;
        private const int NUMBER3 = 147;
        private const int NUMBER4 = 63;
        private const int NUMBER5 = 642;

        private const int RESULT = 21;
        private const int MULTIPLIER = 1000;

        [Fact]
        public void CalculateGCD_WhenArgumentsAreValid_ShouldReturnCorrectValue()
        {
            // Arrange - Act
            GCDCalculator gcdCalculator = new GCDCalculator();

            // Assert
            gcdCalculator.CalculateGCD(NUMBER1, NUMBER2)
                .Should()
                .Equals(RESULT);

            gcdCalculator.CalculateGCD(NUMBER1, NUMBER2, NUMBER3)
                .Should()
                .Equals(RESULT);

            gcdCalculator.CalculateGCD(NUMBER1, NUMBER2, NUMBER3, NUMBER4)
                .Should()
                .Equals(RESULT);

            gcdCalculator.CalculateGCD(NUMBER1, NUMBER2, NUMBER3, NUMBER4, NUMBER5)
                .Should()
                .Equals(RESULT);

            gcdCalculator.CalculateGCD(out _, NUMBER1, NUMBER2)
                .Should()
                .Equals(RESULT);
        }

        [Fact]
        public void CalculateBinaryGCD_WhenArgumentsAreValid_ShouldReturnCorrectValue()
        {
            // Arrange - Act
            GCDCalculator gcdCalculator = new GCDCalculator();

            // Assert
            gcdCalculator.CalculateBinaryGCD(out _, NUMBER1, NUMBER2)
                .Should()
                .Equals(RESULT);
        }

        //[Fact]
        //public void CalculateGCD_WhenArgumentsAreValid_ShouldOutputCorrectTime()
        //{
        //    // Arrange
        //    GCDCalculator gcdCalculator = new GCDCalculator();
        //    DateTime endTime;
        //    DateTime begTime;

        //    // Act
        //    begTime = DateTime.Now;
        //    _ = gcdCalculator.CalculateGCD(out double time, NUMBER1, NUMBER2);
        //    endTime = DateTime.Now;

        //    // Assert
        //    time
        //        .Should()
        //        .BeApproximately((endTime - begTime).TotalMilliseconds, 0.1f);
        //}

        [Fact]
        public void GetHistogram_ShouldReturnCorrectValue()
        {
            // Arrange 
            GCDCalculator gcdCalculator = new GCDCalculator();
            SortedDictionary<string, double> histogram = new SortedDictionary<string, double>();
            double time, timeBin;

            // Act
            gcdCalculator.CalculateGCD(out time, NUMBER1, NUMBER2);
            gcdCalculator.CalculateBinaryGCD(out timeBin, NUMBER1, NUMBER2);
            histogram = gcdCalculator.GetHistogram();

            // Assert
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
    }
}
