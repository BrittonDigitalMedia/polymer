using Machine.Specifications;
using polymer.composition.simpleinjector;
using polymer.core.Composition;
using SimpleInjector;

namespace polymer.tests.simpleinjector.for_SimpleInjectorContainer.given
{
	public class a_composed_container
	{
		Establish context = () =>
		{
			_simpleInjectorContainer = new Container();
			_container = new SimpleInjectorContainer(_simpleInjectorContainer);
		};

		protected static IContainer _container;
		protected static Container _simpleInjectorContainer;
	}
}