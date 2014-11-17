using polymer.core.Commanding;
using System;

namespace polymer.specs.core.Commanding.assets
{
	public class FakeCommand : ICommand<FakeCommandResult>
	{
		public Guid Key { get; set; }
	}
}