using System.Collections.Generic;
using System.Diagnostics;
using Machine.Specifications;
using NetMQ;

namespace polymer.specs.zeromq.for_BasicCommunication
{
	public class when_sending_a_hundred_thousand_strings_from_client_to_server
	{
		Establish context = () =>
		{
			_message = "message_{0}";
			_messagesReceivedAtServer = new List<string>();
			_responsesReceivedByClient = new List<string>();
		};
		Because of = () =>
		{
			using (var ctx = NetMQContext.Create())
			{
				using (var server = ctx.CreateResponseSocket())
				{
					server.Bind("tcp://127.0.0.1:5556");
					using (var client = ctx.CreateRequestSocket())
					{
						client.Connect("tcp://127.0.0.1:5556");
						_stopwatch = Stopwatch.StartNew();
						for (int i = 1; i < 1001; i++)
						{
							client.Send(string.Format(_message, i));

							_received = server.ReceiveString();
							_messagesReceivedAtServer.Add(_received);
							server.Send(_received);

							_response = client.ReceiveString();
							_responsesReceivedByClient.Add(_response);
						}
						_stopwatch.Stop();
					}
				}
			}
		};

		It should_receive_1000_messages_on_the_server = () => _messagesReceivedAtServer.Count.ShouldEqual(1000);
		It should_receive_1000_responses_on_the_client = () => _responsesReceivedByClient.Count.ShouldEqual(1000);
		It should_complete_in_less_than_a_second = () => _stopwatch.ElapsedMilliseconds.ShouldBeLessThan(1000);

		private static string _message;
		private static string _received;
		private static List<string> _messagesReceivedAtServer;
		private static List<string> _responsesReceivedByClient;
		private static string _response;
		private static Stopwatch _stopwatch;
	}
}