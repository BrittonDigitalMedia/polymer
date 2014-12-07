using System;
using polymer.core.Commanding;
using polymer.core.Persistence;
using polymer.tests.testmodule.Commands;
using polymer.tests.testmodule.contracts.Repositories;

namespace polymer.tests.testmodule.DomainLogic
{
	public class CreateOrganisationLogic : ICommandHandler<CreateOrganisation, CreateOrganisationResult>
	{
		private readonly IOrganisationRepository _organisationRepository;
		private readonly INoSqlPersistenceManagerProvider _noSqlPersistenceManagerProvider;

		public CreateOrganisationResult Handle(CreateOrganisation command)
		{
			throw new NotImplementedException();
		}

		public CreateOrganisationLogic(
			IOrganisationRepository organisationRepository, 
			INoSqlPersistenceManagerProvider noSqlPersistenceManagerProvider,
			IKeyValueStorePersistenceManager ke
			)
		{
			_organisationRepository = organisationRepository;
			_noSqlPersistenceManagerProvider = noSqlPersistenceManagerProvider;
		}

		public string UniqueCode{get { return "ADD-ORG"; }}

		public string CommandName{ get { return "CREATE ORGANISATION"; }
		}

		public ICommandResult Handle(ICommand command)
		{
			throw new NotImplementedException();
		}
	}
}
