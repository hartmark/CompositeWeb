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
using Microsoft.Practices.CompositeWeb.ObjectBuilder;
using Microsoft.Practices.ObjectBuilder;

namespace Microsoft.Practices.CompositeWeb.Interfaces
{
	/// <summary>
	/// Defines the contract for the Web Client Application.
	/// </summary>
	public interface IWebClientApplication
	{
		/// <summary>
		/// Gets the <see cref="IBuilder{TStageEnum}"/> used by the application and its modules.
		/// </summary>
		IBuilder<WCSFBuilderStage> ApplicationBuilder { get; }

		/// <summary>
		/// Gets the <see cref="IBuilder{TBuilderStage}"/> used to create and initialize the page handlers.
		/// </summary>
		IBuilder<WCSFBuilderStage> PageBuilder { get; }

		/// <summary>
		/// Gets the application root <see cref="CompositionContainer"/>.
		/// </summary>
		CompositionContainer RootContainer { get; }
	}
}