using System;
using polymer.core.Commanding;

namespace polymer.tests.core.Commanding.assets
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

	}
}