namespace NumberGuessingGame.src.Messages;

public interface IMessagesProvider
{
	string GetDifficultyMenuMessage();
	string GetGuessTheNumberMessage();
	string GetLossingMessage(int correctNumber);
	string GetRulesMessage();
	string GetTooHighGuessMessage();
	string GetTooLowGuessMessage();
	string GetWelcomeMessage();
	string GetWinningMessage();
	string InvalidInputMustBeNumber();
	string PickedEasyDifficulty();
	string PickedHardDifficulty();
	string PickedMediumDifficulty();
}