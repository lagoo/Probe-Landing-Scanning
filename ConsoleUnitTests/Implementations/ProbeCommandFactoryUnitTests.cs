using Console.Implementations;
using FluentAssertions;
using System;
using Xunit;

namespace ConsoleUnitTests.Implementations
{
    public class ProbeCommandFactoryUnitTests
    {
        [Theory()]
        [InlineData('L')]
        [InlineData('R')]
        public void Create_DirectionChange_ShouldReturnChangeDirectionCommand(char action)
        {
            // Arrange
            ProbeCommandFactory stu = new();

            // Act
            var result = stu.Create(action);

            // Assert
            result.Should().BeOfType<ChangeDirectionCommand>();
        }

        [Fact()]
        public void Create_MoveOnDirection_ShouldReturnMoveOnDirectionCommand()
        {
            // Arrange
            ProbeCommandFactory stu = new();

            // Act
            var result = stu.Create('M');

            // Assert
            result.Should().BeOfType<MoveOnDirectionCommand>();
        }


        [Fact()]
        public void Create_FlagOnDirection_ShouldReturnFlagDirectionCommand()
        {
            // Arrange
            ProbeCommandFactory stu = new();

            // Act
            var result = stu.Create('F');

            // Assert
            result.Should().BeOfType<FlagDirectionCommand>();
        }


        [Fact()]
        public void Create_InvalidAction_ShouldThrowNotImplementedException()
        {
            // Arrange
            ProbeCommandFactory stu = new();

            // Act & Assert
            Assert.Throws<NotImplementedException>(() => stu.Create('A'));
        }
    }
}
