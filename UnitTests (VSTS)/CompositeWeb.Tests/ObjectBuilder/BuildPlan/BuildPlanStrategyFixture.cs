using System;
using Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan;
using Microsoft.Practices.CompositeWeb.Tests.Mocks;
using Microsoft.Practices.CompositeWeb.Tests.Mocks.ObjectBuilder.BuildPlan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.CompositeWeb.Tests.ObjectBuilder.Strategies
{
	[TestClass]
	public class BuildPlanStrategyFixture
	{
		public BuildPlanStrategyFixture()
		{
		}

		[TestMethod]
		[ExpectedException(typeof (InvalidOperationException))]
		public void CreatingInstanceWithNoBuildPlan()
		{
			MockBuilderContext ctx = BuildContext();

			MockObject i1 = (MockObject) ctx.HeadOfChain.BuildUp(ctx, typeof (MockObject), null, null);
		}

		[TestMethod]
		public void CreatingInstanceGetsProperBuildPlanUsingBuildPlanPolicy()
		{
			MockBuilderContext ctx = BuildContext();
			MockObject expectedObject = new MockObject();

			IBuildPlan buildPlan = new MockBuildPlan(expectedObject);
			IBuildPlanPolicy buildPlanPolicy = new BuildPlanPolicy();
			buildPlanPolicy.Set(typeof (MockObject), buildPlan);
			ctx.Policies.SetDefault<IBuildPlanPolicy>(buildPlanPolicy);

			MockObject i1 = (MockObject) ctx.HeadOfChain.BuildUp(ctx, typeof (MockObject), null, null);

			Assert.IsNotNull(i1);
			Assert.AreSame(expectedObject, i1);
		}

		[TestMethod]
		public void CreatingInstanceCreatedBuildPlanUsingPlanBuilderPolicy()
		{
			MockBuilderContext ctx = BuildContext();
			MockObject expectedObject = new MockObject();

			IBuildPlan buildPlan = new MockBuildPlan(expectedObject);
			IPlanBuilderPolicy planBuilderPolicy = new MockPlanBuilderPolicy(buildPlan);
			ctx.Policies.SetDefault<IPlanBuilderPolicy>(planBuilderPolicy);

			MockObject i1 = (MockObject) ctx.HeadOfChain.BuildUp(ctx, typeof (MockObject), null, null);

			Assert.IsNotNull(i1);
			Assert.AreSame(expectedObject, i1);
		}

		private static MockBuilderContext BuildContext()
		{
			MockBuilderContext ctx = new MockBuilderContext(new BuildPlanStrategy());

			return ctx;
		}

		#region Nested type: MockObject

		private class MockObject
		{
		}

		#endregion
	}
}