using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Properties
{
	/// <summary>
	/// 
	/// </summary>
	public class AttributeBasedPropertyChooser : IPropertyChooserPolicy
	{
		#region IPropertyChooserPolicy Members

		/// <summary>
		/// 
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		public IEnumerable<PropertyInfo> GetInjectionProperties(Type t)
		{
			foreach (PropertyInfo prop in t.GetProperties())
			{
				if (Attribute.IsDefined(prop, typeof (ParameterAttribute)))
				{
					yield return prop;
				}
			}
		}

		#endregion
	}
}