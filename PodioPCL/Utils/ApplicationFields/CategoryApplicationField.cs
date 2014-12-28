using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PodioPCL.Models;
using PodioPCL.Models.ItemFields;
using System;
using System.Collections.Generic;

namespace PodioPCL.Utils.ApplicationFields
{
	/// <summary>
	/// Class CategoryApplicationField.
	/// </summary>
	public class CategoryApplicationField : ApplicationField
	{
		IEnumerable<CategoryItemField.Option> _options;

		/// <summary>
		/// The list of options for the category
		/// </summary>
		public IEnumerable<CategoryItemField.Option> Options
		{
			get
			{
				if (_options == null)
				{
					_options = this.GetSettingsAs<CategoryItemField.Option>("options");
				}
				return _options;
			}
			set
			{
				InitializeFieldSettings();
				this.InternalConfig.Settings["options"] = value != null ? JToken.FromObject(value) : null;
			}
		}

		/// <summary>
		/// True if multiple options should be allowed, False otherwise
		/// </summary>
		public bool Multiple
		{
			get
			{
				return (bool)this.GetSetting("multiple");
			}
			set
			{
				InitializeFieldSettings();
				this.InternalConfig.Settings["multiple"] = value;
			}
		}

		/// <summary>
		/// The way the options are displayed on the item, one of "inline", "list" or "dropdown"
		/// </summary>
		public DisplayType? Display
		{
			get
			{
				DisplayType displayType = DisplayType.Inline;
				if (Enum.TryParse<DisplayType>((string)this.GetSetting("display"), out displayType))
					return displayType;
				else
					return null;
			}
			set
			{
				InitializeFieldSettings();
				if (value == null)
					this.InternalConfig.Settings["display"] = null;
				else
					this.InternalConfig.Settings["display"] = value.Value.ToString().ToLower();
			}
		}

		[JsonConverter(typeof(LowerStringEnumConverter))]
		public enum DisplayType
		{
			Inline,
			List,
			Dropdown
		}
	}
}
