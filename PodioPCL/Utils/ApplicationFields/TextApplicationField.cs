using Newtonsoft.Json;
using PodioPCL.Models;

namespace PodioPCL.Utils.ApplicationFields
{
	/// <summary>
	/// Class TextApplicationField.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	public class TextApplicationField : ApplicationField
	{
		private string _size;

		public TextApplicationField()
		{
			Type = "text";
		}

		/// <summary>
		/// Size of the input field, either "small" or "large"
		/// </summary>
		public string Size
		{
			get
			{
				if (_size == null)
				{
					_size = (string)this.GetSetting("size");
				}
				return _size;
			}
			set
			{
				InitializeFieldSettings();
				this.InternalConfig.Settings["size"] = value;
			}
		}
	}
}
