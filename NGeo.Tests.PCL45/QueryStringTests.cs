using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGeo.GeoNames.Model;
using NGeo.GeoNames.Requests;
using Should;
using static System.FormattableString;

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
			var st = Invariant($"{C_Svc_ExtendedFindNearby}?style={request.Style.ToString()}&lat={request.Latitude}&lng={request.Longitude}");
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
			var st = Invariant($"{C_Svc_ExtendedFindNearby}?lat={request.Latitude}&lng={request.Longitude}");
			var reference = new Uri(S_BaseAddress, st);
			var result = new Uri(S_BaseAddress, request.ToQueryString(C_Svc_ExtendedFindNearby));
			var c = Uri.Compare(reference, result, UriComponents.HttpRequestUrl, UriFormat.Unescaped, StringComparison.OrdinalIgnoreCase);


			reference.Equals(result).ShouldBeTrue();
		}
	}
}
