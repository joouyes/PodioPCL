// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="ApplicationField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PodioPCL.Utils.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace PodioPCL.Models
{
	/// <summary>
	/// Class ApplicationField.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), JsonConverter(typeof(ApplicationFieldConverter))]
	public class ApplicationField
	{
		/// <summary>
		/// Gets or sets the field identifier.
		/// </summary>
		/// <value>The field identifier.</value>
		[JsonProperty("field_id", NullValueHandling = NullValueHandling.Ignore)]
		public int? FieldId { get; set; }

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		[JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets the label.
		/// </summary>
		/// <value>The label.</value>
		public string Label
		{
			get { return this.InternalConfig.Label; }
			set
			{
				InitializeFieldSettings();
				this.InternalConfig.Label = value;
			}
		}

		/// <summary>
		/// Gets the external identifier.
		/// </summary>
		/// <value>The external identifier.</value>
		[JsonProperty("external_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ExternalId { get; internal set; }

		/// <summary>
		/// Gets the internal configuration.
		/// </summary>
		/// <value>The internal configuration.</value>
		[JsonProperty("config", NullValueHandling = NullValueHandling.Ignore)]
		public FieldConfig InternalConfig { get; internal set; }

		/// <summary>
		/// Gets the configuration.
		/// </summary>
		/// <value>The configuration.</value>
		public FieldConfig Config
		{
			get
			{
				return InitializeFieldSettings();
			}
		}

		/// <summary>
		/// Gets the status.
		/// </summary>
		/// <value>The status.</value>
		[JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
		public string Status { get; internal set; }


		/// <summary>
		/// Gets the setting.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>JToken.</returns>
		internal JToken GetSetting(string key)
		{
			if (this.InternalConfig.Settings != null)
			{
				return InternalConfig.Settings[key];
			}

			return null;
		}

		/// <summary>
		/// Gets the settings as.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key">The key.</param>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		internal IEnumerable<T> GetSettingsAs<T>(string key)
		{
			var rawOptions = (JArray)this.GetSetting(key);
			var options = new T[rawOptions.Count];

			if (rawOptions != null && rawOptions.Any())
				return rawOptions.ToObject<List<T>>();

			return options;
		}

		/// <summary>
		/// Initializes the field settings.
		/// </summary>
		/// <returns>FieldConfig.</returns>
		internal FieldConfig InitializeFieldSettings()
		{
			FieldConfig config = null;

			if (this.InternalConfig == null)
				this.InternalConfig = config = new FieldConfig();
			else
				config = this.InternalConfig;


			if (this.InternalConfig.Settings == null)
				this.InternalConfig.Settings = new JObject();

			return config;
		}

		/// <summary>
		/// Converts the ItemField to the <typeparamref name="TApplicationField" />
		/// </summary>
		/// <typeparam name="TApplicationField">The type of the new ItemField.</typeparam>
		/// <returns>A new <typeparamref name="TApplicationField"/></returns>
		public TApplicationField ConvertTo<TApplicationField>() where TApplicationField : ApplicationField, new()
		{
			return new TApplicationField
			{
				ExternalId = ExternalId,
				FieldId = FieldId,
				InternalConfig = InternalConfig,
				Label = Label,
				Status = Status,
				Type = Type
			};
		}
	}
}
