// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="ImageItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace PodioPCL.Models.ItemFields
{
	/// <summary>
	/// Holds an <see cref="PodioPCL.Models.Image">image</see>.
	/// <br />
	/// <a href="https://developers.podio.com/doc/applications">Application API Documentation</a>
	/// <br />
	/// <a href="https://developers.podio.com/doc/files">File API Documentation</a>
	/// </summary>
	public class ImageItemField : ItemField
	{
		/// <summary>
		/// The _images
		/// </summary>
		private List<FileAttachment> _images;

		/// <summary>
		/// Gets the images.
		/// </summary>
		/// <value>The images.</value>
		public IEnumerable<FileAttachment> Images
		{
			get
			{
				return this.valuesAs<FileAttachment>(_images);
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
		/// Sets the file id of the image file.
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
