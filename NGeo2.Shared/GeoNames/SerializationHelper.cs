using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace NGeo.GeoNames
{
	internal static class SerializationHelper
	{
		public static async Task<TResult> FromJson<TResult>(string json)
		{
			if (string.IsNullOrWhiteSpace(json))
			{
				return default(TResult);
			}
			else
			{
#if (NET40)
				return await Task.Factory.StartNew<TResult>(() => JsonConvert.DeserializeObject<TResult>(json));
#else
				return await Task.FromResult(JsonConvert.DeserializeObject<TResult>(json));
#endif
			}
		}

		public static async Task<TResult> FromXml<TResult>(XElement el, Func<TResult, Task> map)
			where TResult : new()
		{
			if (el == null)
			{
				return default(TResult);
			}
			else
			{
				var result = new TResult();
				await map(result);
				return result;
			}
		}

		public static TResult SafeConvert<TResult>(this XElement el, Func<XElement, TResult> getResult, TResult def = default(TResult))
		{
			return string.IsNullOrEmpty((string)el) ? def : getResult(el);
		}
	}
}
