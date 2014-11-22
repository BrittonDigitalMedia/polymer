using ServiceStack.Configuration;
using SimpleInjector;
using System;

namespace polymer.api.servicestack.simpleinjector
{
	public class SimpleInjectorContainerAdapter : IContainerAdapter
	{
		private readonly Container container;

		public SimpleInjectorContainerAdapter(Container container)
		{
			this.container = container;
		}

		public T Resolve<T>()
		{
			return (T) this.container.GetInstance(typeof (T));
		}

		public T TryResolve<T>()
		{
			IServiceProvider provider = this.container;
			object service = provider.GetService(typeof (T));
			return service != null ? (T) service : default(T);
		}
	}
}