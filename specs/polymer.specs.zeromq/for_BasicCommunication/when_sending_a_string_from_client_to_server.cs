using Machine.Specifications;
using NetMQ;
using System.Diagnostics;

namespace polymer.specs.zeromq.for_BasicCommunication
{
	public class when_sending_a_string_from_client_to_server
	{
		Establish context = () =>
		{
			_requestMessage = "test_request";
			_responseMessage = "test_response";
			_response = string.Empty;
			_request = string.Empty;
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
						client.Send(_requestMessage);

						_request = server.ReceiveString();
						Debug.WriteLine("From Client: {0}", _request);
						server.Send(_responseMessage);

						_response = client.ReceiveString();
						Debug.WriteLine("From Server: {0}", _response);
					}
				}
			}
		};

		It should_receive_the_request_message_on_the_client = () => _request.ShouldEqual(_requestMessage);
		It should_receive_the_response_message_from_the_server = () => _response.ShouldEqual(_responseMessage);
		private static string _requestMessage;
		private static string _responseMessage;
		private static string _response;
		private static string _request;
	}
}