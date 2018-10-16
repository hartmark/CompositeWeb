using System;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.Tests.Mocks.ObjectBuilder
{
	internal class MockCreationStrategy : BuilderStrategy
	{
		public override object BuildUp(IBuilderContext context, Type typeToBuild, object existing, string idToBuild)
		{
			existing = Activator.CreateInstance(typeToBuild);
			return base.BuildUp(context, typeToBuild, existing, idToBuild);
		}
	}
}