using System;
using System.Reflection;
using Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Creation;

namespace Microsoft.Practices.CompositeWeb.Tests.Mocks.ObjectBuilder.BuildPlan.DynamicMethodPlan.Creation
{
	internal class MockReturnNullConstructor : IConstructorChooserPolicy
	{
		#region IConstructorChooserPolicy Members

		public ConstructorInfo ChooseConstructor(Type t)
		{
			return null;
		}

		#endregion
	}
}