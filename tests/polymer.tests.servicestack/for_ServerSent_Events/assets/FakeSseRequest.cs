using ServiceStack;

namespace polymer.tests.servicestack.for_ServerSent_Events.assets
{
	[Route("/sse")]
	public class FakeSseRequest : IReturn<FakeSseResponse>
	{
		public string TestProperty { get; set; }
	}
}