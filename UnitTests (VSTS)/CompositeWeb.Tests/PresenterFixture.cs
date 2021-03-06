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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.CompositeWeb.Tests
{
	/// <summary>
	/// Summary description for PresenterFixture
	/// </summary>
	[TestClass]
	public class PresenterFixture
	{
		[TestMethod]
		public void TestInitialization()
		{
			TestablePresenter presenter = new TestablePresenter();

			Assert.IsNull(presenter.View);
		}

		[TestMethod]
		public void TestViewSet()
		{
			TestablePresenter presenter = new TestablePresenter();
			TestView view = new TestView();
			presenter.View = view;

			Assert.AreSame(view, presenter.View);
		}
	}

	internal class TestView
	{
	}

	internal class TestablePresenter : Presenter<TestView>
	{
	}
}