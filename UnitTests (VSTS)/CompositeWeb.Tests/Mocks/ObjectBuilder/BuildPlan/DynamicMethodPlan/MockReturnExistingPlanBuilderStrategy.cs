using System;
using System.Reflection.Emit;
using Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.Tests.Mocks.ObjectBuilder.BuildPlan.DynamicMethodPlan
{
	internal class MockReturnExistingPlanBuilderStrategy : PlanBuilderStrategy
	{
		private bool _buildUpCalled;

		public bool BuildUpCalled
		{
			get { return _buildUpCalled; }
			set { _buildUpCalled = value; }
		}

		protected override void BuildUp(IBuilderContext context, Type typeToBuild, object existing, string idToBuild,
		                                ILGenerator il)
		{
			_buildUpCalled = true;

			Label done = il.DefineLabel();

			il.Emit(OpCodes.Ldarg_2);
			il.MarkLabel(done);
		}
	}
}