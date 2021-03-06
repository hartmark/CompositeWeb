using System;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Parameters
{
	/// <summary>
	/// 
	/// </summary>
	public class DependencyParameterResolver : ParameterResolver
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="il"></param>
		/// <param name="paramAttr"></param>
		/// <param name="parameterType"></param>
		public override void EmitParameterResolution(ILGenerator il, ParameterAttribute paramAttr, Type parameterType)
		{
			DependencyAttribute attr = (DependencyAttribute) paramAttr;

			ConstructorInfo dependencyResolverCtor =
				GetConstructor<DependencyResolver>(typeof (IBuilderContext));

			MethodInfo resolve = GetMethodInfo<DependencyResolver>("Resolve",
			                                                       typeof (Type), typeof (Type), typeof (string),
			                                                       typeof (NotPresentBehavior), typeof (SearchMode));

			// Create the dependency resolver object
			// Constructor takes context
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Newobj, dependencyResolverCtor);

			// Call frame for call to .Resolve

			// Actual parameter type
			EmitLoadType(il, parameterType);

			// Type to create
			if (attr.CreateType != null)
			{
				EmitLoadType(il, attr.CreateType);
			}
			else
			{
				il.Emit(OpCodes.Ldnull);
			}

			// id
			if (attr.Name != null)
			{
				il.Emit(OpCodes.Ldstr, attr.Name);
			}
			else
			{
				il.Emit(OpCodes.Ldnull);
			}

			// NotPresentBehavior
			il.Emit(OpCodes.Ldc_I4, (int) attr.NotPresentBehavior);

			// SearchMode
			il.Emit(OpCodes.Ldc_I4, (int) attr.SearchMode);

			// And call it
			il.EmitCall(OpCodes.Call, resolve, null);
		}
	}
}