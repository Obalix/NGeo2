using Newtonsoft.Json;
using NGeo.GeoNames.Model;

namespace NGeo.GeoNames.Requests
{
	/// <summary>
	/// Webservice Type : REST
	/// Url : api.geonames.org/findNearby?
	/// Parameters : lat,lng, featureClass,featureCode, radius: radius in km(optional), maxRows : max number of rows(default 10)
	/// The parameter featureCode may be used several times, to exclude a featureCode you can use 'featureCode!='
	/// style : SHORT,MEDIUM,LONG,FULL(default = MEDIUM), verbosity of returned xml document
	/// localCountry: in border areas this parameter will restrict the search on the local country, value= true
	/// Result : returns the closest toponym for the lat/lng query as xml document
	/// </summary>
	public class FindNearbyToponymRequest : FindNearbyGeoNameRequest
	{

		[JsonProperty("featureClass", Order = 1)]
		public FeatureClass? FeatureClass { get; set; }

		[JsonProperty("featureCode", Order = 2)]
		public string[] FeatureCodes { get; set; }

		[JsonProperty("maxRows", Order = 3)]
		public int? MaxRows { get; set; }
	}
}
