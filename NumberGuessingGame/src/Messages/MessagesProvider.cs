namespace NumberGuessingGame.src.Messages;

internal class MessagesProvider : IMessagesProvider
{
    string IMessagesProvider.GetRulesMessage()
    {
        return "I'm thinking of a number between 1 and 100! You need to guess it!";
    }

    string IMessagesProvider.PickedEasyDifficulty()
    {
        return "Picked easy difficulty";
    }

    string IMessagesProvider.PickedHardDifficulty()
    {
        return "Picked hard difficulty";
    }

    string IMessagesProvider.PickedMediumDifficulty()
    {
        return "Picked medium difficulty";
    }

    string IMessagesProvider.GetDifficultyMenuMessage()
    {
        return
$@"Please select the difficulty level:
1. Easy (15 chances)
2. Medium (10 chances)
3. Hard (7 chances)";
    }

    string IMessagesProvider.GetWelcomeMessage()
    {
        return $"Welcome in the best guessing game!";
    }

    string IMessagesProvider.InvalidInputMustBeNumber()
    {
        return $"This is invalid input, please provide number this time";
    }

    string IMessagesProvider.GetWinningMessage()
    {
        return $"Good job! You Win!";
    }

    string IMessagesProvider.GetLossingMessage(int correctNumber)
    {
        return $"You lost! Correct number was: {correctNumber}";
    }

    string IMessagesProvider.GetTooHighGuessMessage()
    {
        return $"It is lower number!";
    }

    string IMessagesProvider.GetTooLowGuessMessage()
    {
        return $"It is higher number!";
    }

    string IMessagesProvider.GetGuessTheNumberMessage()
    {
        return $"Guess the number!";
    }
}
