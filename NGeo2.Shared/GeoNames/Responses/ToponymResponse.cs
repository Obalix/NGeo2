using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using NGeo.GeoNames.Exceptions;
using NGeo.GeoNames.Model;

namespace NGeo.GeoNames.Responses
{
	public class GeoNameResponse : QueryResponse<GeoName>, IGeoNameResponse
	{
		public static Task<GeoNameResponse> FromJson(string json)
		{
			return SerializationHelper.FromJson<GeoNameResponse>(json);
		}

		public static Task<GeoNameResponse> FromXml(XElement el)
		{
			return SerializationHelper.FromXml<GeoNameResponse>(
				el,
				async r => {
					var status = el.Element("status");
					if (status != null)
					{
						r.Exception = new GeoNamesException((string)status.Attribute("message"), (int?)status.Attribute("value"));
					}
					else
					{
#if (NET40)
						await SyncToTaskFactory.CreateTask(
							() => {
								r.Items = el.Elements("geoname")
									.AsParallel()
									.WithDegreeOfParallelism(NGeoSettings.MaxParallelThreads)
									.Select((x, i) => new { i = i, t = GeoName.FromXml(x).Result })
									.OrderBy(x => x.i)
									.Select(x => x.t)
									.ToArray();

							}
						);
#else
						r.Items = (
								await el.Elements("geoname")
									.ToObservable()
									.Select((x, i) => Observable.FromAsync(async t => new { i = i, t = await GeoName.FromXml(x) }))
									.Merge(NGeoSettings.MaxParallelThreads)
									.ToArray()
							)
							.OrderBy(x => x.i)
							.Select(x => x.t)
							.ToArray();
#endif
					}
				}
			);
		}

		#region [Results]

				[JsonProperty("geonames")]
				public override GeoName[] Items { get; protected set; }

				NGeoItem[] IGeoNameResponse.Items { get { return this.Items; } }

		#endregion
	}
}
