using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using polymer.core.Composition;
using SimpleInjector;

namespace polymer.composition.simpleinjector
{
	public class SimpleInjectorContainer : IContainer
	{
		private readonly Container _container;

		public SimpleInjectorContainer(Container container)
		{
			_container = container;
		}

		public void Bind<TInterface, TConcreteType>(ObjectLifespan lifespan = ObjectLifespan.Transient)
			where TInterface : class
			where TConcreteType : class, TInterface
		{
			switch (lifespan)
			{
				case ObjectLifespan.Transient:
					_container.Register<TInterface, TConcreteType>(Lifestyle.Transient);
					break;
				case ObjectLifespan.Singleton:
					_container.Register<TInterface, TConcreteType>(Lifestyle.Singleton);
					break;
				default:
					throw new ArgumentOutOfRangeException("lifespan");
			}

		}

		public void Inject<TInterface>(TInterface instance)
			where TInterface : class
		{
			_container.Register(() => instance, Lifestyle.Singleton);
		}

		public void FindAndInjectAll<TInterface>()
		{
			string pluginDirectory = AppDomain.CurrentDomain.BaseDirectory;

			var pluginAssemblies =
				from file in new DirectoryInfo(pluginDirectory).GetFiles()
				where file.Extension.ToLower() == ".dll"
				where file.Name.StartsWith("polymer")
				select Assembly.LoadFile(file.FullName);

			var pluginTypes =
				from assembly in pluginAssemblies
				from type in assembly.GetExportedTypes()
				where typeof(TInterface).IsAssignableFrom(type)
				where !type.IsAbstract
				where !type.IsGenericTypeDefinition
				select type;

			_container.RegisterAll<TInterface>(pluginTypes);
		}

		public T GetInstance<T>() where T : class
		{
			return _container.GetInstance<T>();
		}

		public IEnumerable<T> GetAllInstances<T>() where T : class
		{
			return _container.GetAllInstances<T>();
		}
	}
}