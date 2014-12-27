// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-27-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-27-2014
// ***********************************************************************
// <copyright file="LoginSettings.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodioPCL.Utils.Authentication
{
	/// <summary>
	/// LoginSettings to be used to temporarily store user information (like in unit testing).
	/// </summary>
	public class LoginSettings
	{
		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		public string UserName { get; set; }
		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public string Password { get; set; }
		/// <summary>
		/// Gets or sets the client identifier.
		/// </summary>
		/// <value>The client identifier.</value>
		public string ClientId { get; set; }
		/// <summary>
		/// Gets or sets the client secret.
		/// </summary>
		/// <value>The client secret.</value>
		public string ClientSecret { get; set; }
		/// <summary>
		/// Gets or sets the application identifier.
		/// </summary>
		/// <value>The application identifier.</value>
		public int? AppId { get; set; }
		/// <summary>
		/// Gets or sets the application token.
		/// </summary>
		/// <value>The application token.</value>
		public string AppToken { get; set; }
	}
}
