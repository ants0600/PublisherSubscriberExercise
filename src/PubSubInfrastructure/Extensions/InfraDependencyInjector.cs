using Autofac;
using PubSubDomain.Services;
using PubSubInfrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PublisherUi.Extensions
{
	public static class InfraDependencyInjector
	{
		private static readonly ContainerBuilder Builder = new ContainerBuilder();

		private static IContainer _container;

		static InfraDependencyInjector()
		{
			InitializeDependencyInjection();
		}

		/// <summary>
		/// Initialize dependency injection from domain, infra, and executing assembly.
		/// </summary>
		private static void InitializeDependencyInjection()
		{
			////// Usually you're only interested in exposing the type
			////// via its interface:
			////builder.Register<SomeType>().As<IService>();

			////// However, if you want BOTH services (not as common)
			////// you can say so:
			////builder.RegisterType<SomeType>().AsSelf().As<IService>();


			Assembly executingAssembly = GetCurrentAssembly();
			Assembly infraAssembly = GetInfraAssembly();
			Assembly domainAssembly = GetDomainAssembly();
			Builder.RegisterAssemblyTypes(executingAssembly, infraAssembly, domainAssembly)
				.AsSelf().AsImplementedInterfaces();
		}

		private static Assembly GetCurrentAssembly()
		{
			return Assembly.GetExecutingAssembly();
		}

		/// <summary>
		/// Assembly for infra.
		/// The assembly containining concrete classes for service.
		/// </summary>
		private static Assembly GetInfraAssembly()
		{
			return typeof(BaseService).Assembly;
		}

		/// <summary>
		/// Assembly for domain.
		/// The assembly containing interfaces.
		/// </summary>
		private static Assembly GetDomainAssembly()
		{
			return typeof(IService).Assembly;
		}

		public static T Resolve<T>()
		{
			_container = _container ?? Builder.Build();

			// Create the scope, resolve your IService,
			// use it, then dispose of the scope.
			using (var scope = _container.BeginLifetimeScope())
			{
				T value = scope.Resolve<T>();
				return value;
			}
		}
	}
}
