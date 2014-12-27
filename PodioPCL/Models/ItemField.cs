// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="ItemField.cs" company="Onsharp">
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
	/// The ItemField is the base class for all <see cref="ItemField"/>'s in an <see cref="Item"/>.
	/// </summary>
	[JsonConverter(typeof(ItemFieldConverter))]
	public class ItemField
	{
		/// <summary>
		/// Gets or sets the field identifier.
		/// </summary>
		/// <value>The field identifier.</value>
		[JsonProperty("field_id")]
		public int? FieldId { get; set; }

		/// <summary>
		/// Gets or sets the type of the ItemField.
		/// </summary>
		/// <value>The type.</value>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets the external identifier.
		/// </summary>
		/// <value>The external identifier.</value>
		[JsonProperty("external_id")]
		public string ExternalId { get; set; }

		/// <summary>
		/// Gets or sets the label.
		/// </summary>
		/// <value>The label.</value>
		[JsonProperty("label")]
		public string Label { get; set; }

		/// <summary>
		/// Gets or sets the values.
		/// </summary>
		/// <value>The values.</value>
		[JsonProperty("values")]
		public JArray Values { get; set; }

		/// <summary>
		/// Gets or sets the configuration.
		/// </summary>
		/// <value>The configuration.</value>
		[JsonProperty("config")]
		public FieldConfig Config { get; set; }

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		[JsonProperty("status")]
		public string Status { get; set; }

		/// <summary>
		/// Determines whether the specified key has value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns><c>true</c> if the specified key has value; otherwise, <c>false</c>.</returns>
		public bool HasValue(string key = null)
		{
			return this.Values != null
				&& this.Values.Any()
				&& (key == null ||
				(this.Values.First() != null &&
				this.Values.First()[key] != null));
		}

		/// <summary>
		/// Gets the setting from the <see cref="ItemField.Config"/> property.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>System.Object.</returns>
		public object GetSetting(string key)
		{
			if (this.Config.Settings != null)
			{
				var settings = this.Config.Settings;
				return settings[key];
			}

			return null;
		}

		/// <summary>
		/// Values as a <typeparamref name="TValue"/>.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="value">The value.</param>
		/// <param name="key">The key.</param>
		/// <returns>A <typeparamref name="TValue"/></returns>
		protected TValue valueAs<TValue>(JToken value, string key)
			where TValue : class, new()
		{
			if (value != null && value[key] != null)
				return value[key].ToObject<TValue>();

			return null;
		}

		/// <summary>
		/// Values as List&lt;<typeparamref name="TValue"/>&gt;.
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="list">The list.</param>
		/// <returns>List&lt;<typeparamref name="TValue"/>&gt;.</returns>
		protected List<TValue> valuesAs<TValue>(List<TValue> list)
			where TValue : class, new()
		{
			if (list == null)
			{
				list = new List<TValue>();
				if (this.Values != null)
				{
					foreach (var itemAttributes in this.Values)
					{
						var obj = this.valueAs<TValue>(itemAttributes, "value");
						list.Add(obj);
					}
				}
			}
			return list;
		}

		/// <summary>
		/// Ensures the values initialized.
		/// </summary>
		/// <param name="includeFirstChildDictionary">if set to <c>true</c> [include first child dictionary].</param>
		protected void ensureValuesInitialized(bool includeFirstChildDictionary = false)
		{
			if (this.Values == null)
			{
				this.Values = new JArray();
			}
			if (includeFirstChildDictionary && this.Values.Count == 0)
			{
				this.Values.Add(new JObject());
			}
		}

		/// <summary>
		/// Converts the ItemField to the <typeparamref name="TItemField" />
		/// </summary>
		/// <typeparam name="TItemField">The type of the new ItemField.</typeparam>
		/// <returns>A new <typeparamref name="TItemField"/></returns>
		public TItemField ConvertTo<TItemField>() where TItemField : ItemField, new()
		{
			var toItem = new TItemField();
			toItem.Config = Config;
			toItem.ExternalId = ExternalId;
			toItem.FieldId = FieldId;
			toItem.Label = Label;
			toItem.Status = Status;
			toItem.Type = Type;
			toItem.Values = Values;
			return toItem;
		}
	}
}
