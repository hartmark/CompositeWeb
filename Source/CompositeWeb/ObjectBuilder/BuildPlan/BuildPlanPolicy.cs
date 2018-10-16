using System;
using System.Collections.Generic;

namespace Microsoft.Practices.CompositeWeb.ObjectBuilder.BuildPlan
{
	/// <summary>
	/// 
	/// </summary>
	public class BuildPlanPolicy : IBuildPlanPolicy
	{
		private volatile Dictionary<Type, IBuildPlan> buildPlans;
		private object lockObject;

		/// <summary>
		/// 
		/// </summary>
		public BuildPlanPolicy()
		{
			buildPlans = new Dictionary<Type, IBuildPlan>();
			lockObject = new object();
		}

		#region IBuildPlanPolicy Members

		/// <summary>
		/// 
		/// </summary>
		/// <param name="typeToBuild"></param>
		/// <returns></returns>
		public IBuildPlan Get(Type typeToBuild)
		{
			if (buildPlans.ContainsKey(typeToBuild))
			{
				return buildPlans[typeToBuild];
			}
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="typeToBuild"></param>
		/// <param name="plan"></param>
		public void Set(Type typeToBuild, IBuildPlan plan)
		{
			lock (lockObject)
			{
				Dictionary<Type, IBuildPlan> newPlans =
					new Dictionary<Type, IBuildPlan>(buildPlans);
				newPlans[typeToBuild] = plan;
				buildPlans = newPlans;
			}
		}

		#endregion
	}
}