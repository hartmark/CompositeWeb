using System;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan
{
	/// <summary>
	/// This interface defines the contract for creating a new build plan.
	/// </summary>
	public interface IPlanBuilderPolicy : IBuilderPolicy
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="typeToBuild"></param>
		/// <param name="idToBuild"></param>
		/// <returns></returns>
		IBuildPlan CreatePlan(Type typeToBuild, string idToBuild);
	}
}