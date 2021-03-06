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
using Microsoft.Practices.CompositeWeb.Interfaces;

namespace Microsoft.Practices.CompositeWeb.Tests.Mocks
{
	public class MockHttpContextLocatorService : IHttpContextLocatorService
	{
		public IHttpContext Context;

		public MockHttpContextLocatorService()
		{
		}

		public MockHttpContextLocatorService(IHttpContext context)
		{
			Context = context;
		}

		#region IHttpContextLocatorService Members

		public IHttpContext GetCurrentContext()
		{
			return Context;
		}

		#endregion
	}
}