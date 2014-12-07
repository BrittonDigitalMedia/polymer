using polymer.core.Commanding;
using polymer.tests.testmodule.DomainObjects;
using ServiceStack;

namespace polymer.tests.testmodule.Commands
{
	[Route("/organisations", "PUT", Summary = "creates a new organisation")]
	public class CreateOrganisation : ICommand<CreateOrganisationResult>, IReturn<CreateOrganisationResult>
	{
		public Organisation Organisation { get; set; }
	}

	public class CreateOrganisationResult : ICommandResult
	{
		public string OrganisationId { get; set; }
	}
}