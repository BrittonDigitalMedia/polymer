using Machine.Specifications;
using polymer.tests.core.Commanding.assets;

namespace polymer.tests.core.Commanding.for_CommandHandler.given
{
	public class a_command_handler
	{
		Establish context = () =>
		{
			_commandHandler = new FakeCommandHandler();
		};

		protected static FakeCommandHandler _commandHandler;
	}
}