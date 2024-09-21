using Moq;
using NumberGuessingGame.src.ConsoleIO;
using NumberGuessingGame.src.DifficultyLevel;
using NumberGuessingGame.src.Messages;
using System.IO;

namespace NumberGuessingGame.Tests;

public class GameTest
{
    private Game Game { get; init; }

    private Mock<IUserOutputs> MockUserOutput  { get; init; }
    private IMessagesProvider MessagesProvider { get; init; }
    private Mock<Random> MockRandom { get; init; }
    private Mock<IDifficultyProvider> MockDifficultyProvider { get; init; }
    private Mock<IUserInputs> MockUserInput { get; init; }


    public GameTest()
    {
        MockUserInput = new();
        MockUserOutput = new();
        MockDifficultyProvider = new();
        MockRandom = new();
        MessagesProvider = new MessagesProvider();
        Game = new(MessagesProvider, MockUserInput.Object, MockUserOutput.Object, MockDifficultyProvider.Object, MockRandom.Object);
    }

    [Fact]
    public void StartGame_DisplaysWelcomeMessageAndRules()
    {
        //Arrange

        //Act
        Game.StartGame();

        //Assert
        MockUserOutput.Verify(userOutput => userOutput.WriteLine(MessagesProvider.GetWelcomeMessage()));
        MockUserOutput.Verify(userOutput => userOutput.WriteLine(MessagesProvider.GetRulesMessage()));
    }

    [Fact]
    public void StartGame_SetsDifficulty()
    {
        //Arrange
        MockDifficultyProvider.Setup(dp => dp.SelectDifficultyLevel()).Returns(DifficultyLevel.Easy);

        //Act
        Game.StartGame();

        //Assert
        MockDifficultyProvider.Verify(dp => dp.SelectDifficultyLevel(), Times.Once);
    }

    [Fact]
    public void StartGame_UserGuessTooHigh_DisplayTooHighMessage()
    {
        //Arrange
        const int CorrectNumber = 13;
        MockDifficultyProvider.Setup(dp => dp.SelectDifficultyLevel()).Returns(DifficultyLevel.Easy);
        MockRandom.Setup(random => random.Next(0, 100)).Returns(CorrectNumber);
        MockUserInput.SetupSequence(userInput => userInput.GetUserInputAsInt())
            .Returns(CorrectNumber+1)
            .Returns(CorrectNumber);
        //Act

        Game.StartGame();

        //Assert
        MockUserOutput.Verify(userOutput => userOutput.WriteLine(MessagesProvider.GetTooHighGuessMessage()));
    }

    [Fact]
    public void StartGame_UserGuessTooLow_DisplayTooLowMessage()
    {
        //Arrange
        const int CorrectNumber = 13;
        MockDifficultyProvider.Setup(dp => dp.SelectDifficultyLevel()).Returns(DifficultyLevel.Easy);
        MockRandom.Setup(random => random.Next(0, 100)).Returns(CorrectNumber);
        MockUserInput.SetupSequence(userInput => userInput.GetUserInputAsInt())
            .Returns(CorrectNumber - 1)
            .Returns(CorrectNumber);
        //Act

        Game.StartGame();

        //Assert
        MockUserOutput.Verify(userOutput => userOutput.WriteLine(MessagesProvider.GetTooLowGuessMessage()));
    }

    [Fact]
    public void StartGame_UserGuessCorrectlyFirstTime_DisplayWinningMessage()
    {
        //Arrange
        const int CorrectNumber = 13;
        MockDifficultyProvider.Setup(dp => dp.SelectDifficultyLevel()).Returns(DifficultyLevel.Easy);
        MockRandom.Setup(random => random.Next(0, 100)).Returns(CorrectNumber);
        MockUserInput.Setup(userInput => userInput.GetUserInputAsInt()).Returns(CorrectNumber);
        //Act

        Game.StartGame();

        //Assert
        MockUserOutput.Verify(userOutput => userOutput.WriteLine(MessagesProvider.GetGuessTheNumberMessage()));
        MockUserOutput.Verify(userOutput => userOutput.WriteLine(MessagesProvider.GetWinningMessage()));
        MockUserOutput.Verify(userOutput => userOutput.WriteLine(MessagesProvider.GetLossingMessage(CorrectNumber)), Times.Never);
    }

    [Fact]
    public void StartGame_UserRunOutOffAttemptsAfter15TriesForEasyDifficulty_DisplayLosingMessage()
    {
        //Arrange
        const int CorrectNumber = 13;
        const int TriesForEasyDifficulty = 15;
        MockDifficultyProvider.Setup(dp => dp.SelectDifficultyLevel()).Returns(DifficultyLevel.Easy);
        MockRandom.Setup(random => random.Next(0, 100)).Returns(CorrectNumber);
        MockUserInput.Setup(userInput => userInput.GetUserInputAsInt()).Returns(CorrectNumber + 1);
        //Act

        Game.StartGame();

        //Assert
        MockUserOutput.Verify(userOutput => userOutput.WriteLine(MessagesProvider.GetLossingMessage(CorrectNumber)));
        MockUserInput.Verify(userInput => userInput.GetUserInputAsInt(), Times.Exactly(TriesForEasyDifficulty));

    }

    [Fact]
    public void StartGame_UserRunOutOffAttemptsAfter10TriesForMediumDifficulty_DisplayLosingMessage()
    {
        //Arrange
        const int CorrectNumber = 13;
        const int TriesForEasyDifficulty = 10;
        MockDifficultyProvider.Setup(dp => dp.SelectDifficultyLevel()).Returns(DifficultyLevel.Medium);
        MockRandom.Setup(random => random.Next(0, 100)).Returns(CorrectNumber);
        MockUserInput.Setup(userInput => userInput.GetUserInputAsInt()).Returns(CorrectNumber + 1);
        //Act

        Game.StartGame();

        //Assert
        MockUserOutput.Verify(userOutput => userOutput.WriteLine(MessagesProvider.GetLossingMessage(CorrectNumber)));
        MockUserInput.Verify(userInput => userInput.GetUserInputAsInt(), Times.Exactly(TriesForEasyDifficulty));

    }

    [Fact]
    public void StartGame_UserRunOutOffAttemptsAfter7TriesFoHardDifficulty_DisplayLosingMessage()
    {
        //Arrange
        const int CorrectNumber = 13;
        const int TriesForEasyDifficulty = 7;
        MockDifficultyProvider.Setup(dp => dp.SelectDifficultyLevel()).Returns(DifficultyLevel.Hard);
        MockRandom.Setup(random => random.Next(0, 100)).Returns(CorrectNumber);
        MockUserInput.Setup(userInput => userInput.GetUserInputAsInt()).Returns(CorrectNumber + 1);
        //Act

        Game.StartGame();

        //Assert
        MockUserOutput.Verify(userOutput => userOutput.WriteLine(MessagesProvider.GetLossingMessage(CorrectNumber)));
        MockUserInput.Verify(userInput => userInput.GetUserInputAsInt(), Times.Exactly(TriesForEasyDifficulty));
    }

    [Fact]
    public void StartGame_ThrowsException_WhenNotSupportedDifficultyLevelIsReturned()
    {
        //Arrange
        MockDifficultyProvider.Setup(dp => dp.SelectDifficultyLevel()).Returns((DifficultyLevel)9999);

        //Act && Assert

        Assert.Throws<NotSupportedException>(() => Game.StartGame());

    }
}
