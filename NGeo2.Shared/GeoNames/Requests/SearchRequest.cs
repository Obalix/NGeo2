using Newtonsoft.Json;
using NGeo.GeoNames.Requests;

namespace NGeo2.Shared.GeoNames.Requests
{
    public class SearchRequest : GeoNameRequest
    {
        [JsonProperty("q")]
        public string Pattern { get; set; }
    }
}
