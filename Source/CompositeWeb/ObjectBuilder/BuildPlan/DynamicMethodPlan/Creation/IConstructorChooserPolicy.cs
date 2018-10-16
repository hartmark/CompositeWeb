using System;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Creation
{
	/// <summary>
	/// Interface defining the policy used to determine which constructor to use.
	/// </summary>
	public interface IConstructorChooserPolicy : IBuilderPolicy
	{
		/// <summary>
		/// Determines a single constructor from a given Type.
		/// </summary>
		/// <param name="t"> Type to choose a constructor from.</param>
		/// <returns> The choosen constructor.</returns>
		ConstructorInfo ChooseConstructor(Type t);
	}
}