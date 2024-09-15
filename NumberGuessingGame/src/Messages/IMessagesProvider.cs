namespace NumberGuessingGame.src.Messages;

public interface IMessagesProvider
{
    string GetDifficultyMenuMessage();
    string GetWelcomeMessage();
    string InvalidInputMustBeNumber();
    string PickedEasyDifficulty();
    string PickedHardDifficulty();
    string PickedMediumDifficulty();
}