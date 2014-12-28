// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="VideoItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace PodioPCL.Models.ItemFields
{
	/// <summary>
	/// Class VideoItemField.
	/// </summary>
	public class VideoItemField : ItemField
	{
		/// <summary>
		/// The _videos
		/// </summary>
		private List<FileAttachment> _videos;

		/// <summary>
		/// Gets the videos.
		/// </summary>
		/// <value>The videos.</value>
		public IEnumerable<FileAttachment> Videos
		{
			get
			{
				return this.valuesAs<FileAttachment>(_videos);
			}
		}

		/// <summary>
		/// Sets the file ids.
		/// </summary>
		/// <value>The file ids.</value>
		public IEnumerable<int> FileIds
		{
			set
			{
				ensureValuesInitialized();
				foreach (var fileId in value)
				{
					var jobject = new JObject();
					jobject["value"] = fileId;
					this.Values.Add(jobject);
				}
			}
		}
		/// <summary>
		/// Sets the file identifier.
		/// </summary>
		/// <value>The file identifier.</value>
		public int FileId
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
