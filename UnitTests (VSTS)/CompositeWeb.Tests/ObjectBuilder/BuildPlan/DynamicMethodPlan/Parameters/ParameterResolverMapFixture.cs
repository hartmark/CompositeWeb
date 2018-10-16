using System;
using System.Reflection.Emit;
using Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Parameters;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.CompositeWeb.Tests.ObjectBuilder.BuildPlan.DynamicMethodPlan.Parameters
{
	[TestClass]
	public class ParameterResolverMapFixture
	{
		[TestMethod]
		public void ShouldBeAbleToAddCustomParameterAttribute()
		{
			ParameterResolverMap.AddResolver(typeof (MockParamterAttribute), new MockParameterResolver());

			IParameterResolver resolver = ParameterResolverMap.GetResolver(new MockParamterAttribute());

			Assert.IsNotNull(resolver);
			Assert.IsInstanceOfType(resolver, typeof (MockParameterResolver));
		}

		[TestMethod]
		[ExpectedException(typeof (ArgumentException))]
		public void AddResolverForANonParameterAttributeThrows()
		{
			ParameterResolverMap.AddResolver(typeof (Attribute), new MockParameterResolver());
		}

		[TestMethod]
		[ExpectedException(typeof (ArgumentNullException))]
		public void AddNullResolverThrows()
		{
			ParameterResolverMap.AddResolver(typeof (MockParamterAttribute), null);
		}

		[TestMethod]
		[ExpectedException(typeof (ArgumentNullException))]
		public void GetNullResolverThrows()
		{
			ParameterResolverMap.GetResolver(null);
		}

		#region Nested type: MockParameterResolver

		private class MockParameterResolver : IParameterResolver
		{
			#region IParameterResolver Members

			public void EmitParameterResolution(ILGenerator il, ParameterAttribute paramAttr, Type parameterType)
			{
				throw new NotImplementedException();
			}

			#endregion
		}

		#endregion

		#region Nested type: MockParamterAttribute

		private class MockParamterAttribute : ParameterAttribute
		{
			public override IParameter CreateParameter(Type memberType)
			{
				throw new NotImplementedException();
			}
		}

		#endregion
	}
}