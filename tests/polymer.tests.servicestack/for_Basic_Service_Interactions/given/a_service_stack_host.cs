using Funq;
using Machine.Specifications;
using polymer.api.servicestack;
using polymer.api.servicestack.simpleinjector;
using polymer.tests.servicestack.for_Basic_Service_Interactions.assets;
using ServiceStack;

namespace polymer.tests.servicestack.for_Basic_Service_Interactions.given
{
	public class a_service_stack_host
	{
		Establish context = () =>
		{
			var container = new SimpleInjector.Container();
			_appHost = new PolymerAppHost("Polymer API", typeof(FakeService).Assembly);
			_appHost.Container.Adapter = new SimpleInjectorContainerAdapter(container);
			_appHost.Init();
			_container = _appHost.Container;
			_appHost.Start("http://localhost:54321/");
			_client = new JsonServiceClient("http://localhost:54321/");
		};

		Cleanup cu = () =>
		{
			_appHost.Dispose();
		};

		protected static ServiceStackHost _appHost;
		protected static Container _container;
		protected static JsonServiceClient _client;
	}
}