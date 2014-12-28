// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-09-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="Space.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PodioPCL.Utils;

namespace PodioPCL.Models
{
	/// <summary>
	/// Class Space.
	/// </summary>
	public class Space
	{
		/// <summary>
		/// Gets or sets the space identifier.
		/// </summary>
		/// <value>The space identifier.</value>
		[JsonProperty("space_id")]
		public int SpaceId { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		/// <value>The URL.</value>
		[JsonProperty("url")]
		public string Url { get; set; }

		/// <summary>
		/// Gets or sets the URL label.
		/// </summary>
		/// <value>The URL label.</value>
		[JsonProperty("url_label")]
		public string UrlLabel { get; set; }

		/// <summary>
		/// Gets or sets the org identifier.
		/// </summary>
		/// <value>The org identifier.</value>
		[JsonProperty("org_id")]
		public int? OrgId { get; set; }

		/// <summary>
		/// Gets or sets the contact count.
		/// </summary>
		/// <value>The contact count.</value>
		[JsonProperty("contact_count")]
		public int? ContactCount { get; set; }

		/// <summary>
		/// Gets or sets the members.
		/// </summary>
		/// <value>The members.</value>
		[JsonProperty("members")]
		public int? Members { get; set; }

		/// <summary>
		/// Gets or sets the role.
		/// </summary>
		/// <value>The role.</value>
		[JsonProperty("role")]
		public string Role { get; set; }

		/// <summary>
		/// Gets or sets the rights.
		/// </summary>
		/// <value>The rights.</value>
		[JsonProperty("rights")]
		public String[] Rights { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [post on new application].
		/// </summary>
		/// <value><c>null</c> if [post on new application] contains no value, <c>true</c> if [post on new application]; otherwise, <c>false</c>.</value>
		[JsonProperty("post_on_new_app")]
		public bool? PostOnNewApp { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [post on new member].
		/// </summary>
		/// <value><c>null</c> if [post on new member] contains no value, <c>true</c> if [post on new member]; otherwise, <c>false</c>.</value>
		[JsonProperty("post_on_new_member")]
		public bool? PostOnNewMember { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Space"/> is subscribed.
		/// </summary>
		/// <value><c>null</c> if [subscribed] contains no value, <c>true</c> if [subscribed]; otherwise, <c>false</c>.</value>
		[JsonProperty("subscribed")]
		public bool? Subscribed { get; set; }

		/// <summary>
		/// Gets or sets the privacy.
		/// </summary>
		/// <value>The privacy.</value>
		[JsonProperty("privacy")]
		public PrivacyTypes Privacy { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [automatic join].
		/// </summary>
		/// <value><c>null</c> if [automatic join] contains no value, <c>true</c> if [automatic join]; otherwise, <c>false</c>.</value>
		[JsonProperty("auto_join")]
		public bool? AutoJoin { get; set; }

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Space"/> is premium.
		/// </summary>
		/// <value><c>null</c> if [premium] contains no value, <c>true</c> if [premium]; otherwise, <c>false</c>.</value>
		[JsonProperty("premium")]
		public bool? Premium { get; set; }

		/// <summary>
		/// Gets or sets the created on.
		/// </summary>
		/// <value>The created on.</value>
		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		/// <summary>
		/// Gets or sets the last activity on.
		/// </summary>
		/// <value>The last activity on.</value>
		[JsonProperty("last_activity_on")]
		public DateTime? LastActivityOn { get; set; }

		/// <summary>
		/// Gets or sets the created by.
		/// </summary>
		/// <value>The created by.</value>
		[JsonProperty("created_by")]
		public ByLine CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the org.
		/// </summary>
		/// <value>The org.</value>
		[JsonProperty("org")]
		public Organization Org { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is overdue.
		/// </summary>
		/// <value><c>true</c> if this instance is overdue; otherwise, <c>false</c>.</value>
		[JsonProperty("is_overdue")]
		public bool IsOverdue { get; set; }

		/// <summary>
		/// Gets or sets the owner.
		/// </summary>
		/// <value>The owner.</value>
		[JsonProperty("owner")]
		public Ref Owner { get; set; }

		/// <summary>
		/// Gets or sets the push.
		/// </summary>
		/// <value>The push.</value>
		[JsonProperty("push")]
		public Push Push { get; set; }

		/// <summary>
		/// Enum PrivacyTypes
		/// </summary>
		[JsonConverter(typeof(LowerStringEnumConverter))]
		public enum PrivacyTypes
		{
			/// <summary>
			/// Closed privacy option.
			/// </summary>
			Closed,
			/// <summary>
			/// Open privacy option.
			/// </summary>
			Open,
		}
	}
}
