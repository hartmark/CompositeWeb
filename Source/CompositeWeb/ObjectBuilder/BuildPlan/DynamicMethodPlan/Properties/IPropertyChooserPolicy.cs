using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Properties
{
	/// <summary>
	/// Policy used by build plan generator to decide which properties on a type
	/// to do injection on.
	/// </summary>
	public interface IPropertyChooserPolicy : IBuilderPolicy
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		IEnumerable<PropertyInfo> GetInjectionProperties(Type t);
	}
}