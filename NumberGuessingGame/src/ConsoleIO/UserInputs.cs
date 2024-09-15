using NumberGuessingGame.src.Messages;

namespace NumberGuessingGame.src.ConsoleIO;

internal class UserInputs : IUserInputs
{
    private IMessagesProvider Messages { get; init; }
    private IUserOutputs UserOuputs { get; }

    public UserInputs(IMessagesProvider messages, IUserOutputs userOuputs)
    {
        Messages = messages;
        UserOuputs = userOuputs;
    }
    public UserInputs(IMessagesProvider messages)
    {
        Messages = messages;
    }

    public int GetUserInputAsInt()
    {
        while (true)
        {
            try
            {
                if (int.TryParse(GetUserInput(), out int intInput))
                {
                    return intInput;
                }
            }
            catch
            {
                UserOuputs?.WriteLine(Messages.InvalidInputMustBeNumber());
            }
        }
    }

    public string? GetUserInput()
    {
        return Console.ReadLine();
    }
}
