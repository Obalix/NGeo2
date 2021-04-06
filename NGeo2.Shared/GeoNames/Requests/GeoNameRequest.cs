using Newtonsoft.Json;
using NGeo.GeoNames.Model;

namespace NGeo.GeoNames.Requests
{
	public abstract class GeoNameRequest
	{
		private string _userName;

		[JsonProperty("username", Order = 1)]
		public string UserName {
			get { return _userName ?? NGeoSettings.UserName; }
			set { _userName = value; }
		}

		[JsonProperty("style", Order = 2)]
		// default = MEDIUM
		public Style? Style { get; set; }

		[JsonProperty("geonameId", Order = 3)]
		public int? GeoNameId { get; set; }

	}
}
