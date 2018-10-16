using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Properties
{
	/// <summary>
	/// 
	/// </summary>
	public class DefaultPropertyChooserPolicy : IPropertyChooserPolicy
	{
		#region IPropertyChooserPolicy Members

		/// <summary>
		/// 
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		public IEnumerable<PropertyInfo> GetInjectionProperties(Type t)
		{
			foreach (PropertyInfo prop in t.GetProperties(BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.Instance)
				)
			{
				yield return prop;
			}
		}

		#endregion
	}
}