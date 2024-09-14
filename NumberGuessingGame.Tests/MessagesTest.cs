
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NumberGuessingGame.src.Messages;
using Xunit.Sdk;

namespace NumberGuessingGame.Tests;

public class MessagesTest
{
    private readonly IMessages messages;

    public MessagesTest()
    {
        messages = new Messages();
    }

    [Fact]
    public void Message_ReturnsWelcomeMessage()
    {
        //Arrange

        //Act
        string message = messages.GetWelcomeMessage();

        //Assert
        message.Should().NotBeNullOrWhiteSpace();
    }
}