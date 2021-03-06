﻿// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-09-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="ItemDiff.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PodioPCL.Models
{
	/// <summary>
	/// Class ItemDiff.
	/// </summary>
    public class ItemDiff
    {
		/// <summary>
		/// Gets or sets the field identifier.
		/// </summary>
		/// <value>The field identifier.</value>
        [JsonProperty("field_id")]
        public int? FieldId { get; set; }

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
        [JsonProperty("type")]
        public string Type { get; set; }

		/// <summary>
		/// Gets or sets the label.
		/// </summary>
		/// <value>The label.</value>
        [JsonProperty("label")]
        public string Label { get; set; }

		/// <summary>
		/// Gets or sets the configuration.
		/// </summary>
		/// <value>The configuration.</value>
        [JsonProperty("config")]
        public FieldConfig Config { get; set; }

		/// <summary>
		/// Gets or sets from.
		/// </summary>
		/// <value>From.</value>
        [JsonProperty("from")]
        public List<Dictionary<string, object>> From { get; set; }

		/// <summary>
		/// Gets or sets to.
		/// </summary>
		/// <value>To.</value>
        [JsonProperty("to")]
        public List<Dictionary<string, object>> To { get; set; }
    }
}
