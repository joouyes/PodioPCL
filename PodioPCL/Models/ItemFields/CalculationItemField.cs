// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="CalculationItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;

namespace PodioPCL.Models.ItemFields
{
	/// <summary>
	/// A calculation based on <see cref="T:PodioPCL.Models.ItemField">Fields</see> in the same or related <see cref="T:PodioPCL.Models.Application">Application</see>
	/// <br />
	/// <a href="https://developers.podio.com/doc/applications">Application API Documentation</a>
	/// </summary>
	public class CalculationItemField : ItemField
	{
		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		public float? Value
		{
			get
			{
				if (this.HasValue("value"))
				{
					return float.Parse((string)this.Values.First()["value"]);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Gets the value as string.
		/// </summary>
		/// <value>The value as string.</value>
		public string ValueAsString
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
		}

		/// <summary>
		/// Gets the start.
		/// </summary>
		/// <value>The start.</value>
		public DateTime? Start
		{
			get
			{
				if (this.HasValue("start"))
				{
					return (DateTime)this.Values.First()["start"];
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Gets the start UTC.
		/// </summary>
		/// <value>The start UTC.</value>
		public DateTime? StartUTC
		{
			get
			{
				if (this.HasValue("start_utc"))
				{
					return (DateTime)this.Values.First()["start_utc"];
				}
				else
				{
					return null;
				}
			}
		}
	}

}