using Machine.Specifications;
using polymer.tests.servicestack.for_Basic_Service_Interactions.assets;
using System;
using System.Globalization;

namespace polymer.tests.servicestack.for_Basic_Service_Interactions
{
	public class when_interacting_with_a_basic_service : given.a_service_stack_host
	{
		Establish context = () =>
		{
			_request = new FakeRequest { TestProperty = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture) };
		};

		Because of = () =>
		{
			_response = _client.Post(_request);
		};



		It should_return_a_response = () => _response.ShouldNotBeNull();
		It should_return_correct_response_with_eho_property = () => _response.TestProperty.ShouldEqual(_request.TestProperty);

		private static FakeRequest _request;
		private static FakeResponse _response;
	}
}