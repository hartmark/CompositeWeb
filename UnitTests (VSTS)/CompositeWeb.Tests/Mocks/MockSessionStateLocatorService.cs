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
using System.Web.SessionState;
using Microsoft.Practices.CompositeWeb.Interfaces;

namespace Microsoft.Practices.CompositeWeb.Tests.Mocks
{
	public class MockSessionStateLocatorService : ISessionStateLocatorService
	{
		public MockHttpSessionState SessionState = new MockHttpSessionState();

		#region ISessionStateLocatorService Members

		public IHttpSessionState GetSessionState()
		{
			return SessionState;
		}

		#endregion
	}
}