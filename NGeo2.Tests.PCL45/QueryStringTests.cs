using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGeo.GeoNames.Model;
using NGeo.GeoNames.Requests;
using Should;

#if (!NET40)

using static System.FormattableString;

#endif

namespace NGeo
{
	[TestClass]
	public class QueryStringTests
	{
		private const string C_Svc_ExtendedFindNearby = "extendedFindNearby";
		private readonly Uri S_BaseAddress = new Uri("http://api.geonames.org/");

		[TestMethod]
		public void QueryString_ExtendedFindNearbyRequest()
		{
			var request = new ExtendedFindNearbyRequest() {
				Latitude = 48.0m,
				Longitude = 11.25m,
				Style = Style.FULL,
			};

			var ci = CultureInfo.InvariantCulture;
#if (NET40)
			var st = String.Format(
				CultureInfo.InvariantCulture,
				"{0}?username={1}&style={2}&lat={3}&lng={4}",
				C_Svc_ExtendedFindNearby,
				Properties.Settings.Default.UserName,
				request.Style.ToString(),
				request.Latitude,
				request.Longitude
			);
#else
			var st = Invariant(
				$"{C_Svc_ExtendedFindNearby}?username={Properties.Settings.Default.UserName}&style={request.Style.ToString()}&lat={request.Latitude}&lng={request.Longitude}"
			);
#endif
			var reference = new Uri(S_BaseAddress, st);
			var result = new Uri(S_BaseAddress, request.ToQueryString(C_Svc_ExtendedFindNearby));
			var c = Uri.Compare(reference, result, UriComponents.HttpRequestUrl, UriFormat.Unescaped, StringComparison.OrdinalIgnoreCase);


			reference.Equals(result).ShouldBeTrue();
		}

		[TestMethod]
		public void QueryString_ExtendedFindNearbyRequest_NoStyle()
		{
			var request = new ExtendedFindNearbyRequest() {
				Latitude = 48.0m,
				Longitude = 11.25m
			};

			var ci = CultureInfo.InvariantCulture;
#if (NET40)
			var st = String.Format(
				CultureInfo.InvariantCulture,
				"{0}?username={1}&lat={2}&lng={3}",
				C_Svc_ExtendedFindNearby,
				Properties.Settings.Default.UserName,
				request.Latitude,
				request.Longitude
			);
#else
			var st = Invariant($"{C_Svc_ExtendedFindNearby}?username={Properties.Settings.Default.UserName}&lat={request.Latitude}&lng={request.Longitude}");
#endif
			var reference = new Uri(S_BaseAddress, st);
			var result = new Uri(S_BaseAddress, request.ToQueryString(C_Svc_ExtendedFindNearby));
			var c = Uri.Compare(reference, result, UriComponents.HttpRequestUrl, UriFormat.Unescaped, StringComparison.OrdinalIgnoreCase);


			reference.Equals(result).ShouldBeTrue();
		}
	}
}
