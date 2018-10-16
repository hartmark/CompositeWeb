using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Method
{
	/// <summary>
	/// 
	/// </summary>
	public class AttributeBasedMethodChooser : IMethodChooserPolicy
	{
		#region IMethodChooserPolicy Members

		/// <summary>
		/// 
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		public IEnumerable<MethodInfo> GetMethods(Type t)
		{
			foreach (MethodInfo method in t.GetMethods(BindingFlags.Instance | BindingFlags.Public))
			{
				if (Attribute.IsDefined(method, typeof (InjectionMethodAttribute)))
				{
					yield return method;
				}
			}
		}

		#endregion
	}
}