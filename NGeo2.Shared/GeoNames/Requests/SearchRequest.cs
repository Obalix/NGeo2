using Newtonsoft.Json;

namespace NGeo.GeoNames.Requests
{
    public class SearchRequest : GeoNameRequest
    {
        [JsonProperty("q")]
        public string Pattern { get; set; }
    }
}
