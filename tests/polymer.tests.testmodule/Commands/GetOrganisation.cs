using System;
using polymer.core.Commanding;
using polymer.tests.testmodule.DomainObjects;
using ServiceStack;

namespace polymer.tests.testmodule.Commands
{
	[Route("/organisations/{OrganisationId}", "GET,POST", Summary = "gets an organisation")]
	[Route("/organisations/bykey/{Key}", "GET,POST", Summary = "gets an organisation using its unique key")]
	public class GetOrganisation : ICommand<GetOrganisationResult>, IReturn<GetOrganisationResult>
	{
		public string OrganisationId { get; set; }
		public Guid Key { get; set; }
	}

	public class GetOrganisationResult : ICommandResult
	{
		public Organisation Organisation { get; set; }
	}
}