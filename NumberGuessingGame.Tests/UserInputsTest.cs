using Moq;
using NumberGuessingGame.src.ConsoleIO;
using NumberGuessingGame.src.Messages;

namespace NumberGuessingGame.Tests;

public class UserInputsTest
{
	private UserInputs UserInputs { get; init; }
	private IMessagesProvider MessageProvider { get; init; }
	private Mock<IUserOutputs> MockUserOutputs { get; init; }

	public UserInputsTest()
	{
		MessageProvider = new MessagesProvider();
		MockUserOutputs = new();
		UserInputs = new UserInputs(MessageProvider, MockUserOutputs.Object);
	}

	[Theory]
	[InlineData("ala")]
	[InlineData("3")]
	[InlineData("30")]
	[InlineData("-15")]
	[InlineData("asdjbn.asd")]
	public void GetUserInput_ReturnsInput(string input)
	{
		//Arrange
		Console.SetIn(new StringReader(input));

		//Act
		string? userInput = UserInputs.GetUserInput();

		//Assert
		_ = userInput.Should().Be(input);
	}

	[Theory]
	[InlineData(3)]
	[InlineData(30)]
	[InlineData(-15)]
	[InlineData(0)]
	public void GetUserInputAsInt_ValidInput_ReturnsInt(int input)
	{
		//Arrange
		Console.SetIn(new StringReader(input.ToString()));

		//Act
		int userInput = UserInputs.GetUserInputAsInt();

		//Assert
		_ = userInput.Should().Be(input);
	}

	[Theory]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData(",")]
	[InlineData("23asd")]
	public void GetUserInputAsInt_InvalidInput_ReturnsInt(string invalidInput)
	{
		//Arrange
		int validInput = 9;
		string invalidInputFollowedByValidInput = $"{invalidInput}\n{validInput}\n";
		Console.SetIn(new StringReader(invalidInputFollowedByValidInput));

		//Act
		int userInput = UserInputs.GetUserInputAsInt();

		//Assert
		_ = userInput.Should().Be(validInput);
		MockUserOutputs.Verify(userOutputs => userOutputs.WriteLine(MessageProvider.InvalidInputMustBeNumber()), Times.Once);
	}
}
