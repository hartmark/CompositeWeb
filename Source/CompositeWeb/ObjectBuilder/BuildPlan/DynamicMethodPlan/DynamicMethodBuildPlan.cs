using System;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan.DynamicMethodPlan
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="context"></param>
	/// <param name="typeToBuild"></param>
	/// <param name="existing"></param>
	/// <param name="id"></param>
	/// <returns></returns>
	public delegate object BuildUpHandler(
		IBuilderContext context, Type typeToBuild, object existing, string id);

	/// <summary>
	/// 
	/// </summary>
	public class DynamicMethodBuildPlan : IBuildPlan
	{
		private BuildUpHandler buildUpMethod;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="buildUpMethod"></param>
		public DynamicMethodBuildPlan(BuildUpHandler buildUpMethod)
		{
			this.buildUpMethod = buildUpMethod;
		}

		#region IBuildPlan Members

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="typeToBuild"></param>
		/// <param name="existing"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public object BuildUp(IBuilderContext context, Type typeToBuild, object existing, string id)
		{
			return buildUpMethod(context, typeToBuild, existing, id);
		}

		#endregion
	}
}