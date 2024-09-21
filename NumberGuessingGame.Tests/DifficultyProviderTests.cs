using Moq;
using NumberGuessingGame.src.ConsoleIO;
using NumberGuessingGame.src.DifficultyLevel;
using NumberGuessingGame.src.Messages;

namespace NumberGuessingGame.Tests;

public class DifficultyProviderTests
{
    private IDifficultyProvider DifficultyProvider { get; init; }

    private Mock<IUserInputs> MockInputProvider { get; init; }
    private Mock<IUserOutputs> MockOutputProvider { get; init; }
    private IMessagesProvider MessageProvider { get; init; }

    public DifficultyProviderTests()
    {
        MockInputProvider = new Mock<IUserInputs>();
        MockOutputProvider = new Mock<IUserOutputs>();
        MessageProvider = new MessagesProvider();
        DifficultyProvider = new DifficultyProvider(MockInputProvider.Object, MockOutputProvider.Object, MessageProvider);
    }

    [Theory]
    [InlineData(1, DifficultyLevel.Easy)]
    [InlineData(2, DifficultyLevel.Medium)]
    [InlineData(3, DifficultyLevel.Hard)]
    [InlineData(99, DifficultyLevel.Easy)]
    public void DifficultyProvider_ReturnsCorrectDifficultyLevel_WhenUserSends_CorrectInput(int userInput, DifficultyLevel expectedOutput)
    {
        //Arrange
        MockInputProvider.Setup(inputReader => inputReader.GetUserInputAsInt()).Returns(userInput);

        //Act
        var result = DifficultyProvider.SelectDifficultyLevel();

        //Assert
        result.Should().Be(expectedOutput);
    }
}
