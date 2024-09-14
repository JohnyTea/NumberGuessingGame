
using NumberGuessingGame.src.Messages;

namespace NumberGuessingGame;

internal class Game(IMessages messages)
{
    public IMessages Messages { get; } = messages;

    internal void StartGame()
    {
        string welcomeMessage = Messages.GetWelcomeMessage();

        Console.WriteLine(welcomeMessage);
    }
}