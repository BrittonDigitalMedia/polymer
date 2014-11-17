using System.Diagnostics;
using Machine.Specifications;
using NetMQ;
using polymer.specs.zeromq.for_JsonSerialization.assets;
using ServiceStack;
using System;
using System.Collections.Generic;

namespace polymer.specs.zeromq.for_JsonSerialization
{
	public class when_sending_a_hundred_thousand_objects_between_client_and_server
	{
		Establish context = () =>
		{

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
						_serverEntities = new List<FakeEntityForTransport>();
						_clientEntities = new List<FakeEntityForTransport>();

						_stopwatch = Stopwatch.StartNew();
						for (int i = 1; i < 1001; i++)
						{
							_testObject = new FakeEntityForTransport
							{
								Id = string.Format("test/{0}", i),
								Key = Guid.NewGuid(),
								DoubleProperty = 1999999.99D,
								ListOfStrings = new List<string> { "test1", "test2", "test3" }
							};
							client.Send(_testObject.ToJson());
							var objectString = server.ReceiveString();
							var entity = objectString.FromJson<FakeEntityForTransport>();
							_serverEntities.Add(entity);

							server.Send(entity.ToJson());

							var response = client.ReceiveString();
							var responseEntity = response.FromJson<FakeEntityForTransport>();
							_clientEntities.Add(responseEntity);
						}
						_stopwatch.Stop();
					}
				}
			}
		};

		It should_have_a_hundred_thousand_entities_on_the_server = () => _serverEntities.Count.ShouldEqual(1000);
		It should_have_a_hundred_thousand_entities_on_the_client = () => _clientEntities.Count.ShouldEqual(1000);
		It should_should_happen_in_under_a_second = () => _stopwatch.ElapsedMilliseconds.ShouldBeLessThan(1000);

		private static FakeEntityForTransport _testObject;
		private static List<FakeEntityForTransport> _clientEntities;
		private static List<FakeEntityForTransport> _serverEntities;
		private static Stopwatch _stopwatch;
	}
}