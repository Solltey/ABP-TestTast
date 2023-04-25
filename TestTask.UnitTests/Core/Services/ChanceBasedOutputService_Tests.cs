using TestTesk.Application.Services;

namespace TestTask.UnitTests.Core.Services
{
    public class ChanceBasedOutputService_Tests
    {
        [Fact]
        public void GetRandomValue_ReturnsOneOfTheKeys()
        {
            // Arrange
            var pairs = new Dictionary<string, double>
        {
            { "heads", 0.5 },
            { "tails", 0.5 },
        };
            var outputService = new ChanceBasedOutputService();

            // Act
            var result = outputService.GetRandomValue(pairs);

            // Assert
            Assert.Contains(result, pairs.Keys);
        }

        [Fact]
        public void GetRandomValue_ThrowsInvalidOperationException_WhenDictionaryIsEmpty()
        {
            // Arrange
            var pairs = new Dictionary<string, double>();
            var outputService = new ChanceBasedOutputService();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => outputService.GetRandomValue(pairs));
        }

        [Fact]
        public void GetRandomValue_ThrowsInvalidOperationException_WhenProbabilitiesDoNotSumTo1()
        {
            // Arrange
            var pairs = new Dictionary<string, double>
        {
            { "heads", 0.5 },
            { "tails", 0.6 },
        };
            var outputService = new ChanceBasedOutputService();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => outputService.GetRandomValue(pairs));
        }
    }
}
