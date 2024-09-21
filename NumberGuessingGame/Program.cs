using Microsoft.Extensions.DependencyInjection;
using NumberGuessingGame.src.ConsoleIO;
using NumberGuessingGame.src.DifficultyLevel;
using NumberGuessingGame.src.Messages;

namespace NumberGuessingGame;

internal class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();

        var game = serviceProvider.GetRequiredService<Game>();
        game.StartGame();
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<Game>();
        services.AddSingleton<IMessagesProvider, MessagesProvider>();
        services.AddSingleton<IUserInputs, UserInputs>();
        services.AddSingleton<IUserOutputs, UserOutputs>();
        services.AddSingleton<IDifficultyProvider, DifficultyProvider>();
        services.AddSingleton<Random>();
    }

}
