using System;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.Practices.CompositeWeb.Interfaces;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Parameters
{
	/// <summary>
	/// 
	/// </summary>
	public class ServiceDependencyParameterResolver : ParameterResolver
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="il"></param>
		/// <param name="paramAttr"></param>
		/// <param name="parameterType"></param>
		public override void EmitParameterResolution(ILGenerator il, ParameterAttribute paramAttr, Type parameterType)
		{
			ServiceDependencyAttribute attr = (ServiceDependencyAttribute) paramAttr;
			MethodInfo getLocator = GetPropertyGetter<IBuilderContext>("Locator", typeof (IReadWriteLocator));
			MethodInfo getFromLocator = ObtainGetFromLocatorMethod();
			MethodInfo getServices =
				GetPropertyGetter<CompositionContainer>("Services", typeof (IServiceCollection));
			MethodInfo getFromServices = GetMethodInfo<IServiceCollection>("Get", typeof (Type), typeof (bool));
			ConstructorInfo newDependencyKey =
				GetConstructor<DependencyResolutionLocatorKey>(typeof (Type), typeof (string));


			// context.get_Locator
			il.Emit(OpCodes.Ldarg_0);
			il.EmitCall(OpCodes.Callvirt, getLocator, null);

			// new DependencyResolutionContainer(typeof(CompositionContainer), null)
			EmitLoadType(il, typeof (CompositionContainer));
			il.Emit(OpCodes.Ldnull);
			il.Emit(OpCodes.Newobj, newDependencyKey);
			// locator.Get(key)
			il.EmitCall(OpCodes.Callvirt, getFromLocator, null);
			il.Emit(OpCodes.Castclass, typeof (CompositionContainer));

			// container.get_Services
			il.EmitCall(OpCodes.Callvirt, getServices, null);

			if (attr.Type != null)
			{
				EmitLoadType(il, attr.Type);
			}
			else
			{
				EmitLoadType(il, parameterType);
			}

			if (attr.Required)
			{
				il.Emit(OpCodes.Ldc_I4_1);
			}
			else
			{
				il.Emit(OpCodes.Ldc_I4_0);
			}
			il.EmitCall(OpCodes.Callvirt, getFromServices, null);
		}
	}
}