using Machine.Specifications;
using polymer.specs.core.Commanding.assets;

namespace polymer.specs.core.Commanding.for_CommandHandler.given
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