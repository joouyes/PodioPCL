// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="StateItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;

namespace PodioPCL.Models.ItemFields
{
	/// <summary>
	/// The text value of state from the settings field.
	/// <br />
	/// <a href="https://developers.podio.com/doc/items">Item API Documentation</a>
	/// </summary>
    public class StateItemField : ItemField
    {
		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
        public string Value
        {
            get
            {
                if (this.HasValue("value"))
                {
                    return (string)this.Values.First()["value"];
                }
                else
                {
                    return null;
                }
            }

            set
            {
                ensureValuesInitialized(true);
                this.Values.First()["value"] = value;
            }
        }
    }
}
