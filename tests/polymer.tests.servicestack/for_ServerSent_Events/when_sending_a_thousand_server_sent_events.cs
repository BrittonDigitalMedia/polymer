using System;
using System.Collections.Generic;
using System.Diagnostics;
using Machine.Specifications;
using polymer.tests.servicestack.for_ServerSent_Events.assets;
using ServiceStack;

namespace polymer.tests.servicestack.for_ServerSent_Events
{
	public class when_sending_a_thousand_server_sent_events : given.a_service_stack_host
	{
		Establish context = () =>
		{

			ServerEventConnect connectMsg = null;
			_msgs = new List<ServerEventMessage>();
			_commands = new List<ServerEventMessage>();
			_errors = new List<Exception>();

			_eventListener = new ServerEventsClient("http://localhost:54321/event-stream", "test")
			{
				OnConnect = e => connectMsg = e,
				OnCommand = _commands.Add,
				OnMessage = _msgs.Add,
				OnException = _errors.Add,
			}.Start();
		};

		Because of = () =>
		{
			_stopWatch = Stopwatch.StartNew();
			for (int i = 1; i < 1001; i++)
			{
				_sseRequest = new FakeSseRequest { TestProperty = string.Format("Msg-{0}", i) };
				_sseResponse = _client.Post(_sseRequest);
			}
			_eventListener.WaitForNextMessage();
			_stopWatch.Stop();
		};

		It should_receive_server_sent_event = () => _msgs.Count.ShouldEqual(1000);
		It should_happen_in_under_3_seconds = () => _stopWatch.ElapsedMilliseconds.ShouldBeLessThan(3000);

		private static FakeSseRequest _sseRequest;
		private static FakeSseResponse _sseResponse;
		private static ServerEventsClient _eventListener;
		private static List<ServerEventMessage> _msgs;
		private static List<ServerEventMessage> _commands;
		private static List<Exception> _errors;
		private static Stopwatch _stopWatch;
	}
}