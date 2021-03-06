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

namespace Microsoft.Practices.CompositeWeb
{
	/// <summary>
	/// Base class for dependency attributes that can be made optional.
	/// </summary>
	public abstract class OptionalDependencyAttribute : ParameterAttribute
	{
		private bool _required = true;

		/// <summary>
		/// Whether the dependency is required. Defaults to true.
		/// </summary>
		public bool Required
		{
			get { return _required; }
			set { _required = value; }
		}

		/// <summary>
		/// See <see cref="ParameterAttribute.CreateParameter"/> for more information.
		/// </summary>
		public abstract override IParameter CreateParameter(Type memberType);
	}
}