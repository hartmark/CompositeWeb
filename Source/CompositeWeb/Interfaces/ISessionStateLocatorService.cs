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
using System.Diagnostics.CodeAnalysis;
using System.Web.SessionState;

namespace Microsoft.Practices.CompositeWeb.Interfaces
{
	/// <summary>
	/// Define a service used to locate the session state.
	/// </summary>
	public interface ISessionStateLocatorService
	{
		/// <summary>
		/// Gets the session state as a <see cref="IHttpSessionState"/> implementation.
		/// </summary>
		/// 
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification="Performs a convertion")]
		IHttpSessionState GetSessionState();
	}
}