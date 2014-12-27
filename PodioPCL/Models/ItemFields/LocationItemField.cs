// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="LocationItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PodioPCL.Models.ItemFields
{
	///	<summary>
	///		<para>A location in f.ex. Google maps.</para>
	///		<para>
	///			<list type="table">
	///				<listheader>
	///					<term>Field Name</term>
	///					<description>Field Value</description>
	///				</listheader>
	///				<item>
	///					<term>value:</term>
	///					<description>The location as entered by the user</description>
	///				</item>
	///				<item>
	///					<term>formatted:</term>
	///					<description>The resolved formatted full address</description>
	///				</item>
	///				<item>
	///					<term>street_number:</term>
	///					<description>The number in the street</description>
	///				</item>
	///				<item>
	///					<term>street_name:</term>
	///					<description>The name of the street</description>
	///				</item>
	///				<item>
	///					<term>postal_code:</term>
	///					<description>The zip code for the city</description>
	///				</item>
	///				<item>
	///					<term>city:</term>
	///					<description>The name of the city</description>
	///				</item>
	///				<item>
	///					<term>state:</term>
	///					<description>The state of the city, if any</description>
	///				</item>
	///				<item>
	///					<term>country:</term>
	///					<description>The country of the city</description>
	///				</item>
	///				<item>
	///					<term>lat:</term>
	///					<description>The latitude of the location</description>
	///				</item>
	///				<item>
	///					<term>lng:</term>
	///					<description>The longitude of the location</description>
	///				</item>
	///			</list>
	///		</para>
	///		<para>
	///			<a href="https://developers.podio.com/doc/applications">Application API Documentation</a>
	///		</para>
	///	</summary>
	public class LocationItemField : ItemField
	{
		/// <summary>
		/// Gets or sets the locations.
		/// </summary>
		/// <value>The locations.</value>
		public IEnumerable<string> Locations
		{
			get
			{
				if (this.Values != null && this.Values.Any())
					return new List<string>(this.Values.Select(s => (string)s["value"]));
				else
					return new List<String>();
			}

			set
			{
				ensureValuesInitialized();
				foreach (var location in value)
				{
					var jobject = new JObject();
					jobject["value"] = location;
					this.Values.Add(jobject);
				}
			}
		}

		/// <summary>
		/// Sets the location.
		/// </summary>
		/// <value>The location.</value>
		public string Location
		{
			get
			{
				if (this.Values != null && this.HasValue("value"))
				{
					return (string)this.Values["value"];
				}
				return null;
			}
			set
			{
				ensureValuesInitialized();
				this.Values.Add(new JObject { { "value", value } });
			}
		}

		/// <summary>
		/// The resolved formatted full address.
		/// </summary>
		/// <value>The formatted address.</value>
		public string Formatted
		{
			get
			{
				if (this.Values != null && this.HasValue("formatted"))
				{
					return (string)this.Values["formatted"];
				}
				return null;
			}
			set
			{
				ensureValuesInitialized();
				this.Values.Add(new JObject { { "formatted", value } });
			}
		}

		/// <summary>
		/// The Street Number of the address.
		/// </summary>
		/// <value>The street number.</value>
		public string StreetNumber
		{
			get
			{
				if (this.Values != null && this.HasValue("street_number"))
				{
					return (string)this.Values["street_number"];
				}
				return null;
			}
			set
			{
				ensureValuesInitialized();
				this.Values.Add(new JObject { { "street_number", value } });
			}
		}

		/// <summary>
		/// The Street Name of the address.
		/// </summary>
		/// <value>The name of the street.</value>
		public string StreetName
		{
			get
			{
				if (this.Values != null && this.HasValue("street_name"))
				{
					return (string)this.Values["street_name"];
				}
				return null;
			}
			set
			{
				ensureValuesInitialized();
				this.Values.Add(new JObject { { "street_name", value } });
			}
		}

		/// <summary>
		/// Gets or sets the postal code.
		/// </summary>
		/// <value>The postal code.</value>
		public string PostalCode
		{
			get
			{
				if (this.Values != null && this.HasValue("postal_code"))
				{
					return (string)this.Values["postal_code"];
				}
				return null;
			}
			set
			{
				ensureValuesInitialized();
				this.Values.Add(new JObject { { "postal_code", value } });
			}
		}

		/// <summary>
		/// Gets or sets the city.
		/// </summary>
		/// <value>The city.</value>
		public string City
		{
			get
			{
				if (this.Values != null && this.HasValue("city"))
				{
					return (string)this.Values["city"];
				}
				return null;
			}
			set
			{
				ensureValuesInitialized();
				this.Values.Add(new JObject { { "city", value } });
			}
		}

		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>The state.</value>
		public string State
		{
			get
			{
				if (this.Values != null && this.HasValue("state"))
				{
					return (string)this.Values["state"];
				}
				return null;
			}
			set
			{
				ensureValuesInitialized();
				this.Values.Add(new JObject { { "state", value } });
			}
		}

		/// <summary>
		/// Gets or sets the country.
		/// </summary>
		/// <value>The country.</value>
		public string Country
		{
			get
			{
				if (this.Values != null && this.HasValue("country"))
				{
					return (string)this.Values["country"];
				}
				return null;
			}
			set
			{
				ensureValuesInitialized();
				this.Values.Add(new JObject { { "country", value } });
			}
		}

		/// <summary>
		/// Gets or sets the latitude.
		/// </summary>
		/// <value>The latitude.</value>
		public string Latitude
		{
			get
			{
				if (this.Values != null && this.HasValue("lat"))
				{
					return (string)this.Values["lat"];
				}
				return null;
			}
			set
			{
				ensureValuesInitialized();
				this.Values.Add(new JObject { { "lat", value } });
			}
		}

		/// <summary>
		/// Gets or sets the longitude.
		/// </summary>
		/// <value>The longitude.</value>
		public string Longitude
		{
			get
			{
				if (this.Values != null && this.HasValue("lng"))
				{
					return (string)this.Values["lng"];
				}
				return null;
			}
			set
			{
				ensureValuesInitialized();
				this.Values.Add(new JObject { { "lng", value } });
			}
		}

	}
}
