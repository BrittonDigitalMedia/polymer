using System;
using NodaTime;

namespace polymer.core.Commanding
{
	public class VoidResult : ICommandResult
	{
		public Guid UniqueMessageReferenceEcho { get; set; }
		public Guid AcknowledgementToken { get; set; }
		public Instant Timestamp { get; set; }
	}
}