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
using Microsoft.Practices.CompositeWeb.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.CompositeWeb.Tests.Utility
{
	// Tests for the DataEventArgs class, mainly to get test coverage up.
	//
	[TestClass]
	public class DataEventArgsFixture
	{
		[TestMethod]
		public void ShouldStoreDataViaConstructor()
		{
			string data = "Something happened";
			DataEventArgs<string> e = new DataEventArgs<string>(data);
			Assert.AreSame(data, e.Data);
		}

		[TestMethod]
		public void ShouldReturnDatasToStringWhenToStringOnEventArgsCalled()
		{
			string data = "Here's my data";
			DataEventArgs<string> e = new DataEventArgs<string>(data);

			Assert.AreEqual(data, e.ToString());
		}
	}
}