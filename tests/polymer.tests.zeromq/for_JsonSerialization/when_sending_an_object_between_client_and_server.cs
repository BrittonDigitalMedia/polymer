using System;
using System.Collections.Generic;
using System.Diagnostics;
using Machine.Specifications;
using NetMQ;
using polymer.specs.zeromq.for_JsonSerialization.assets;
using ServiceStack;

namespace polymer.specs.zeromq.for_JsonSerialization
{
	public class when_sending_an_object_between_client_and_server
	{
		Establish context = () =>
		{
			_testObject = new FakeEntityForTransport
			{
				Id = "test/1",
				Key = Guid.NewGuid(),
				DoubleProperty = 1999999.99D,
				ListOfStrings = new List<string> {"test1", "test2", "test3"}
			};
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
						client.Send(_testObject.ToJson());

						var objectString = server.ReceiveString();
						_entity = objectString.FromJson<FakeEntityForTransport>();

						server.Send(_entity.ToJson());

						_response = client.ReceiveString();
						_responseEntity = _response.FromJson<FakeEntityForTransport>();
					}
				}
			}
		};

		It should_receive_identical_object_on_server = () => _entity.ShouldBeOfExactType<FakeEntityForTransport>();
		It should_reveive_identical_object_response_from_server = () => _responseEntity.ShouldBeOfExactType<FakeEntityForTransport>();
		It should_have_the_same_id_value = () => _responseEntity.Id.ShouldEqual(_testObject.Id);
		
		private static FakeEntityForTransport _testObject;
		private static FakeEntityForTransport _entity;
		private static string _response;
		private static FakeEntityForTransport _responseEntity;
	}
}