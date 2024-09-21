using NumberGuessingGame.src.Messages;

namespace NumberGuessingGame.src.ConsoleIO;

internal class UserInputs : IUserInputs
{
    private IMessagesProvider Messages { get; init; }
    private IUserOutputs UserOuputs { get; init; }

    public UserInputs(IMessagesProvider messages, IUserOutputs userOuputs)
    {
        Messages = messages;
        UserOuputs = userOuputs;
    }

    public int GetUserInputAsInt()
    {
        do
        {
            if (int.TryParse(GetUserInput(), out int intInput))
            {
                return intInput;
            }
            else
            {
                UserOuputs.WriteLine(Messages.InvalidInputMustBeNumber());
            }
        }while (true);
    }

    public string? GetUserInput()
    {
        return Console.ReadLine();
    }
}
