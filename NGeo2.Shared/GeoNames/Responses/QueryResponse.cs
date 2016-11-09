using System;
using Newtonsoft.Json;
using NGeo.GeoNames.Exceptions;
using NGeo.GeoNames.Model;

namespace NGeo.GeoNames.Responses
{
	public interface IGeoNameResponse
	{
		GeoNamesException Exception { get; }
		NGeoItem[] Items { get; }
	}

	public abstract class QueryResponse<TItem>
		where TItem : NGeoItem
	{
		[JsonProperty("status")]
		public GeoNamesException Exception { get; protected set; }

		public abstract TItem[] Items { get; protected set; }
	}
}
