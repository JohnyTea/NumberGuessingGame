using Moq;
using NumberGuessingGame.src.ConsoleIO;
using NumberGuessingGame.src.DifficultyLevel;
using NumberGuessingGame.src.Messages;

namespace NumberGuessingGame.Tests;

public class DifficultyProviderTests
{
    private IDifficultyProvider DifficultyProvider { get; init; }

    private readonly Mock<IUserInputs> mockInputProvider = new();
    private readonly Mock<IUserOutputs> mockOutputProvider = new();
    private readonly Mock<IMessagesProvider> mockMessageProvider = new();

    public DifficultyProviderTests()
    {
        DifficultyProvider = new DifficultyProvider(mockInputProvider.Object, mockOutputProvider.Object, mockMessageProvider.Object);
    }

    [Theory]
    [InlineData(1, DifficultyLevel.Easy)]
    [InlineData(2, DifficultyLevel.Medium)]
    [InlineData(3, DifficultyLevel.Hard)]
    [InlineData(99, DifficultyLevel.Easy)]
    public void DifficultyProvider_ReturnsCorrectDifficultyLevel_WhenUserSends_CorrectInput(int userInput, DifficultyLevel expectedOutput)
    {
        //Arrange
        mockInputProvider.Setup(inputReader => inputReader.GetUserInputAsInt()).Returns(userInput);

        //Act
        var result = DifficultyProvider.GetDifficultyLevel();

        //Assert
        result.Should().Be(expectedOutput);
    }
}
