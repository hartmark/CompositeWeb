using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Method
{
	/// <summary>
	/// 
	/// </summary>
	public interface IMethodChooserPolicy : IBuilderPolicy
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		IEnumerable<MethodInfo> GetMethods(Type t);
	}
}