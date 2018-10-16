using Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan;
using Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan;
using Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Creation;
using Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Properties;
using Microsoft.Practices.CompositeWeb.Tests.Mocks;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.CompositeWeb.Tests.ObjectBuilder.BuildPlan.DynamicMethodPlan.Properties
{
	[TestClass]
	public class SetPropertiesStrategyFixture
	{
		public SetPropertiesStrategyFixture()
		{
		}

		[TestMethod]
		public void BuildUpDefaultPropertyChooserSetPublicProperties()
		{
			MockBuilderContext ctx = BuildContext();
			TestableRootCompositionContainer compositionContainer = new TestableRootCompositionContainer();
			ctx.Locator.Add(new DependencyResolutionLocatorKey(typeof (CompositionContainer), null), compositionContainer);
			MockDependentObject serviceDependency =
				compositionContainer.Services.AddNew<MockDependentObject, IMockDependentObject>();

			MockObject mockInstance = new MockObject();
			mockInstance = (MockObject) ctx.HeadOfChain.BuildUp(ctx, typeof (MockObject), null, null);

			Assert.IsNotNull(mockInstance.CreateNewProperty);
			Assert.AreSame(serviceDependency, mockInstance.ServiceDependencyProperty);
			Assert.IsNull(mockInstance.InternalProperty);
		}

		[TestMethod]
		public void BuildUpAttributePropChooserSetPropertiesWithInheritedParameterAttributes()
		{
			PolicyList policies = new PolicyList();
			policies.SetDefault<IPropertyChooserPolicy>(new AttributeBasedPropertyChooser());

			MockBuilderContext ctx = BuildContext(policies);
			TestableRootCompositionContainer compositionContainer = new TestableRootCompositionContainer();
			ctx.Locator.Add(new DependencyResolutionLocatorKey(typeof (CompositionContainer), null), compositionContainer);
			MockDependentObject serviceDependency =
				compositionContainer.Services.AddNew<MockDependentObject, IMockDependentObject>();

			MockObject mockInstance = new MockObject();
			mockInstance = (MockObject) ctx.HeadOfChain.BuildUp(ctx, typeof (MockObject), null, null);

			Assert.IsNotNull(mockInstance.CreateNewProperty);
			Assert.AreSame(serviceDependency, mockInstance.ServiceDependencyProperty);
			Assert.IsNull(mockInstance.InternalProperty);
		}

		private static MockBuilderContext BuildContext()
		{
			return BuildContext(new PolicyList());
		}

		private static MockBuilderContext BuildContext(PolicyList innerPolicies)
		{
			MockBuilderContext ctx = new MockBuilderContext(new BuildPlanStrategy());

			ctx.Policies.SetDefault<IPlanBuilderPolicy>(CreatePlanBuilder(innerPolicies));

			return ctx;
		}

		private static IPlanBuilderPolicy CreatePlanBuilder(PolicyList innerPolicies)
		{
			BuilderStrategyChain chain = new BuilderStrategyChain();
			chain.Add(new CallConstructorStrategy());
			chain.Add(new SetPropertiesStrategy());

			return new DynamicMethodPlanBuilderPolicy(chain, innerPolicies);
		}

		#region Nested type: IMockDependentObject

		public interface IMockDependentObject
		{
		}

		#endregion

		#region Nested type: MockCreateNewDependingObject

		private class MockCreateNewDependingObject
		{
			public object DependentObject;

			public MockCreateNewDependingObject([CreateNew] MockDependentObject dependentObject)
			{
				DependentObject = dependentObject;
			}
		}

		#endregion

		#region Nested type: MockDependentObject

		public class MockDependentObject : IMockDependentObject
		{
		}

		#endregion

		#region Nested type: MockObject

		public class MockObject
		{
			public object CreateNewProperty;
			public object InternalProperty;
			public object ServiceDependencyProperty;

			[CreateNew]
			public MockDependentObject CreateNew
			{
				set { CreateNewProperty = value; }
			}

			[ServiceDependency(Type = typeof (IMockDependentObject))]
			public IMockDependentObject ServiceDependency
			{
				set { ServiceDependencyProperty = value; }
			}

			internal MockDependentObject Internal
			{
				set { InternalProperty = value; }
			}
		}

		#endregion
	}
}