using polymer.core.Commanding;
using System;

namespace polymer.specs.core.Commanding.assets
{
	public class FakeCommandResult : ICommandResult
	{
		public Guid AcknowledgementToken { get; set; }
	}
}