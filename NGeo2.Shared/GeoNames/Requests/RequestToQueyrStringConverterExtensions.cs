using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace NGeo.GeoNames.Requests
{
	internal static class RequestToQueyrStringConverterExtensions
	{
		internal static string ToQueryString(this GeoNameRequest request, string serviceName)
		{
			var ci = System.Globalization.CultureInfo.InvariantCulture;

			var classHierarchy = Enumerable.Repeat(request.GetType(), 1)
				.Concat(request.GetType().BaseClasses())
				.Select(x => x.GetTypeInfo())
				.Reverse()
				.ToList();

			var parameters = classHierarchy
				.SelectMany(
					(ti, i) => ti.DeclaredProperties.Where(x => x.CanRead && x.GetMethod.IsPublic)
						.Select(x => new { pi = x, ca = x.GetCustomAttribute<JsonPropertyAttribute>() })
						.Select(
							x => new {
								Value = string.Format(ci, "{0}", x.pi.GetValue(request)),
								Name = x.ca?.PropertyName,
								Order = i * 100 + x.ca?.Order
							}
						)
						.Where(x => !string.IsNullOrWhiteSpace(x.Name) && !string.IsNullOrWhiteSpace(x.Value))
				)
				.OrderBy(x => x.Order)
				.Select(x => System.Uri.EscapeUriString($"{x.Name}={string.Format(ci, "{0}", x.Value)}"))
				.ToList();

			var queryString = $"{serviceName}?{string.Join("&", parameters)}";

			return queryString;
		}
	}
}
