using Console.Exceptions;
using Console.Implementations;
using Console.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace ConsoleUnitTests.Implementations
{
    public class FileInputInterpreterUnitTests
    {
        [Fact()]
        public void Ctor_InvalidData_ShouldThrowException()
        {
            // Arrange
            Mock<IDataReader> moqDataReader = new();
            Mock<ICommandFactory> moqCommandFactory = new();

            // Act
            var result = Assert.ThrowsAny<Exception>(() => new FileInputInterpreter(moqDataReader.Object, moqCommandFactory.Object));

            // Assert
            result.Message.Should().Be("Dados insuficientes para gerar as sondas e a posição maxima!");
        }

        [Fact()]
        public void PlatformMaxPosition_InvalidData_ShouldThrowInvalidPlatformMaxPositionException()
        {
            // Arrange
            Mock<IDataReader> moqDataReader = new();
            moqDataReader.Setup(e => e.Read(FileInputInterpreter.fileName)).Returns(new string[] { "1 A", "1 1 N", "MRL" });
            Mock<ICommandFactory> moqCommandFactory = new();

            // Act
            var result = Assert.Throws<InvalidPlatformMaxPositionException>(() => new FileInputInterpreter(moqDataReader.Object, moqCommandFactory.Object));

            // Assert
            result.Message.Should().Be("Não foi possivel determinar tamanho maximo da plataforma!");
        }

        [Fact()]
        public void PlatformMaxPosition_ValidData_ShouldFillPlatformMaxPosition()
        {
            // Arrange
            Mock<IDataReader> moqDataReader = new();
            moqDataReader.Setup(e => e.Read(FileInputInterpreter.fileName)).Returns(new string[] { "1 1", "1 1 N", "MRL" });
            Mock<ICommandFactory> moqCommandFactory = new();

            // Act
            var stu = new FileInputInterpreter(moqDataReader.Object, moqCommandFactory.Object);

            // Assert
            stu.PlatformMaxPosition.xaxis.Should().Be(1);
            stu.PlatformMaxPosition.yaxis.Should().Be(1);
        }

        [Fact()]
        public void ProbesParamns_InvalidData_ShouldThrowInvalidPlatformMaxPositionException()
        {
            // Arrange
            Mock<IDataReader> moqDataReader = new();
            moqDataReader.Setup(e => e.Read(FileInputInterpreter.fileName)).Returns(new string[] { "1 1", "1 A N", "MRL" });
            Mock<ICommandFactory> moqCommandFactory = new();

            // Act
            var result = Assert.Throws<InvalidProbeValuesException>(() => new FileInputInterpreter(moqDataReader.Object, moqCommandFactory.Object));

            // Assert
            result.Message.Should().Be("Não foi possivel converter valores para açãos para a sonda!");
        }

        [Fact()]
        public void ProbesParamns_ValidData_ShouldFillProbesParamns()
        {
            // Arrange
            Mock<IDataReader> moqDataReader = new();
            moqDataReader.Setup(e => e.Read(FileInputInterpreter.fileName)).Returns(new string[] { "1 1", "1 1 N", "MRL" });
            Mock<ICommandFactory> moqCommandFactory = new();

            // Act
            var stu = new FileInputInterpreter(moqDataReader.Object, moqCommandFactory.Object);

            // Assert
            stu.ProbesParamns.Count().Should().Be(1);
        }
    }
}
