using polymer.core.Commanding;
using System;

namespace polymer.orchestration.zeromq
{
	public class ZeroMqCommandRouter : ICommandRouter
	{
		public void Route<TCommand>(TCommand command)
		{
			throw new NotImplementedException("zeromq not fully implemented yet");
		}
	}
}
