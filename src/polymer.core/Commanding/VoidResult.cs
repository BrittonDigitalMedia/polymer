using System;

namespace polymer.core.Commanding
{
	public class VoidResult : ICommandResult
	{
		public Guid AcknowledgementToken { get; set; }
	}
}