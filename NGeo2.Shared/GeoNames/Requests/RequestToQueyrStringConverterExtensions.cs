using System;
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

#if (NET40)
			var classHierarchy = Enumerable.Repeat(request.GetType(), 1)
				.Concat(request.GetType().BaseClasses())
				.Select(x => x)
				.Reverse()
				.ToList();

			var parameters = classHierarchy
				.SelectMany(
					(ti, i) => ti.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
						.Where(x => x.CanRead)
						.Select(x => new { pi = x, ca = x.GetCustomAttributes(false).OfType< JsonPropertyAttribute>().FirstOrDefault() })
						.Select(
							x => new {
								Value = string.Format(ci, "{0}", x.pi.GetValue(request, null)),
								Name = x.ca?.PropertyName,
								Order = i * 100 + x.ca?.Order
							}
						)
						.Where(x => !string.IsNullOrWhiteSpace(x.Name) && !string.IsNullOrWhiteSpace(x.Value))
				)
				.OrderBy(x => x.Order)
				.Select(x => System.Uri.EscapeUriString($"{x.Name}={string.Format(ci, "{0}", x.Value)}"))
				.ToList();
#else
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
#endif

			var queryString = $"{serviceName}?{string.Join("&", parameters)}";

			return queryString;
		}

#if (NET40)


		private static string[] GetParameters(GeoNameRequest request)
		{
			var ci = System.Globalization.CultureInfo.InvariantCulture;
			var requestType = request.GetType();
			var classHierarchy = Enumerable.Repeat(requestType, 1)
				.Concat(requestType.BaseClasses())
				.Select(x => x)
				.Reverse()
				.ToList();

			var parameters = classHierarchy
				.SelectMany(
					(ti, i) => ti.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
						.Where(x => x.CanRead)
						.Select(x => new { pi = x, level = i, ca = x.GetCustomAttributes(false).OfType<JsonPropertyAttribute>().FirstOrDefault() })
						.GroupBy(x => x.pi.Name)
						.Select(g => g.OrderByDescending(x => x.level).FirstOrDefault())
						.Select(
							x => new {
								Value = string.Format(ci, "{0}", x.pi.GetValue(request, null)),
								Name = x.ca?.PropertyName,
								Order = x.level * 1000 + x.ca?.Order
							}
						)
						.Where(x => !string.IsNullOrWhiteSpace(x.Name) && !string.IsNullOrWhiteSpace(x.Value))
				)
				.OrderBy(x => x.Order)
				.Select(x => Uri.EscapeUriString($"{x.Name}={string.Format(ci, "{0}", x.Value)}"))
				.ToArray();

			return parameters;
		}

#else

		private static string[] GetParameters(GeoNameRequest request)
		{
			var ci = System.Globalization.CultureInfo.InvariantCulture;
			var requestType = request.GetType();
			var classHierarchy = Enumerable.Repeat(requestType, 1)
				.Concat(requestType.BaseClasses())
				.Select(x => x.GetTypeInfo())
				.Reverse()
				.ToList();

			var parameters = classHierarchy
				.SelectMany(
					(ti, i) => ti.DeclaredProperties.Where(x => x.CanRead && x.GetMethod.IsPublic)
						.Select(x => new { pi = x, level = i, ca = x.GetCustomAttribute<JsonPropertyAttribute>() })
						.GroupBy(x => x.pi.Name)
						.Select(g => g.OrderByDescending(x => x.level).FirstOrDefault())
						.Select(
							x => new {
								Value = string.Format(ci, "{0}", x.pi.GetValue(request)),
								Name = x.ca?.PropertyName,
								Order = x.level * 100 + x.ca?.Order
							}
						)
						.Where(x => !string.IsNullOrWhiteSpace(x.Name) && !string.IsNullOrWhiteSpace(x.Value))
				)
				.OrderBy(x => x.Order)
				.Select(x => System.Uri.EscapeUriString($"{x.Name}={string.Format(ci, "{0}", x.Value)}"))
				.ToArray();

			return parameters;
		}

#endif
	}
}
