using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PodioPCL.Models;
using PodioPCL.Models.ItemFields;
using PodioPCL.Utils.ApplicationFields;
using System;

namespace PodioPCL.Utils.Serialization
{
	internal class ApplicationFieldConverter : CustomCreationConverter<ApplicationField>
	{
		public override bool CanConvert(Type objectType)
		{
			var canConvert = base.CanConvert(objectType);
			return canConvert;
		}

		public override Newtonsoft.Json.Schema.JsonSchema GetSchema()
		{
			var schema = base.GetSchema();
			return schema;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var jsonApplicationField = base.ReadJson(reader, objectType, existingValue, serializer);
			if (jsonApplicationField != null && jsonApplicationField.GetType() == typeof(ApplicationField))
			{
				var field = (ApplicationField)jsonApplicationField;
				ApplicationFieldTypes fieldType = ApplicationFieldTypes.Other;
				Enum.TryParse(field.Type, true, out fieldType);

				switch (fieldType)
				{
					case ApplicationFieldTypes.App:
						return field.ConvertTo<AppReferenceApplicationField>();
					case ApplicationFieldTypes.Category:
						return field.ConvertTo<CategoryApplicationField>();
					case ApplicationFieldTypes.Contact:
						return field.ConvertTo<ContactApplicationField>();
					case ApplicationFieldTypes.Date:
						return field.ConvertTo<DateApplicationField>();
					case ApplicationFieldTypes.Duration:
						return field.ConvertTo<DurationApplicationField>();
					case ApplicationFieldTypes.Embed:
						return field.ConvertTo<EmbedApplicationField>();
					case ApplicationFieldTypes.Image:
						return field.ConvertTo<EmbedApplicationField>();
					case ApplicationFieldTypes.Location:
						return field.ConvertTo<LocationApplicationField>();
					case ApplicationFieldTypes.Money:
						return field.ConvertTo<MoneyApplicationField>();
					case ApplicationFieldTypes.Number:
						return field.ConvertTo<NumericApplicationField>();
					case ApplicationFieldTypes.Progress:
						return field.ConvertTo<ProgressApplicationField>();
					case ApplicationFieldTypes.Question:
						return field.ConvertTo<QuestionApplicationField>();
					case ApplicationFieldTypes.State:
						return field.ConvertTo<StateApplicationField>();
					case ApplicationFieldTypes.Text:
						return field.ConvertTo<TextApplicationField>();
				}
			}
			return jsonApplicationField;
		}

		public override ApplicationField Create(Type objectType)
		{
			var dis = this;
			return new ApplicationField();
		}
	}
}
