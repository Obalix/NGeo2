using Newtonsoft.Json;

namespace NGeo.GeoNames.Requests
{
	public class FindNearbyGeoNameRequest : BasicNearbyRequest
	{
		[JsonProperty("radius", Order = 1)]
		//default = 10 km
		public decimal? Radius { get; set; }

		[JsonProperty("localCountry", Order = 2)]
		// default = true
		public bool? LocalCountry { get; set; }
	}
}
