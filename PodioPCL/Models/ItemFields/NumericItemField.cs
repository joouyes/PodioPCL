// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="NumericItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;

namespace PodioPCL.Models.ItemFields
{
	/// <summary>
	/// A field that can hold a single number with decimals.
	/// <br />
	/// <a href="https://developers.podio.com/doc/applications">Application API Documentation</a>
	/// </summary>
    public class NumericItemField : ItemField
    {
		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
        public double? Value
        {
            get
            {
                if (this.HasValue("value"))
                {
                    return (double)this.Values.First()["value"];
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
