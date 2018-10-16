using System;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan
{
	/// <summary>
	/// Interface defining how to call a build plan.
	/// </summary>
	public interface IBuildPlan
	{
		/// <summary>
		/// Interface of BuildUp/>.
		/// </summary>
		/// <param name="context">The build context.</param>
		/// <param name="typeToBuild">The type of the object being built.</param>
		/// <param name="existing">The existing instance of the object.</param>
		/// <param name="id">The ID of the object being built.</param>
		/// <returns>The built object.</returns>
		object BuildUp(IBuilderContext context, Type typeToBuild, object existing, string id);
	}
}