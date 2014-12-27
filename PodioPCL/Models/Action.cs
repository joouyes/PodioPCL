// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-09-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="Action.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PodioPCL.Models
{
	/// <summary>
	/// The Action model.
	/// <br />
	/// Podio API doc: https://developers.podio.com/doc/actions
	/// </summary>
	public class Action
	{
		//TODO: Add Space, Space_Member, and App stuff from api documentation

		/// <summary>
		/// Gets or sets the action identifier.
		/// </summary>
		/// <value>The action identifier.</value>
		[JsonProperty("action_id")]
		public int? ActionId { get; set; }

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>The data.</value>
		[JsonProperty("data")]
		public JObject Data { get; set; }

		/// <summary>
		/// Gets or sets the text.
		/// </summary>
		/// <value>The text.</value>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Gets or sets the comments.
		/// </summary>
		/// <value>The comments.</value>
		[JsonProperty("comments")]
		public List<Comment> Comments { get; set; }

		/// <summary>
		/// Gets or sets the created by.
		/// </summary>
		/// <value>The created by.</value>
		[JsonProperty("created_by")]
		public ByLine CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the created on.
		/// </summary>
		/// <value>The created on.</value>
		[JsonProperty("created_on")]
		public DateTime? CreatedOn { get; set; }

		/// <summary>
		/// Gets or sets the created via.
		/// </summary>
		/// <value>The created via.</value>
		[JsonProperty("created_via")]
		public Via CreatedVia { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is liked.
		/// </summary>
		/// <value><c>true</c> if this instance is liked; otherwise, <c>false</c>.</value>
		[JsonProperty("is_liked")]
		public bool IsLiked { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [like count].
		/// </summary>
		/// <value><c>true</c> if [like count]; otherwise, <c>false</c>.</value>
		[JsonProperty("like_count")]
		public bool LikeCount { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Action"/> is pineed.
		/// </summary>
		/// <value><c>true</c> if pineed; otherwise, <c>false</c>.</value>
		[JsonProperty("pinned")]
		public bool Pineed { get; set; }

		/// <summary>
		/// Gets or sets the presence.
		/// </summary>
		/// <value>The presence.</value>
		[JsonProperty("presence")]
		public Presence Presence { get; set; }

		/// <summary>
		/// Gets or sets the push.
		/// </summary>
		/// <value>The push.</value>
		[JsonProperty("push")]
		public Push Push { get; set; }

		/// <summary>
		/// Gets or sets the rights.
		/// </summary>
		/// <value>The rights.</value>
		[JsonProperty("rights")]
		public string[] Rights { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Action"/> is subscribed.
		/// </summary>
		/// <value><c>true</c> if subscribed; otherwise, <c>false</c>.</value>
		[JsonProperty("subscribed")]
		public bool Subscribed { get; set; }

		/// <summary>
		/// Gets or sets the subscribed count.
		/// </summary>
		/// <value>The subscribed count.</value>
		[JsonProperty("subscribed_count")]
		public int SubscribedCount { get; set; }

		public static class Types
		{
			public static readonly string AppCreated = "app_created";
			public static readonly string AppUpdated = "app_updated";
			public static readonly string AppDeleted = "app_deleted";
			public static readonly string AppInstalled = "app_installed";
			public static readonly string AppActivated = "app_activated";
			public static readonly string AppDeactivated = "app_deactivated";

			public static readonly string SpaceCreated = "space_created";
			public static readonly string SpaceMemberAdded = "member_added";
			public static readonly string SpaceMemberLeft = "member_left";
			public static readonly string SpaceMemberKicked = "member_kicked";
		}
	}
}