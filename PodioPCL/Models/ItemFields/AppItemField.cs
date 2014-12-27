// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="AppItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace PodioPCL.Models.ItemFields
{
	/// <summary>
	/// A reference to another <see cref="T:PodioPCL.Models.Application">app </see> <see cref="T:PodioPCL.Models.Item"> item</see>.
	/// <br />
	/// <a href="https://developers.podio.com/doc/applications">Application API Documentation</a>
	/// <br />
	/// <a href="https://developers.podio.com/doc/items">Item API Documentation</a>
	/// </summary>
	public class AppItemField : ItemField
	{
		/// <summary>
		/// The _items
		/// </summary>
		private List<Item> _items;

		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <value>The items.</value>
		public IEnumerable<Item> Items
		{
			get
			{
				return this.valuesAs<Item>(_items);
			}
		}

		/// <summary>
		/// Sets the item ids.
		/// </summary>
		/// <value>The item ids.</value>
		public IEnumerable<int> ItemIds
		{
			set
			{
				ensureValuesInitialized();
				foreach (var itemId in value)
				{
					var jobject = new JObject();
					jobject["value"] = itemId;
					this.Values.Add(jobject);
				}
			}
		}
		/// <summary>
		/// Sets the item identifier.
		/// </summary>
		/// <value>The item identifier.</value>
		public int ItemId
		{
			set
			{
				ensureValuesInitialized();

				var jobject = new JObject();
				jobject["value"] = value;
				this.Values.Add(jobject);

			}
		}
	}
}
