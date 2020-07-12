using ShapeLibrary;
using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace ReaderLibrary.Tests
{
    public class ReaderTests
    {
        List<Shape> shapes = new List<Shape>
        {
            new Triangle
            {
                Side1 = 10,
                Side2 = 10,
                Side3 = 20,
            },
            new Triangle
            {
                Side1 = 18,
                Side2 = 30,
                Side3 = 24,
            },
            new Rectangle
            {
                Height = 5,
                Width = 10,
            },
            new Circle
            {
                Radius = 20,
            },
            new Pentagon
            {
                Side = 15,
            },
        };

        [Theory]
        [InlineData(10, 10, 20)]
        public void GetEqualShapes_IfEqualShapePassed_ShouldReturnNotEmptyCollection(double side1, double side2, double side3)
        {
            // Arrange
            Reader reader = new Reader();
            reader.AddShapes(shapes);

            Triangle triangle = new Triangle
            {
                Side1 = side1,
                Side2 = side2,
                Side3 = side3,
            };

            // Act
            List<Shape> result = reader.GetEqualShapes(triangle);

            // Assert
            result.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData(30, 10, 20)]
        public void GetEqualShapes_IfNotEqualShapePassed_ShouldReturnEmptyCollection(double side1, double side2, double side3)
        {
            // Arrange
            Reader reader = new Reader();
            reader.AddShapes(shapes);

            Triangle triangle = new Triangle
            {
                Side1 = side1,
                Side2 = side2,
                Side3 = side3,
            };

            // Act
            List<Shape> result = reader.GetEqualShapes(triangle);

            // Assert
            result.Should().BeEmpty();
        }
    }
}
