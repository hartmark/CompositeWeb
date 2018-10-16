using System;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan
{
	/// <summary>
	/// This policy stores the currently available build plans based
	/// on type and ID.
	/// </summary>
	public interface IBuildPlanPolicy : IBuilderPolicy
	{
		/// <summary>
		/// Return a BuildPlan for the specified Type.
		/// </summary>
		/// <param name="typeToBuild">The Type to build</param>
		/// <returns>The BuildPlan</returns>
		IBuildPlan Get(Type typeToBuild);

		/// <summary>
		/// Sets a BuildPlan for a specific Type.
		/// </summary>
		/// <param name="typeToBuild">The Type to be built</param>
		/// <param name="plan">The BuildPlan to asociate.</param>
		void Set(Type typeToBuild, IBuildPlan plan);
	}
}