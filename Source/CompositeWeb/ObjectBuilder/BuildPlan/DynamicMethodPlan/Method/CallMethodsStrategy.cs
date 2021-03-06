using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Parameters;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan.Method
{
	/// <summary>
	/// 
	/// </summary>
	public class CallMethodsStrategy : PlanBuilderStrategy
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="typeToBuild"></param>
		/// <param name="existing"></param>
		/// <param name="idToBuild"></param>
		/// <param name="il"></param>
		protected override void BuildUp(
			IBuilderContext context, Type typeToBuild, object existing, string idToBuild, ILGenerator il)
		{
			IMethodChooserPolicy chooser = GetChooserFromContext(context, typeToBuild, idToBuild);
			List<MethodInfo> methods = new List<MethodInfo>(chooser.GetMethods(typeToBuild));

			if (methods.Count > 0)
			{
				LocalBuilder objectToBuild = il.DeclareLocal(typeToBuild);
				il.Emit(OpCodes.Stloc, objectToBuild);

				foreach (MethodInfo method in chooser.GetMethods(typeToBuild))
				{
					il.Emit(OpCodes.Ldloc, objectToBuild);
					foreach (ParameterInfo paramInfo in method.GetParameters())
					{
						EmitResolveParameter(il, paramInfo);
					}
					il.EmitCall(OpCodes.Call, method, null);
				}
				il.Emit(OpCodes.Ldloc, objectToBuild);
			}
		}

		private static void EmitResolveParameter(ILGenerator il, ParameterInfo param)
		{
			ParameterAttribute attr = GetParameterAttribute(param);
			IParameterResolver resolver = ParameterResolverMap.GetResolver(attr);
			resolver.EmitParameterResolution(il, attr, param.ParameterType);
		}

		private static ParameterAttribute GetParameterAttribute(ParameterInfo param)
		{
			object[] attrs = param.GetCustomAttributes(typeof (ParameterAttribute), false);
			if (attrs.Length == 0)
			{
				return new DependencyAttribute();
			}
			if (attrs.Length > 1)
			{
				throw new InvalidAttributeException(string.Format(CultureInfo.CurrentCulture,
				                                                  "Can only have one parameter attribute for parameter {0}",
				                                                  param.Name));
			}

			return (ParameterAttribute) attrs[0];
		}

		private static IMethodChooserPolicy GetChooserFromContext(IBuilderContext context, Type typeToBuild, string idToBuild)
		{
			IMethodChooserPolicy chooser = context.Policies.Get<IMethodChooserPolicy>(typeToBuild, idToBuild);
			if (chooser == null)
			{
				throw new InvalidOperationException("No IMethodChooserPolicy available");
			}
			return chooser;
		}
	}
}