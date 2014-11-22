using System;
using polymer.core.Commanding;

namespace polymer.tests.core.Commanding.assets
{
	public class FakeCommandResult : ICommandResult
	{
		public Guid AcknowledgementToken { get; set; }
	}
}