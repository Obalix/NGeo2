using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace NGeo.GeoNames.Model
{
	public class GeoName : NGeoItem
	{
		public static Task<GeoName> FromJson(string json)
		{
			return SerializationHelper.FromJson<GeoName>(json);
		}

		public static Task<GeoName> FromXml(XElement el)
		{
			return SerializationHelper.FromXml<GeoName>(
				el,
				async (r) => {
					r.AdminCode1 = (string)el.Element("adminCode1");
					r.AdminCode1_ISO3166_2 = (string)el.Element("adminCode1")?.Attribute("ISO3166-2");
					r.AdminCode2 = (string)el.Element("adminCode2");
					r.AdminCode3 = (string)el.Element("adminCode3");
					r.AdminId1 = (string)el.Element("adminId1");
					r.AdminId2 = (string)el.Element("adminId2");
					r.AdminId3 = (string)el.Element("adminId3");
					r.AdminName1 = (string)el.Element("adminName1");
					r.AdminName2 = (string)el.Element("adminName2");
					r.AdminName3 = (string)el.Element("adminName3");
					r.AdminName4 = (string)el.Element("adminName4");
					r.AdminName5 = (string)el.Element("adminName5");
					r.AsciiName = (string)el.Element("asciiName");
					r.ContinentCode = (string)el.Element("continentCode");
					r.CountryCode = (string)el.Element("countryCode");
					r.CountryId = (string)el.Element("countryId");
					r.CountryName = (string)el.Element("countryName");
					r.Distance = el.Element("distance").SafeConvert(e => (decimal?)e);
					r.Altitude = el.Element("elevation").SafeConvert(e => (int?)e);
					r.FeatureClassName = (string)el.Element("fclName");
					r.FeatureCode = (string)el.Element("fcode");
					r.FeatureCodeId = (string)el.Element("fcodeName");
					r.TopynymId = (int)el.Element("geonameId");
					r.Latitude = el.Element("lat").SafeConvert(e => (decimal?)e);
					r.Longitude = el.Element("lng").SafeConvert(e => (decimal?)e);
					r.Name = (string)el.Element("name");
					r.Population = el.Element("population").SafeConvert(e => (long?)e);
					r.ToponymName = (string)el.Element("toponymName");
					r.FeatureClass = el.Element("fcl").SafeConvert(e => (FeatureClass)Enum.Parse(typeof(FeatureClass), (string)e, true), FeatureClass.Unknown);
					r.Timezone = await Timezone.FromXml(el.Element("timezone"));
#if (NET40)
					r.AlternateNames = el.Elements("alternativeName")
						.Select((an, i) => new { i = i, an = AlternateName.FromXml(an).Result })
						.OrderBy(x => x.i)
						.Select(x => x.an)
						.ToArray();
#else
					r.AlternateNames = (
							await el.Elements("alternativeName")
								.ToObservable()
								.Select((an, i) => Observable.FromAsync(async t => new { i = i, an = await AlternateName.FromXml(an) }))
								.Concat()
								.ToArray()
						)
						.OrderBy(x => x.i)
						.Select(x => x.an)
						.ToArray();
#endif
				}
			);
		}

		[JsonProperty("adminCode1")]
		public string AdminCode1 { get; private set; }

		[JsonIgnore]
		public string AdminCode1_ISO3166_2 { get; private set; }

		[JsonProperty("adminCode2")]
		public string AdminCode2 { get; private set; }

		[JsonProperty("adminCode3")]
		public string AdminCode3 { get; private set; }

		[JsonProperty("adminId1")]
		public string AdminId1 { get; private set; }

		[JsonProperty("adminId2")]
		public string AdminId2 { get; private set; }

		[JsonProperty("adminId3")]
		public string AdminId3 { get; private set; }

		[JsonProperty("adminName1")]
		public string AdminName1 { get; private set; }

		[JsonProperty("adminName2")]
		public string AdminName2 { get; private set; }

		[JsonProperty("adminName3")]
		public string AdminName3 { get; private set; }

		[JsonProperty("adminName4")]
		public string AdminName4 { get; private set; }

		[JsonProperty("adminName5")]
		public string AdminName5 { get; private set; }

		[JsonProperty("asciiName")]
		public string AsciiName { get; private set; }

		[JsonProperty("continentCode")]
		public string ContinentCode { get; private set; }

		[JsonProperty("countryCode")]
		public string CountryCode { get; private set; }

		[JsonProperty("countryId")]
		public string CountryId { get; private set; }

		[JsonProperty("countryName")]
		public string CountryName { get; private set; }

		[JsonProperty("distance")]
		public decimal? Distance { get; private set; }

		[JsonProperty("elevation")]
		public int? Altitude { get; private set; }

		[JsonProperty("fcl")]
		public FeatureClass FeatureClass { get; private set; }

		[JsonProperty("fclName")]
		public string FeatureClassName { get; private set; }

		[JsonProperty("fcode")]
		public string FeatureCode { get; private set; }

		[JsonProperty("fcodeName")]
		public string FeatureCodeId { get; private set; }

		[JsonProperty("geonameId")]
		public int TopynymId { get; private set; }

		[JsonProperty("lat")]
		public decimal? Latitude { get; private set; }

		[JsonProperty("lng")]
		public decimal? Longitude { get; private set; }

		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("population")]
		public long? Population { get; private set; }

		[JsonProperty("toponymName")]
		public string ToponymName { get; private set; }


		[JsonProperty("timezone")]
		public Timezone Timezone { get; private set; }
		[JsonProperty("alternateNames")]
		public AlternateName[] AlternateNames { get; private set; }
	}

	public class Timezone : NGeoItem
	{
		public static Task<Timezone> FromJson(string json)
		{
			return SerializationHelper.FromJson<Timezone>(json);
		}

		public static Task<Timezone> FromXml(XElement el)
		{
			return SerializationHelper.FromXml<Timezone>(
				el,
				(r) => SyncToTaskFactory.CreateTask(
					() => {
						r.GMTOffset = (decimal?)el.Attribute("gmtOffset");
						r.DSTOffset = (decimal?)el.Attribute("dstOffset");
						r.timeZoneId = (string)el;
					}
				)
			);
		}

		[JsonProperty("gmtOffset")]
		public decimal? GMTOffset { get; private set; }

		[JsonProperty("timeZoneId")]
		public string timeZoneId { get; private set; }

		[JsonProperty("dstOffset")]
		public decimal? DSTOffset { get; private set; }
	}

	public class AlternateName : NGeoItem
	{
		public static Task<AlternateName> FromJson(string json)
		{
			return SerializationHelper.FromJson<AlternateName>(json);
		}

		public static Task<AlternateName> FromXml(XElement el)
		{
			return SerializationHelper.FromXml<AlternateName>(
				el,
				(r) => SyncToTaskFactory.CreateTask(
					() => {
						r.Lang = (string)el.Attribute("lang");
						r.IsPreferredName = ((bool?)el.Attribute("isPreferredName")).GetValueOrDefault(false);
						r.IsShortName = ((bool?)el.Attribute("isShortName")).GetValueOrDefault(false);
						r.Name = (string)el;
					}
				)
			);
		}

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("lang")]
		public string Lang { get; set; }

		[JsonProperty("isPreferredName")]
		public bool IsPreferredName { get; set; }

		[JsonProperty("isShortName")]
		public bool IsShortName { get; set; }

		public bool IsLink => (this.Lang.Equals("link", StringComparison.OrdinalIgnoreCase));
	}

	public class BoundingBox : NGeoItem
	{
		public static Task<BoundingBox> FromJson(string json)
		{
			return SerializationHelper.FromJson<BoundingBox>(json);
		}

		public static Task<BoundingBox> FromXml(XElement el)
		{
			return SerializationHelper.FromXml<BoundingBox>(
				el,
				(r) => SyncToTaskFactory.CreateTask(
					() => {
						r.North = (double)el.Element("north");
						r.East = (double)el.Element("east");
						r.South = (double)el.Element("south");
						r.West = (double)el.Element("west");
					}
				)
			);
		}

		[JsonProperty("north")]
		public double North { get; private set; }

		[JsonProperty("east")]
		public double East { get; private set; }

		[JsonProperty("south")]
		public double South { get; private set; }

		[JsonProperty("west")]
		public double West { get; private set; }
	}
}
