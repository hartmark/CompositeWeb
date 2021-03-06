using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.CompositeWeb.Utility;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Parameters
{
	/// <summary>
	/// Maps <see cref="ParameterAttribute"/> types to their <see cref="IParameterResolver"/> type used to emit IL code for the BuildPlan.
	/// </summary>
	[SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors")]
	public class ParameterResolverMap
	{
		private static Dictionary<Type, IParameterResolver> resolvers;

		[SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
		static ParameterResolverMap()
		{
			resolvers = new Dictionary<Type, IParameterResolver>();
			resolvers[typeof (CreateNewAttribute)] = new CreateNewParameterResolver();
			resolvers[typeof (DependencyAttribute)] = new DependencyParameterResolver();
			resolvers[typeof (ServiceDependencyAttribute)] = new ServiceDependencyParameterResolver();
			resolvers[typeof (StateDependencyAttribute)] = new StateDependencyParameterResolver();
			resolvers[typeof (ProviderDependencyAttribute)] = new ProviderDependencyParameterResolver();
		}

		/// <summary>
		/// Gets the <see cref="IParameterResolver"/> registered for a specific <see cref="ParameterAttribute"/>.
		/// </summary>
		/// <param name="resolutionAttribute">The parameter to get the registered resolver for.</param>
		/// <returns>An instance of <see cref="IParameterResolver"/> used to emit the IL code.</returns>
		public static IParameterResolver GetResolver(ParameterAttribute resolutionAttribute)
		{
			Guard.ArgumentNotNull(resolutionAttribute, "resolutionAttribute");
			return resolvers[resolutionAttribute.GetType()];
		}

		/// <summary>
		/// Adds a <see cref="ParameterResolver"/> used to resolve a specific <see cref="ParameterAttribute"/>.
		/// </summary>
		/// <param name="attributeType">The type, which should be assignable from <see cref="ParameterAttribute"/>.</param>
		/// <param name="parameterResolver">The resolver used to emit the IL code.</param>
		public static void AddResolver(Type attributeType, IParameterResolver parameterResolver)
		{
			Guard.ArgumentNotNull(attributeType, "attributeType");
			Guard.ArgumentNotNull(parameterResolver, "parameterResolver");

			Guard.TypeIsAssignableFromType(typeof (ParameterAttribute), attributeType, "attributeType");

			resolvers[attributeType] = parameterResolver;
		}
	}
}