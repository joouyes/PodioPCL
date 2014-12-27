// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="MemberItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace PodioPCL.Models.ItemFields
{
	/// <summary>
	/// A Member of the <see cref="T:PodioPCL.Models.Space"/>.
	/// <br />
	/// <a href="https://developers.podio.com/doc/applications">Application API Documentation</a>
	/// <br />
	/// <a href="https://developers.podio.com/doc/space-members">Space Members API Documentation</a>
	/// </summary>
	public class MemberItemField : ItemField
	{
		private List<User> _users;

		/// <summary>
		/// Gets the users.
		/// </summary>
		/// <value>The users.</value>
		public IEnumerable<User> Users
		{
			get
			{
				return this.valuesAs<User>(_users);
			}
		}

		/// <summary>
		/// The profile_id's of the contacts
		/// </summary>
		public IEnumerable<int> UserIds
		{
			set
			{
				ensureValuesInitialized();
				foreach (var userId in value)
				{
					var jobject = new JObject();
					jobject["value"] = userId;
					this.Values.Add(jobject);
				}
			}
		}

		/// <summary>
		/// Sets the user identifier.
		/// </summary>
		/// <value>The user identifier.</value>
		public int UserId
		{
			set
			{
				ensureValuesInitialized();

				var jobject = new JObject();
				jobject["value"] = value;
				this.Values.Add(jobject);

			}
		}

	}
}
