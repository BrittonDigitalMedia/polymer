using Machine.Specifications;
using NMoneys;
using polymer.specs.ravendb.for_NMoneys.assets;
using polymer.specs.ravendb.for_Units.Net.given;
using System;

namespace polymer.specs.ravendb.for_NMoneys
{
	public class when_saving_an_entity_with_currencies : a_valid_database_context
	{
		Establish context = () =>
		{
			_entity = new FakeEntityWithCurrencies
			{
				TransactionAmount = new Money(1099.99M, CurrencyIsoCode.ZAR),
				Key = Guid.NewGuid()
			};
		};

		Because of = () =>
		{
			using (var uow = _context.NewSession("TestDatabase"))
			{
				uow.Store(_entity);
				uow.Commit();
			}

			using (var uow = _context.NewSession("TestDatabase"))
			{
				_resultEntity = uow.Get<FakeEntityWithCurrencies>(_entity.Id);
			}

		};

		It should_have_entity_in_database = () => _store.OpenSession("TestDatabase").Load<FakeEntityWithCurrencies>(_entity.Id).ShouldNotBeNull();

		private It should_have_correct_currency_value = () => _resultEntity.TransactionAmount.ShouldEqual(new Money(1099.99M, CurrencyIsoCode.ZAR));
		private static FakeEntityWithCurrencies _entity;
		private static FakeEntityWithCurrencies _resultEntity;
	}
}