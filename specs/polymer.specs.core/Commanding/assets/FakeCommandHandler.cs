using polymer.core.Commanding;
using System;

namespace polymer.specs.core.Commanding.assets
{
	public class FakeCommandHandler : ICommandHandler<FakeCommand, FakeCommandResult>
	{
		public string UniqueCode
		{
			get { return "FKE"; }
		}

		public string CommandName
		{
			get { return "FAKE COMMAND"; }
		}



		public FakeCommandResult Handle(FakeCommand command)
		{
			return new FakeCommandResult {AcknowledgementToken = Guid.NewGuid()};
		}

		ICommandResult ICommandHandler.Handle(ICommand command)
		{
			return Handle(command as FakeCommand);
		}
	}
}