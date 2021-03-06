using System;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.Strategies
{
	/// <summary>
	/// 
	/// </summary>
	public class SimplifiedSingletonStrategy : BuilderStrategy
	{
		/// <summary>
		/// Implementation of <see cref="IBuilderStrategy.BuildUp"/>.
		/// </summary>
		/// <param name="context">The build context.</param>
		/// <param name="typeToBuild">The type of the object being built.</param>
		/// <param name="existing">The existing instance of the object.</param>
		/// <param name="idToBuild">The ID of the object being built.</param>
		/// <returns>The built object.</returns>
		public override object BuildUp(IBuilderContext context, Type typeToBuild, object existing, string idToBuild)
		{
			DependencyResolutionLocatorKey key = null;
			ILifetimeContainer lifeTime = GetLifetime(context);

			if (context.Locator != null)
			{
				key = new DependencyResolutionLocatorKey(typeToBuild, idToBuild);
				if (context.Locator.Contains(key, SearchMode.Local))
				{
					return context.Locator.Get(key);
				}
			}

			existing = base.BuildUp(context, typeToBuild, existing, idToBuild);

			if (context.Locator != null && lifeTime != null && IsSingleton(context, key))
			{
				context.Locator.Add(key, existing);
				lifeTime.Add(existing);
			}
			return existing;
		}

		private static bool IsSingleton(IBuilderContext context, DependencyResolutionLocatorKey key)
		{
			ISingletonPolicy policy = context.Policies.Get<ISingletonPolicy>(key.Type, key.ID);
			return policy != null && policy.IsSingleton;
		}

		private static ILifetimeContainer GetLifetime(IBuilderContext context)
		{
			if (context.Locator == null)
			{
				return null;
			}

			return context.Locator.Get<ILifetimeContainer>(typeof (ILifetimeContainer), SearchMode.Local);
		}
	}
}