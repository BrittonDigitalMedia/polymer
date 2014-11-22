using System;
using Machine.Specifications;
using Moq;
using polymer.core.Commanding.Logging;
using polymer.core.Logging;
using polymer.core.Security;
using polymer.tests.core.Commanding.assets;

namespace polymer.tests.core.Commanding.Logging.for_CommandHandlerLoggingDecorator.given
{
	public class a_command_logging_record_decorator
	{
		Establish context = () =>
		{
			_testGuid = new Guid("{55D73ECE-C262-474C-8A6E-7C2D4ADED57A}");
			_commandResult = new FakeCommandResult { AcknowledgementToken = _testGuid };
			_handler = new FakeCommandHandler();
			_mockUserSession = new Mock<IUserSession>();
			_mockLogger = new Mock<ILogger>();


		};

		protected static Mock<IUserSession> _mockUserSession;
		protected static Mock<ILogger> _mockLogger;
		protected static CommandHandlerLoggingDecorator _decorator;
		protected static Guid _testGuid;
		protected static FakeCommandHandler _handler;
		private static FakeCommandResult _commandResult;
	}
}