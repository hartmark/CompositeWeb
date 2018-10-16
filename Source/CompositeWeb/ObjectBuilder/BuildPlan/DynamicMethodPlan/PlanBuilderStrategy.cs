using System;
using System.Reflection.Emit;
using Microsoft.Practices.CompositeWeb.Utility;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class PlanBuilderStrategy : BuilderStrategy
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="typeToBuild"></param>
		/// <param name="existing"></param>
		/// <param name="idToBuild"></param>
		/// <returns></returns>
		public override object BuildUp(
			IBuilderContext context, Type typeToBuild, object existing, string idToBuild)
		{
			ILGenerator il = existing as ILGenerator;
			Guard.ArgumentNotNull(existing, "Must have existing IL generator");
			Guard.ArgumentNotNull(il, "Existing object must be IL Generator");

			BuildUp(context, typeToBuild, existing, idToBuild, il);

			return base.BuildUp(context, typeToBuild, existing, idToBuild);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="typeToBuild"></param>
		/// <param name="existing"></param>
		/// <param name="idToBuild"></param>
		/// <param name="il"></param>
		protected abstract void BuildUp(IBuilderContext context, Type typeToBuild, object existing, string idToBuild,
		                                ILGenerator il);
	}
}