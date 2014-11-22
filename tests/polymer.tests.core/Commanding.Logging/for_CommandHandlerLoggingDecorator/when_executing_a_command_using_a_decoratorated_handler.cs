using System;
using Machine.Specifications;
using Moq;
using polymer.core.Commanding;
using polymer.core.Commanding.Logging;
using polymer.tests.core.Commanding.assets;
using It = Machine.Specifications.It;

namespace polymer.tests.core.Commanding.Logging.for_CommandHandlerLoggingDecorator
{
	public class when_executing_a_command_using_a_decoratorated_handler : given.a_command_logging_record_decorator
	{
		Establish context = () =>
		{
			_decorator = new CommandHandlerLoggingDecorator(_handler, _mockUserSession.Object, _mockLogger.Object);
			_mockLogger.Setup(x => x.LogInfo(Moq.It.IsAny<CommandLogRecord>())).Verifiable();
			_command = new FakeCommand { Key = Guid.NewGuid() };
		};

		Because of = () => _result = _decorator.Handle(_command);

		It should_not_return_null_result = () => _result.ShouldNotBeNull();
		It should_return_a_result_of_correct_type = () => _result.ShouldBeOfExactType<FakeCommandResult>();
		It should_log_command_info = () => _mockLogger.Verify(x => x.LogInfo(Moq.It.IsAny<CommandLogRecord>()), Times.Once);
		protected static FakeCommand _command;
		protected static ICommandResult _result;
	}
}