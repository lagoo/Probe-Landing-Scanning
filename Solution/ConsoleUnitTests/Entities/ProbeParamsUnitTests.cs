using Console.Entities;
using Console.Enums;
using FluentAssertions;
using System;
using Xunit;

namespace ConsoleUnitTests.Entities
{
    public class ProbeParamsUnitTests
    {
        [Theory()]
        [InlineData('N', WindroseEnum.N)]
        [InlineData('E', WindroseEnum.E)]
        [InlineData('S', WindroseEnum.S)]
        [InlineData('W', WindroseEnum.W)]
        public void Ctor_ValidData_ShouldCreateWithValidDirection(char direction, WindroseEnum windrose)
        {
            // Arrange
            Position inital = new(1, 1);

            // Act
            ProbeParams stu = new(inital, direction);

            // Assert
            stu.Direction.Should().Be(windrose);
        }

        [Fact()]
        public void Ctor_InValidData_ShouldThrowException()
        {
            // Arrange
            Position inital = new(1, 1);

            // Act & Assert
            Assert.Throws<NotImplementedException>(() => new ProbeParams(inital, 'A'));
        }
    }
}
