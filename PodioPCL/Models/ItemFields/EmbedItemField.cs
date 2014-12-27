// ***********************************************************************
// Assembly         : PodioPCL
// Author           : OnsharpRyan
// Created          : 12-13-2014
//
// Last Modified By : OnsharpRyan
// Last Modified On : 12-13-2014
// ***********************************************************************
// <copyright file="EmbedItemField.cs" company="Onsharp">
//     Copyright (c) Onsharp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace PodioPCL.Models.ItemFields
{
	/// <summary>
	/// A list of <see cref="PodioPCL.Models.Embed">embeds</see> (links).
	/// <br />
	/// <a href="https://developers.podio.com/doc/applications">Application API Documentation</a>
	/// <br />
	/// <a href="https://developers.podio.com/doc/items">Item API Documentation</a>
	/// <br />
	/// <a href="https://developers.podio.com/doc/embeds">Embed API Documentation</a>
	/// </summary>
	public class EmbedItemField : ItemField
	{
		private List<Embed> _embeds;

		/// <summary>
		/// Gets the embeds.
		/// </summary>
		/// <value>The embeds.</value>
		public IEnumerable<Embed> Embeds
		{
			get
			{
				if (_embeds == null)
				{
					_embeds = new List<Embed>();
					if (this.Values != null)
					{
						foreach (var embedFilePair in this.Values)
						{
							var embed = this.valueAs<Embed>(embedFilePair, "embed");
							if (embedFilePair["file"] != null)
							{
								var file = this.valueAs<FileAttachment>(embedFilePair, "file");
								if (embed.Files == null)
								{
									embed.Files = new List<FileAttachment>();
								}
								embed.Files.Add(file);
							}
							_embeds.Add(embed);
						}
					}
				}
				return _embeds;
			}
		}

		/// <summary>
		/// Adds the embed.
		/// </summary>
		/// <param name="embedId">The embed identifier.</param>
		/// <param name="fileId">The file identifier.</param>
		public void AddEmbed(int embedId, int? fileId = null)
		{
			ensureValuesInitialized();
			var jobject = new JObject();
			jobject["embed"] = embedId;
			if (fileId != null)
			{
				jobject["file"] = fileId;
			}
			this.Values.Add(jobject);
		}
	}
}
