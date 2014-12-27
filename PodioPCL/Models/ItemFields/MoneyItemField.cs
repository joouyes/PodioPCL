// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="MoneyItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;

namespace PodioPCL.Models.ItemFields
{
	/// <summary>
	/// A currency value.
	/// <br />
	/// <a href="https://developers.podio.com/doc/applications">Application API Documentation</a>
	/// </summary>
	public class MoneyItemField : ItemField
	{
		/// <summary>
		/// Gets or sets the currency.
		/// </summary>
		/// <value>The currency.</value>
		public string Currency
		{
			get
			{
				if (this.HasValue("currency"))
				{
					return (string)this.Values.First()["currency"];
				}
				else
				{
					return null;
				}
			}
			set
			{
				ensureValuesInitialized(true);
				this.Values.First()["currency"] = value;
			}
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		public decimal? Value
		{
			get
			{
				if (this.HasValue("value"))
				{
					return (Decimal)this.Values.First()["value"];
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
