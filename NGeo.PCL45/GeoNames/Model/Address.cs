using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace NGeo.GeoNames.Model
{
	public class Address : NGeoItem
	{
		public static Task<Address> FromJson(string json)
		{
			return SerializationHelper.FromJson<Address>(json);
		}

		public static Task<Address> FromXml(XElement el)
		{
			return SerializationHelper.FromXml<Address>(
				el,
				(r) => SyncToTaskFactory.CreateTask(
					() => {
						r.Street = (string)el.Element("street");
						r.MTfcc = (string)el.Element("mtfcc");
						r.StreetNumber = (string)el.Element("streetNumber");
						r.Latitude = (decimal?)el.Element("lat");
						r.Longitude = (decimal?)el.Element("lng");
						r.Distance = (decimal?)el.Element("distance");
						r.PostCode = (string)el.Element("postalcode");
						r.PlaceName = (string)el.Element("placeName");
						r.AdminCode1 = (string)el.Element("adminCode1");
						r.AdminCode2 = (string)el.Element("adminCode2");
						r.AdminName1 = (string)el.Element("adminName1");
						r.AdminName2 = (string)el.Element("adminName2");
						r.CountryCode = (string)el.Element("countryCode");
					}
				)
			);
		}

		[JsonProperty("street")]
		public string Street { get; set; }

		[JsonProperty("mtfcc")]
		public string MTfcc { get; set; }

		[JsonProperty("streetNumber")]
		public string StreetNumber { get; set; }

		[JsonProperty("lat")]
		public decimal? Latitude { get; set; }

		[JsonProperty("lng")]
		public decimal? Longitude { get; set; }

		[JsonProperty("distance")]
		public decimal? Distance { get; set; }

		[JsonProperty("postalcode")]
		public string PostCode { get; set; }

		[JsonProperty("placeName")]
		public string PlaceName { get; set; }

		[JsonProperty("adminCode1")]
		public string AdminCode1 { get; set; }

		[JsonProperty("adminCode2")]
		public string AdminCode2 { get; set; }

		[JsonProperty("adminName1")]
		public string AdminName1 { get; set; }

		[JsonProperty("adminName2")]
		public string AdminName2 { get; set; }

		[JsonProperty("countryCode")]
		public string CountryCode { get; set; }
	}
}
