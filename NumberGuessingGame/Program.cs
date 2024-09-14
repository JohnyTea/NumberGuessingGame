using Microsoft.Extensions.DependencyInjection;
using NumberGuessingGame.src.Messages;
using static System.Net.Mime.MediaTypeNames;

namespace NumberGuessingGame;

internal class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        services
            .AddSingleton<Executor, Executor>()
            .BuildServiceProvider()
            .GetService<Executor>()
            .Execute();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton<IMessages, Messages>()
            .AddSingleton<Game>();
    }

}

internal class Executor(Game game)
{
    public void Execute()
    {
        game.StartGame();
    }
}
