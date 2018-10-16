using System;
using Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.Tests.Mocks.ObjectBuilder.BuildPlan
{
	internal class MockBuildPlan : IBuildPlan
	{
		private object _builtObject;

		public MockBuildPlan(object builtObject)
		{
			_builtObject = builtObject;
		}

		#region IBuildPlan Members

		public object BuildUp(IBuilderContext context, Type typeToBuild, object existing, string id)
		{
			return _builtObject;
		}

		#endregion
	}
}