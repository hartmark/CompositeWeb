using System;
using Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan;

namespace Microsoft.Practices.CompositeWeb.Tests.Mocks.ObjectBuilder.BuildPlan
{
	internal class MockPlanBuilderPolicy : IPlanBuilderPolicy
	{
		private IBuildPlan _buildPlan;

		public MockPlanBuilderPolicy(IBuildPlan builPlan)
		{
			_buildPlan = builPlan;
		}

		#region IPlanBuilderPolicy Members

		public IBuildPlan CreatePlan(Type typeToBuild, string id)
		{
			return _buildPlan;
		}

		#endregion
	}
}