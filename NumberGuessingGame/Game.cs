
using NumberGuessingGame.src.ConsoleIO;
using NumberGuessingGame.src.DifficultyLevel;
using NumberGuessingGame.src.Messages;

namespace NumberGuessingGame;

internal class Game
{
	private IMessagesProvider Messages { get; init; }
	private IUserInputs UserInputs { get; init; }
	private IUserOutputs UserOutputs { get; init; }
	private IDifficultyProvider DifficultyProvider { get; init; }
	private Random Random { get; init; }

	public Game(IMessagesProvider messages, IUserInputs userInputs, IUserOutputs userOutputs, IDifficultyProvider difficultyProvider, Random random)
	{
		Messages = messages;
		UserInputs = userInputs;
		UserOutputs = userOutputs;
		DifficultyProvider = difficultyProvider;
		Random = random;
	}

	public void StartGame()
	{
		UserOutputs.WriteLine(Messages.GetWelcomeMessage());
		UserOutputs.WriteLine(Messages.GetRulesMessage());

		var difficultyLevel = DifficultyProvider.SelectDifficultyLevel();
		int attempts = CalculateAttemptsForDifficulty(difficultyLevel);

		PerformGame(attempts);
	}

	private void PerformGame(int attempts)
	{
		UserOutputs.WriteLine(Messages.GetGuessTheNumberMessage());
		int correctNumber = Random.Next(0, 100);

		do
		{
			attempts--;
			int guess = UserInputs.GetUserInputAsInt();
			if (guess == correctNumber)
			{
				UserOutputs.WriteLine(Messages.GetWinningMessage());
				return;
			}
			else if (guess > correctNumber)
			{
				UserOutputs.WriteLine(Messages.GetTooHighGuessMessage());
			}
			else
			{
				UserOutputs.WriteLine(Messages.GetTooLowGuessMessage());
			}
		} while (attempts > 0);

		UserOutputs.WriteLine(Messages.GetLossingMessage(correctNumber));
	}

	private static int CalculateAttemptsForDifficulty(DifficultyLevel difficultyLevel)
	{
		return difficultyLevel switch
		{
			DifficultyLevel.Easy => 15,
			DifficultyLevel.Medium => 10,
			DifficultyLevel.Hard => 7,
			_ => throw new NotSupportedException()
		};
	}
}