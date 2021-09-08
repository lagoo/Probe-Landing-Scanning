using Console.Entities;
using Console.Enums;
using Console.Interfaces;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ConsoleUnitTests.Entities
{
    public class ProbeUnitTest
    {
        [Fact()]
        public void ToString_ShouldReturnStateOfXasisYasisDirection()
        {
            // Arrange
            Position inital = new(1, 1);
            Position max = new(2, 2);
            List<IProbeCommand> commands = new();

            Probe stu = new(inital, max, WindroseEnum.N, commands);

            // Act
            var result = stu.ToString();

            // Assert
            result.Should().Be("1 1 N");
        }

        [Fact()]
        public void ExecuteCommands_ShouldExecuteAllCommands()
        {
            // Arrange
            Mock<IProbeCommand> moq = new();

            Position inital = new(1, 1);
            Position max = new(2, 2);
            List<IProbeCommand> commands = new() { moq.Object, moq.Object};

            Probe stu = new(inital, max, WindroseEnum.N, commands);

            // Act
            stu.ExecuteCommands();

            // Assert
            moq.Verify(e => e.Execute(stu), Times.Exactly(2));
        }

        [Theory()]
        [InlineData(1, WindroseEnum.E)]
        [InlineData(-1, WindroseEnum.W)]
        public void ChangeDirection_ShouldChangeDirectionWithoutCrossingTheLimit(int value, WindroseEnum expectedResult)
        {
            // Arrange
            Position inital = new(1, 1);
            Position max = new(2, 2);
            List<IProbeCommand> commands = new();

            Probe stu = new(inital, max, WindroseEnum.N, commands);

            // Act
            stu.ChangeDirection(value);

            // Assert
            stu.Direction.Should().Be(expectedResult);
        }

        [Theory()]
        [InlineData(WindroseEnum.N, 1, 1, 2)]
        [InlineData(WindroseEnum.N, 3, 1, 2)]
        [InlineData(WindroseEnum.E, 1, 2, 1)]
        [InlineData(WindroseEnum.E, 3, 2, 1)]
        [InlineData(WindroseEnum.S, 1, 1, 0)]
        [InlineData(WindroseEnum.S, 3, 1, 0)]
        [InlineData(WindroseEnum.W, 1, 0, 1)]
        [InlineData(WindroseEnum.W, 3, 0, 1)]
        public void Move_ShouldIncressOrDecressOneBaseOnTheDirectionWithMaxLimit(WindroseEnum direction, int qtdMove, int xasis, int yasis)
        {
            // Arrange
            Position inital = new(1, 1);
            Position max = new(2, 2);
            List<IProbeCommand> commands = new();

            Probe stu = new(inital, max, direction, commands);

            // Act
            for (int i = 0; i < qtdMove; i++)
            {
                stu.Move();
            }

            // Assert
            stu.XAsis.Should().Be(xasis);
            stu.YAsis.Should().Be(yasis);
        }

        [Fact()]
        public void MarkFlag_ShouldAddMarkFlagWithActualStaus()
        {
            // Arrange
            Position inital = new(1, 1);
            Position max = new(2, 2);
            List<IProbeCommand> commands = new();

            Probe stu = new(inital, max, WindroseEnum.N, commands);

            // Act
            stu.MarkFlag();

            // Assert
            stu.Flags.Should().HaveCount(1);
            stu.Flags.First().Should().Be($"1 1 N");
        }
    }
}
