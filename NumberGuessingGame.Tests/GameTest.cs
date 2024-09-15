using Moq;
using NumberGuessingGame.src.ConsoleIO;
using NumberGuessingGame.src.DifficultyLevel;
using NumberGuessingGame.src.Messages;

namespace NumberGuessingGame.Tests;

internal class GameTest
{
    private Game Game { get; init; }

    private readonly Mock<IUserInputs> mockInputProvider = new();
    private readonly Mock<IUserOutputs> mockOutputProvider = new();
    private readonly Mock<IDifficultyProvider> mockDifficultyProvider = new();
    private readonly Mock<Random> mockRandom = new();

    public GameTest()
    {
        Game = new(new MessagesProvider(), mockInputProvider.Object, mockOutputProvider.Object, mockDifficultyProvider.Object, mockRandom.Object);
    }


}
