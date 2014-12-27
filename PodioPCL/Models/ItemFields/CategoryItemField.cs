// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="CategoryItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace PodioPCL.Models.ItemFields
{
	/// <summary>
	/// A selectable list of categories.
	/// <br />
	/// <a href="https://developers.podio.com/doc/applications">Application API Documentation</a>
	/// <br />
	/// <a href="https://developers.podio.com/doc/items">Item API Documentation</a>
	/// </summary>
    public class CategoryItemField : ItemField
    {
		/// <summary>
		/// The _options
		/// </summary>
        private List<Option> _options;

		/// <summary>
		/// Gets the options.
		/// </summary>
		/// <value>The options.</value>
        public IEnumerable<Option> Options
        {
            get
            {
                return this.valuesAs<Option>(_options);
            }
        }

		/// <summary>
		/// Sets the option identifier.
		/// </summary>
		/// <value>The option identifier.</value>
        public int OptionId {
            set
            {
                ensureValuesInitialized(true);
                this.Values.First()["value"] = value;
            }
        }

		/// <summary>
		/// Sets the option ids.
		/// </summary>
		/// <value>The option ids.</value>
        public IEnumerable<int> OptionIds
        {
            set
            {
                ensureValuesInitialized();
                foreach (var optionId in value)
                {
                    var jobject = new JObject();
                    jobject["value"] = optionId;
                    this.Values.Add(jobject);
                }
            }
        }

		/// <summary>
		/// Class Option.
		/// </summary>
        public class Option
        {

			/// <summary>
			/// Gets or sets the status.
			/// </summary>
			/// <value>The status.</value>
            [JsonProperty("status")]
            public string Status { get; set; }

			/// <summary>
			/// Gets or sets the text.
			/// </summary>
			/// <value>The text.</value>
            [JsonProperty("text")]
            public string Text { get; set; }

			/// <summary>
			/// Gets or sets the identifier.
			/// </summary>
			/// <value>The identifier.</value>
            [JsonProperty("id")]
            public int? Id { get; set; }

			/// <summary>
			/// Gets or sets the color.
			/// </summary>
			/// <value>The color.</value>
            [JsonProperty("color")]
            public string Color { get; set; }
        }

    }
}
