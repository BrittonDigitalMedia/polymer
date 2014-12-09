using polymer.core.Events;
using SimpleInjector;

namespace polymer.composition.simpleinjector
{
	public class SimpleInjectorEventPublisher : IEventPublisher
	{
		private readonly Container _container;

		public SimpleInjectorEventPublisher(Container container)
		{
			_container = container;
		}

		public void Publish<TEvent>(TEvent thisEvent) where TEvent : IEvent
		{
			_container.GetInstance<IEventHandler<TEvent>>();
		}
	}
}
