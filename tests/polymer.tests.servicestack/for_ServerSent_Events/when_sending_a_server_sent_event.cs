using System.Threading;
using Machine.Specifications;
using polymer.tests.servicestack.for_ServerSent_Events.assets;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace polymer.tests.servicestack.for_ServerSent_Events
{
	public class when_sending_a_server_sent_event : given.a_service_stack_host
	{
		Establish context = () =>
		{
			_sseRequest = new FakeSseRequest { TestProperty = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture) };
			ServerEventConnect connectMsg = null;
			_msgs = new List<ServerEventMessage>();
			_commands = new List<ServerEventMessage>();
			_errors = new List<Exception>();

			_eventListener = new ServerEventsClient("http://localhost:54321", channel: "test")
			{
				OnConnect = e => connectMsg = e,
				OnCommand = _commands.Add,
				OnMessage = _msgs.Add,
				OnException = _errors.Add,
			}.Start();
		};

		Because of = () =>
		{
			_sseResponse = _client.Post(_sseRequest);
			Thread.Sleep(1000);

		};

		private Cleanup cu = () =>
		{
			_eventListener.Stop();
			_eventListener.Dispose();
		};

		It should_return_a_response = () => _sseResponse.ShouldNotBeNull();
		It should_return_correct_response_with_eho_property = () => _sseResponse.TestProperty.ShouldEqual(_sseRequest.TestProperty);
		It should_receive_server_sent_event = () => _msgs.Count.ShouldBeGreaterThan(0);

		private static FakeSseRequest _sseRequest;
		private static FakeSseResponse _sseResponse;
		private static ServerEventsClient _eventListener;
		private static List<ServerEventMessage> _msgs;
		private static List<ServerEventMessage> _commands;
		private static List<Exception> _errors;
	}
}