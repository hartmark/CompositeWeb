//===============================================================================
// Microsoft patterns & practices
// Web Client Software Factory
//-------------------------------------------------------------------------------
// Copyright (C) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//-------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===============================================================================
using System.Collections.Generic;
using Microsoft.Practices.CompositeWeb.Interfaces;

namespace Microsoft.Practices.CompositeWeb.Authorization
{
	/// <summary>
	/// Implements a catalog of roles.
	/// </summary>
	public class RolesCatalog : IRolesCatalog
	{
		private List<string> _roles;

		/// <summary>
		/// Initializes a new instance of <see cref="RolesCatalog"/>.
		/// </summary>
		public RolesCatalog()
		{
			_roles = new List<string>();
		}

		#region IRolesCatalog Members

		/// <summary>
		/// Loads the specified roles into the catalog.
		/// </summary>
		/// <param name="roles">A <see cref="string"/> array with the roles to load.</param>
		public void LoadRoles(string[] roles)
		{
			_roles.Clear();
			_roles.AddRange(roles);
		}

		/// <summary>
		/// Gets a <see cref="List{T}"/> of the roles in the catalog.
		/// </summary>
		public IList<string> Roles
		{
			get { return _roles; }
		}

		#endregion
	}
}