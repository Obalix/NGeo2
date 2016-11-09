using Newtonsoft.Json;
using NGeo.GeoNames.Model;

namespace NGeo.GeoNames.Requests
{
	public abstract class BasicNearbyRequest : GeoNameRequest
	{
		[JsonProperty("lat", Order = 1)]
		public decimal? Latitude { get; set; }

		[JsonProperty("lng", Order = 2)]
		public decimal? Longitude { get; set; }
	}
}
