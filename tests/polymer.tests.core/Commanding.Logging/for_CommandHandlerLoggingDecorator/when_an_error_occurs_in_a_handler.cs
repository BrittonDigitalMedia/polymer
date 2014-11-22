using System;
using Machine.Specifications;
using Moq;
using polymer.core.Commanding;
using polymer.core.Commanding.Logging;
using polymer.tests.core.Commanding.assets;
using It = Machine.Specifications.It;

namespace polymer.tests.core.Commanding.Logging.for_CommandHandlerLoggingDecorator
{
	public class when_an_error_occurs_in_a_handler : given.a_command_logging_record_decorator
	{
		Establish context = () =>
		{
			_mockHandler = new Mock<ICommandHandler<FakeCommand, FakeCommandResult>>();
			_mockHandler.Setup(x => x.Handle(Moq.It.IsAny<ICommand>())).Throws<Exception>();
			_mockHandler.SetupGet(x => x.CommandName).Returns(() => "TEST COMMAND");
			_mockHandler.SetupGet(x => x.UniqueCode).Returns(() => "TST-CDE");
			_decorator = new CommandHandlerLoggingDecorator(_mockHandler.Object, _mockUserSession.Object, _mockLogger.Object);
			_mockLogger.Setup(x => x.LogError(Moq.It.IsAny<CommandLogRecord>())).Verifiable();
			_command = new FakeCommand { Key = Guid.NewGuid() };
		};


		Because of = () => _exception = Catch.Exception(() =>_decorator.Handle(_command));

		It should_fail = () => _exception.ShouldBeOfExactType<CommandException>();
		It should_have_command_name_in_exception_message = () => _exception.Message.ShouldContain("TEST COMMAND");
		It should_have_command_key_in_exception_message = () => _exception.Message.ShouldContain(_command.Key.ToString());
		It should_log_an_error = () => _mockLogger.Verify(x => x.LogError(Moq.It.IsAny<CommandLogRecord>()), Times.Once());

		private static Mock<ICommandHandler<FakeCommand, FakeCommandResult>> _mockHandler;
		private static FakeCommand _command;
		private static Exception _exception;
	}
}