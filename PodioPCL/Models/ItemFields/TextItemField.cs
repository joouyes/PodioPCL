using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using PodioPCL.Utils;
// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="TextItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace PodioPCL.Models.ItemFields
{
	///	<summary>
	///		<para>A text field. Can be formatted with Markdown or Html.</para>
	///		<para>
	///			<list type="table">
	///				<listheader>
	///					<term>Field Name</term>
	///					<description>Field Value</description>
	///				</listheader>
	///				<item>
	///					<term>value:</term>
	///					<description>The value of the field which can be any length.</description>
	///				</item>
	///				<item>
	///					<term>format:</term>
	///					<description>The format of the text, either plain, markdown or html.</description>
	///				</item>
	///			</list>
	///		</para>
	///		<para>
	///			<a href="https://developers.podio.com/doc/applications">Application API Documentation</a>
	///		</para>
	///	</summary>
	public class TextItemField : ItemField
	{
		/// <summary>
		/// Gets or sets the Text.
		/// </summary>
		/// <value>The Text</value>
		public string Text
		{
			get
			{
				if (this.HasValue("value"))
				{
					return this.Values.First["value"].ToObject<string>();
				}
				return null;
			}
			set
			{
				ensureValuesInitialized(true);
				this.Values.First["value"] = value;
			}
		}

		/// <summary>
		/// The format of the <see cref="T:PodioPCL.Models.ItemFields.TextItemField"/> Text property. Can be plain, markdown or HTML.
		/// </summary>
		/// <value>The format.</value>
		public FormatTypes? Format
		{
			get
			{
				if (this.HasValue("format"))
				{
					return this.Values.First["format"].ToObject<FormatTypes>();
				}
				return null;
			}

			set
			{
				ensureValuesInitialized();
				this.Values.First["format"] = JsonConvert.SerializeObject(value);
			}
		}

		/// <summary>
		/// The Format types for Text Formating.
		/// </summary>
		[JsonConverter(typeof(LowerStringEnumConverter))]
		public enum FormatTypes
		{
			/// <summary>
			/// Plain text format
			/// </summary>
			Plain,
			/// <summary>
			/// Markdown Format
			/// </summary>
			Markdown,
			/// <summary>
			/// HTML Format
			/// </summary>
			HTML
		}

		/// <summary>
		/// Enum SizeTypes
		/// </summary>
		[JsonConverter(typeof(LowerStringEnumConverter))]
		public enum SizeTypes
		{
			Small,
			Large
		}
	}
}
