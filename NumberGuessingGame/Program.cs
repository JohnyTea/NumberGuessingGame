using Microsoft.Extensions.DependencyInjection;
using NumberGuessingGame.src.ConsoleIO;
using NumberGuessingGame.src.DifficultyLevel;
using NumberGuessingGame.src.Messages;

namespace NumberGuessingGame;

internal class Program
{
	private static void Main(string[] args)
	{
		var services = new ServiceCollection();
		ConfigureServices(services);
		var serviceProvider = services.BuildServiceProvider();

		var game = serviceProvider.GetRequiredService<Game>();
		game.StartGame();
	}
	private static void ConfigureServices(IServiceCollection services)
	{
		_ = services.AddSingleton<Game>();
		_ = services.AddSingleton<IMessagesProvider, MessagesProvider>();
		_ = services.AddSingleton<IUserInputs, UserInputs>();
		_ = services.AddSingleton<IUserOutputs, UserOutputs>();
		_ = services.AddSingleton<IDifficultyProvider, DifficultyProvider>();
		_ = services.AddSingleton<Random>();
	}
}
