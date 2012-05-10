using Jabbot.Core;
using Jabbot.Core.Models;
using Jabbot.Extensions;
using Moq;
using NUnit.Framework;

namespace ExtensionTests
{
	[TestFixture]
	public class CalculatorSprocketTest
	{
		[SetUp]
		public void SetUp()
		{
			_calculatorSprocket = new CalculatorSprocket();
			_botMock = new Mock<IBot>();
		}

		private CalculatorSprocket _calculatorSprocket;
		private Mock<IBot> _botMock;

		[Test]
		public void AcceptsInfoAndHelpCommand()
		{
			//arrange
			var chatMessage = new ChatMessage(string.Format("{0} {1}", "calc", "info"), "Simon", "jibbr");
			var chatMessage2 = new ChatMessage(string.Format("{0} {1}", "calc", "help"), "Simon", "jibbr");

			//act
			_calculatorSprocket.HandleMessage(_botMock.Object, chatMessage);
			_calculatorSprocket.HandleMessage(_botMock.Object, chatMessage2);

			//assert
			_botMock.Verify(b => b.PrivateReply(It.Is<string>(who => who.Contains("Simon")), It.IsAny<string>()), Times.Exactly(2));
		}

		[Test]
		public void CanCalculateSquareRoot()
		{
			//arrange
			var expression = "sqrt(16)";
			var chatMessage = new ChatMessage(string.Format("{0} {1} {2}", "calc", "expr", expression), "Simon", "jibbr");

			//act
			_calculatorSprocket.HandleMessage(_botMock.Object, chatMessage);

			//assert
			_botMock.Verify(b => b.Send(It.Is<string>(what => what.Equals(string.Format("{0} = {1}", expression, "4"))), It.IsAny<string>()));
		}

		[Test]
		public void CanRequestInValidCalculation()
		{
			//arrange
			var chatMessage = new ChatMessage(string.Format("{0} {1} {2}", "calc", "expr", "2 *"), "Simon", "jibbr");

			//act
			_calculatorSprocket.HandleMessage(_botMock.Object, chatMessage);

			//assert
			_botMock.Verify(b => b.Send(It.Is<string>(what => what.Contains("Sorry")), It.IsAny<string>()));
		}

		[Test]
		public void CanRequestValidCalculation()
		{
			//arrange
			var expression = "2 * 2";
			var chatMessage = new ChatMessage(string.Format("{0} {1} {2}", "calc", "expr", expression), "Simon", "jibbr");

			//act
			_calculatorSprocket.HandleMessage(_botMock.Object, chatMessage);

			//assert
			_botMock.Verify(b => b.Send(It.Is<string>(what => what.Equals(string.Format("{0} = {1}", expression, "4"))), It.IsAny<string>()));
		}
	}
}