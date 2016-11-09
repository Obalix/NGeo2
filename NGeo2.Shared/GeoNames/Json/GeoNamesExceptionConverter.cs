using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NGeo.GeoNames.Exceptions;

namespace NGeo.GeoNames.Json
{
	internal class GeoNamesExceptionConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
#if (NET40)
			return objectType.IsSameOrSublcass(typeof(GeoNamesException));
#else
			return objectType.GetTypeInfo().IsSameOrSubClass(typeof(GeoNamesException));
#endif
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var jo = JObject.Load(reader);
			//var joex = JObject.
			var message = (string)jo["message"];
			var errorCode = (int?)jo["value"];

			return new GeoNamesException(message, errorCode);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var ex = value as GeoNamesException;

			writer.WriteStartObject();
			writer.WritePropertyName("message");
			serializer.Serialize(writer, ex.Message);
			writer.WritePropertyName("value");
			serializer.Serialize(writer, ex.ErrorCode);
			writer.WriteEndObject();
		}
	}
}
