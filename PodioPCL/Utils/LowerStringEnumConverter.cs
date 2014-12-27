using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodioPCL.Utils
{
	/// <summary>
	/// Class LowerStringEnumConverter.
	/// </summary>
	public class LowerStringEnumConverter : StringEnumConverter
	{
		/// <summary>
		/// Writes the JSON representation of the object.
		/// </summary>
		/// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <exception cref="System.ArgumentException">Value not an Enum.</exception>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value == null)
			{
				return;
			}
			if (!value.GetType().GetTypeInfo().IsEnum)
			{
				throw new ArgumentException("Value not an Enum.");
			}
			Enum enumValue = (Enum)value;
			serializer.Serialize(writer, enumValue.ToString().ToLower());
		}
	}
}
