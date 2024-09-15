namespace NumberGuessingGame.src.Messages;

internal class MessagesProvider : IMessagesProvider
{
    public string PickedEasyDifficulty()
    {
        throw new NotImplementedException();
    }

    public string PickedHardDifficulty()
    {
        throw new NotImplementedException();
    }

    public string PickedMediumDifficulty()
    {
        throw new NotImplementedException();
    }

    string IMessagesProvider.GetDifficultyMenuMessage()
    {
        return
$@"Please select the difficulty level:
1. Easy (10 chances)
2. Medium (5 chances)
3. Hard (3 chances)";
    }

    string IMessagesProvider.GetWelcomeMessage()
    {
        return $"Welcome in the best guessing game!";
    }

    string IMessagesProvider.InvalidInputMustBeNumber()
    {
        return $"This is invalid input, please provide number this time";
    }
}
