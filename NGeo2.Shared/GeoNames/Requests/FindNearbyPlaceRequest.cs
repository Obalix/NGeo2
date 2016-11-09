using Newtonsoft.Json;
using NGeo.GeoNames.Model.Enums;

namespace NGeo.GeoNames.Requests
{
	/// <summary>
	/// Webservice Type : REST
	/// Url : api.geonames.org/findNearbyPlaceName?
	/// Parameters : lat,lng,
	/// lang: language of returned 'name' element(the pseudo language code 'local' will return it in local language),
	/// radius: radius in km(optional), maxRows: max number of rows(default 10)
	/// style: SHORT,MEDIUM,LONG,FULL(default = MEDIUM), verbosity of returned xml document
	/// localCountry: in border areas this parameter will restrict the search on the local country, value= true
	/// cities: optional filter parameter with three possible values 'cities1000', 'cities5000','cities15000'. See the download readme for further infos
	/// Result : returns the closest populated place (feature class=P) for the lat/lng query as xml document.The unit of the distance element is 'km'. 
	/// </summary>
	public class FindNearbyPlaceRequest : FindNearbyGeoNameRequest
	{
		[JsonProperty("lang", Order = 1)]
		// defaut = local
		public string Language { set; get; }

		[JsonProperty("cities", Order = 2)]
		// default = CityClass.cities1000
		public CityClass? Cities { get; set; }
	}
}
