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
using System;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.Tests.Mocks
{
	public class MockBuilderContext : IBuilderContext
	{
		private BuilderStrategyChain chain = new BuilderStrategyChain();
		private IReadWriteLocator locator = new Locator();
		private PolicyList policies = new PolicyList();

		public MockBuilderContext(params IBuilderStrategy[] strategies)
		{
			if (strategies == null)
			{
				throw new ArgumentNullException("strategies");
			}

			foreach (IBuilderStrategy strategy in strategies)
				chain.Add(strategy);
		}

		#region IBuilderContext Members

		public IBuilderStrategy HeadOfChain
		{
			get { return chain.Head; }
		}

		public IBuilderStrategy GetNextInChain(IBuilderStrategy currentStrategy)
		{
			return chain.GetNext(currentStrategy);
		}

		public IReadWriteLocator Locator
		{
			get { return locator; }
			set { locator = value; }
		}

		public PolicyList Policies
		{
			get { return policies; }
		}

		#endregion
	}
}