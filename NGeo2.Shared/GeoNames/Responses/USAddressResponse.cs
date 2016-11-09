using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using NGeo.GeoNames.Exceptions;
using NGeo.GeoNames.Model;

namespace NGeo.GeoNames.Responses
{
	public class AddressResponse : QueryResponse<Address>, IGeoNameResponse
	{
		public static Task<AddressResponse> FromJson(string json)
		{
			return SerializationHelper.FromJson<AddressResponse>(json);
		}

		public static Task<AddressResponse> FromXml(XElement el)
		{
			return SerializationHelper.FromXml<AddressResponse>(
				el,
				async (r) => {
					var status = el.Element("status");
					if (status != null)
					{
						r.Exception = new GeoNamesException((string)status.Attribute("message"), (int?)status.Attribute("value"));
					}
					else
					{
						r.Items = await el.Elements("address")
							.ToObservable()
							.Select(x => Observable.FromAsync(async t => await Address.FromXml(x)))
							.Merge(NGeoSettings.MaxParallelThreads)
							.ToArray();
					}
				}
			);
		}

		#region [Results]

		[JsonProperty("addresses")]
		public override Address[] Items { get; protected set; }

		NGeoItem[] IGeoNameResponse.Items { get { return this.Items; } }

		#endregion
	}
}
