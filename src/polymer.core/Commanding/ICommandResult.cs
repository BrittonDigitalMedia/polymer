using System;

namespace polymer.core.Commanding
{
	public interface ICommandResult
	{
		Guid AcknowledgementToken { get; set; }
	}
}