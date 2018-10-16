using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Practices.CompositeWeb.Utility;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Creation
{
	/// <summary>
	/// A Default implementation of <see cref="IConstructorChooserPolicy"/>
	/// </summary>
	public class DefaultConstructorChooserPolicy : IConstructorChooserPolicy
	{
		#region IConstructorChooserPolicy Members

		/// <summary>
		/// See <see cref="IConstructorChooserPolicy.ChooseConstructor"/> for more information.
		/// </summary>
		/// <param name="t"> Type to choose a constructor from. </param>
		/// <returns></returns>
		[SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods",
			Justification = "Validated using Guard class")]
		public ConstructorInfo ChooseConstructor(Type t)
		{
			Guard.ArgumentNotNull(t, "DefaultConstructorChooserPolicy requires a Type instance.");

			ConstructorInfo[] ctors = t.GetConstructors();
			if (ctors.Length > 0)
			{
				return ctors[0];
			}

			return t.GetConstructor(new Type[0]);
		}

		#endregion
	}
}