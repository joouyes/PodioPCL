//// ***********************************************************************
//// Assembly         : PodioPCL
//// Author           : OnsharpRyan
//// Created          : 12-13-2014
////
//// Last Modified By : OnsharpRyan
//// Last Modified On : 12-13-2014
//// ***********************************************************************
//// <copyright file="ApplicationConfig.cs" company="Onsharp">
////     Copyright (c) Onsharp. All rights reserved.
//// </copyright>
//// <summary></summary>
//// ***********************************************************************
//using Newtonsoft.Json;
//using System.Collections.Generic;

//namespace PodioPCL.Models
//{
//	/// <summary>
//	/// Class ApplicationConfig.
//	/// </summary>
//	public class ApplicationConfig
//	{
//		/// <summary>
//		/// Gets or sets the type.
//		/// </summary>
//		/// <value>The type.</value>
//		[JsonProperty("type")]
//		public string Type { get; set; }

//		/// <summary>
//		/// Gets or sets the name.
//		/// </summary>
//		/// <value>The name.</value>
//		[JsonProperty("name")]
//		public string Name { get; set; }

//		/// <summary>
//		/// Gets or sets the name of the item.
//		/// </summary>
//		/// <value>The name of the item.</value>
//		[JsonProperty("item_name")]
//		public string ItemName { get; set; }

//		/// <summary>
//		/// Gets or sets the description.
//		/// </summary>
//		/// <value>The description.</value>
//		[JsonProperty("description")]
//		public string Description { get; set; }

//		/// <summary>
//		/// Gets or sets the usage.
//		/// </summary>
//		/// <value>The usage.</value>
//		[JsonProperty("usage")]
//		public string Usage { get; set; }

//		/// <summary>
//		/// Gets or sets the external identifier.
//		/// </summary>
//		/// <value>The external identifier.</value>
//		[JsonProperty("external_id")]
//		public object ExternalId { get; set; }

//		/// <summary>
//		/// Gets or sets the icon identifier.
//		/// </summary>
//		/// <value>The icon identifier.</value>
//		[JsonProperty("icon_id")]
//		public int IconId { get; set; }

//		/// <summary>
//		/// Gets or sets a value indicating whether [allow edit].
//		/// </summary>
//		/// <value><c>true</c> if [allow edit]; otherwise, <c>false</c>.</value>
//		[JsonProperty("allow_edit")]
//		public bool AllowEdit { get; set; }

//		/// <summary>
//		/// Gets or sets the default view.
//		/// </summary>
//		/// <value>The default view.</value>
//		[JsonProperty("default_view")]
//		public string DefaultView { get; set; }

//		/// <summary>
//		/// Gets or sets a value indicating whether [allow attachments].
//		/// </summary>
//		/// <value><c>true</c> if [allow attachments]; otherwise, <c>false</c>.</value>
//		[JsonProperty("allow_attachments")]
//		public bool AllowAttachments { get; set; }

//		/// <summary>
//		/// Gets or sets a value indicating whether [allow comments].
//		/// </summary>
//		/// <value><c>true</c> if [allow comments]; otherwise, <c>false</c>.</value>
//		[JsonProperty("allow_comments")]
//		public bool AllowComments { get; set; }

//		/// <summary>
//		/// Gets or sets a value indicating whether [allow create].
//		/// </summary>
//		/// <value><c>true</c> if [allow create]; otherwise, <c>false</c>.</value>
//		[JsonProperty("allow_create")]
//		public bool AllowCreate { get; set; }

//		/// <summary>
//		/// Gets or sets a value indicating whether [silent creates].
//		/// </summary>
//		/// <value><c>true</c> if [silent creates]; otherwise, <c>false</c>.</value>
//		[JsonProperty("silent_creates")]
//		public bool SilentCreates { get; set; }

//		/// <summary>
//		/// Gets or sets a value indicating whether [silent edits].
//		/// </summary>
//		/// <value><c>true</c> if [silent edits]; otherwise, <c>false</c>.</value>
//		[JsonProperty("silent_edits")]
//		public bool SilentEdits { get; set; }

//		/// <summary>
//		/// Gets or sets a value indicating whether [disable notifications].
//		/// </summary>
//		/// <value><c>true</c> if [disable notifications]; otherwise, <c>false</c>.</value>
//		[JsonProperty("disable_notifications")]
//		public bool DisableNotifications { get; set; }

//		/// <summary>
//		/// Gets or sets a value indicating whether this <see cref="ApplicationConfig"/> is fivestar.
//		/// </summary>
//		/// <value><c>true</c> if fivestar; otherwise, <c>false</c>.</value>
//		[JsonProperty("fivestar")]
//		public bool Fivestar { get; set; }

//		/// <summary>
//		/// Gets or sets the fivestar label.
//		/// </summary>
//		/// <value>The fivestar label.</value>
//		[JsonProperty("fivestar_label")]
//		public string FivestarLabel { get; set; }

//		/// <summary>
//		/// Gets or sets a value indicating whether this <see cref="ApplicationConfig"/> is approved.
//		/// </summary>
//		/// <value><c>true</c> if approved; otherwise, <c>false</c>.</value>
//		[JsonProperty("approved")]
//		public bool Approved { get; set; }

//		/// <summary>
//		/// Gets or sets a value indicating whether this <see cref="ApplicationConfig"/> is thumbs.
//		/// </summary>
//		/// <value><c>true</c> if thumbs; otherwise, <c>false</c>.</value>
//		[JsonProperty("thumbs")]
//		public bool Thumbs { get; set; }

//		/// <summary>
//		/// Gets or sets the thumbs label.
//		/// </summary>
//		/// <value>The thumbs label.</value>
//		[JsonProperty("thumbs_label")]
//		public string ThumbsLabel { get; set; }

//		/// <summary>
//		/// Gets or sets a value indicating whether this <see cref="ApplicationConfig"/> is RSVP.
//		/// </summary>
//		/// <value><c>true</c> if RSVP; otherwise, <c>false</c>.</value>
//		[JsonProperty("rsvp")]
//		public bool Rsvp { get; set; }

//		/// <summary>
//		/// Gets or sets the RSVP label.
//		/// </summary>
//		/// <value>The RSVP label.</value>
//		[JsonProperty("rsvp_label")]
//		public string RsvpLabel { get; set; }

//		/// <summary>
//		/// Gets or sets a value indicating whether this <see cref="ApplicationConfig"/> is yesno.
//		/// </summary>
//		/// <value><c>true</c> if yesno; otherwise, <c>false</c>.</value>
//		[JsonProperty("yesno")]
//		public bool Yesno { get; set; }

//		/// <summary>
//		/// Gets or sets the yesno label.
//		/// </summary>
//		/// <value>The yesno label.</value>
//		[JsonProperty("yesno_label")]
//		public string YesnoLabel { get; set; }

//		/// <summary>
//		/// Gets or sets the tasks.
//		/// </summary>
//		/// <value>The tasks.</value>
//		[JsonProperty("tasks")]
//		public List<AutoTask> Tasks { get; set; }
//	}
//}
