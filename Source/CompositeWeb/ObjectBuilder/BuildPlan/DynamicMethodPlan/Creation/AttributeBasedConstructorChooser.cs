using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using Microsoft.Practices.CompositeWeb.Utility;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Creation
{
	/// <summary>
	/// An implementation of IChooseConstructorPolicy that duplicates the usual OB logic:
	/// If only one constructor, choose that, otherwise look for one that has the
	/// InjectionConstructorAttribute on it.
	/// </summary>
	public class AttributeBasedConstructorChooser : IConstructorChooserPolicy
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
			Guard.ArgumentNotNull(t, "AttributeBasedConstructorChooser requires a Type instance.");

			ConstructorInfo[] ctors = t.GetConstructors();
			if (ctors.Length == 1)
			{
				return ctors[0];
			}

			bool foundInjectionConstructor = false;
			ConstructorInfo injectionConstructor = null;

			if (ctors.Length > 0)
			{
				injectionConstructor = ctors[0];
			}

			foreach (ConstructorInfo ctor in ctors)
			{
				if (Attribute.IsDefined(ctor, typeof (InjectionConstructorAttribute)))
				{
					if (foundInjectionConstructor)
					{
						// Multiple injection constructors are an error
						throw new InvalidAttributeException(string.Format(CultureInfo.CurrentCulture,
						                                                  "Type {0} has multiple injection constructors", t));
					}
					injectionConstructor = ctor;
					foundInjectionConstructor = true;
				}
			}

			return injectionConstructor;
		}

		#endregion
	}
}