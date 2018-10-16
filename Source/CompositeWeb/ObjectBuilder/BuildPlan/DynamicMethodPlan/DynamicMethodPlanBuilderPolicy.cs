using System;
using System.Reflection.Emit;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan
{
	/// <summary>
	/// 
	/// </summary>
	public class DynamicMethodPlanBuilderPolicy : IPlanBuilderPolicy
	{
		private PolicyList policies;
		private IBuilderStrategyChain strategies;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strategies"></param>
		public DynamicMethodPlanBuilderPolicy(IBuilderStrategyChain strategies)
			: this(strategies, new PolicyList())
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strategies"></param>
		/// <param name="policies"></param>
		public DynamicMethodPlanBuilderPolicy(IBuilderStrategyChain strategies, PolicyList policies)
		{
			this.strategies = strategies;
			this.policies = policies;
		}

		#region IPlanBuilderPolicy Members

		/// <summary>
		/// 
		/// </summary>
		/// <param name="typeToBuild"></param>
		/// <param name="idToBuild"></param>
		/// <returns></returns>
		public IBuildPlan CreatePlan(Type typeToBuild, string idToBuild)
		{
			IBuilderContext context = GetContext();

			DynamicMethod buildMethod = new DynamicMethod(
				"BuildUp_" + typeToBuild,
				typeof (object),
				new Type[] {typeof (IBuilderContext), typeof (Type), typeof (object), typeof (string)},
				typeToBuild);
			ILGenerator il = buildMethod.GetILGenerator();

			context.HeadOfChain.BuildUp(context, typeToBuild, il, idToBuild);

			il.Emit(OpCodes.Ret);

			return
				new DynamicMethodBuildPlan((BuildUpHandler) buildMethod.CreateDelegate(typeof (BuildUpHandler)));
		}

		#endregion

		private IBuilderContext GetContext()
		{
			BuilderContext context = new BuilderContext(
				strategies,
				new Locator(),
				policies);
			return context;
		}
	}
}