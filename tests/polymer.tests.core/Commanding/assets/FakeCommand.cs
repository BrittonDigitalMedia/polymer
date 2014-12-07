using System;
using polymer.core.Commanding;

namespace polymer.tests.core.Commanding.assets
{
	public class FakeCommand : ICommand<FakeCommandResult>
	{
		public Guid Key { get; set; }
		public Guid UniqueMessageReference { get; set; }
	}
}