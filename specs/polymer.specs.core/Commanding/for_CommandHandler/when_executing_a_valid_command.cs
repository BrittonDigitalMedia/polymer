﻿using Machine.Specifications;
using polymer.specs.core.Commanding.assets;
using System;

namespace polymer.specs.core.Commanding.for_CommandHandler
{
	public class when_executing_a_valid_command : given.a_command_handler
	{
		Establish context = () =>
		{
			_command = new FakeCommand { Key = Guid.NewGuid() };
		};

		Because of = () => _result = _commandHandler.Handle(_command);

		It should_not_return_null_result = () => _result.ShouldNotBeNull();

		private static FakeCommand _command;
		private static FakeCommandResult _result;
	}
}