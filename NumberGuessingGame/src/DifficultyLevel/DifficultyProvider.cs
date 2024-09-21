using NumberGuessingGame.src.ConsoleIO;
using NumberGuessingGame.src.Messages;

namespace NumberGuessingGame.src.DifficultyLevel;

internal class DifficultyProvider : IDifficultyProvider
{
    public DifficultyProvider(IUserInputs userInputs, IUserOutputs userOutputs, IMessagesProvider messagesProvider)
    {
        UserInputs = userInputs;
        UserOutputs = userOutputs;
        MessagesProvider = messagesProvider;
    }

    public IUserInputs UserInputs { get; init; }
    public IUserOutputs UserOutputs { get; init; }
    public IMessagesProvider MessagesProvider { get; init; }

    DifficultyLevel IDifficultyProvider.SelectDifficultyLevel()
    {
        UserOutputs.WriteLine(MessagesProvider.GetDifficultyMenuMessage());
        int userInput = UserInputs.GetUserInputAsInt();
        switch (userInput)
        {
            case 1:
                UserOutputs.WriteLine(MessagesProvider.PickedEasyDifficulty());
                return DifficultyLevel.Easy;
            case 2:
                UserOutputs.WriteLine(MessagesProvider.PickedMediumDifficulty());
                return DifficultyLevel.Medium;
            case 3:
                UserOutputs.WriteLine(MessagesProvider.PickedHardDifficulty());
                return DifficultyLevel.Hard;
            default:
                UserOutputs.WriteLine(MessagesProvider.PickedEasyDifficulty());
                return DifficultyLevel.Easy;
        }
    }
}
