// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-09-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="FileAttachment.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PodioPCL.Models
{
	/// <summary>
	/// FileAttachment from Podio.
	/// </summary>
    public class FileAttachment
    {
		/// <summary>
		/// Gets or sets the file identifier.
		/// </summary>
		/// <value>The file identifier.</value>
        [JsonProperty("file_id")]
        public int FileId { get; set; }

		/// <summary>
		/// Gets or sets the link.
		/// </summary>
		/// <value>The link.</value>
        [JsonProperty("link")]
        public string Link { get; set; }

		/// <summary>
		/// Gets or sets the perma link.
		/// </summary>
		/// <value>The perma link.</value>
        [JsonProperty("perma_link")]
        public string PermaLink { get; set; }

		/// <summary>
		/// Gets or sets the thumbnail link.
		/// </summary>
		/// <value>The thumbnail link.</value>
        [JsonProperty("thumbnail_link")]
        public string ThumbnailLink { get; set; }

		/// <summary>
		/// Gets or sets the hosted by.
		/// </summary>
		/// <value>The hosted by.</value>
        [JsonProperty("hosted_by")]
        public string HostedBy { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

		/// <summary>
		/// Gets or sets the type of the MIME.
		/// </summary>
		/// <value>The type of the MIME.</value>
        [JsonProperty("mimetype")]
        public string MimeType { get; set; }

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value>The size.</value>
        [JsonProperty("size")]
        public int? Size { get; set; }

		/// <summary>
		/// Gets or sets the context.
		/// </summary>
		/// <value>The context.</value>
        [JsonProperty("context")]
        public Dictionary<string, object> Context { get; set; }

		/// <summary>
		/// Gets or sets the created on.
		/// </summary>
		/// <value>The created on.</value>
        [JsonProperty("created_on")]
        public DateTime CreatedOn { get; set; }

		/// <summary>
		/// Gets or sets the rights.
		/// </summary>
		/// <value>The rights.</value>
        [JsonProperty("rights")]
        public String[] rights { get; set; }

		/// <summary>
		/// Gets or sets the created by.
		/// </summary>
		/// <value>The created by.</value>
        [JsonProperty("created_by")]
        public ByLine CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the created via.
		/// </summary>
		/// <value>The created via.</value>
        [JsonProperty("created_via")]
        public Via CreatedVia { get; set; }

		/// <summary>
		/// Gets or sets the replaces.
		/// </summary>
		/// <value>The replaces.</value>
        [JsonProperty("replaces")]
        public List<FileAttachment> Replaces { get; set; }
    }
}
