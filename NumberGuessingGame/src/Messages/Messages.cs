namespace NumberGuessingGame.src.Messages;

internal class Messages : IMessages
{
    string IMessages.GetWelcomeMessage()
    {
        return $"Welcome in the best guessing game!";
    }
}
