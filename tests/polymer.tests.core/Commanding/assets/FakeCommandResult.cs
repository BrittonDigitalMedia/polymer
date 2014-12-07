using System;
using NodaTime;
using polymer.core.Commanding;

namespace polymer.tests.core.Commanding.assets
{
	public class FakeCommandResult : ICommandResult
	{
		public Guid UniqueMessageReferenceEcho { get; set; }
		public Guid AcknowledgementToken { get; set; }
		public Instant Timestamp { get; set; }
	}
}