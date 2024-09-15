
using NumberGuessingGame.src.ConsoleIO;
using NumberGuessingGame.src.DifficultyLevel;
using NumberGuessingGame.src.Messages;

namespace NumberGuessingGame;

internal class Game
{
    public Game(IMessagesProvider messages, IUserInputs userInputs, IUserOutputs userOutputs, IDifficultyProvider difficultyProvider, Random random)
    {
        Messages = messages;
        UserInputs = userInputs;
        UserOutputs = userOutputs;
        DifficultyProvider = difficultyProvider;
        Random = random;
    }

    public IMessagesProvider Messages { get; init;  }
    public IUserInputs UserInputs { get; init; }
    public IUserOutputs UserOutputs { get; init; }
    public IDifficultyProvider DifficultyProvider { get; init; }
    public Random Random { get; init; }

    public void StartGame()
    {

    }
}