using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using NGeo.GeoNames.Exceptions;
using NGeo.GeoNames.Model;
using NGeo.GeoNames.Requests;
using NGeo.GeoNames.Responses;

namespace NGeo.GeoNames
{
	public class GeoNameService
	{
		private static readonly Dictionary<string, Type> S_itemMap = new Dictionary<string, Type>() {
			{ "status", typeof(ErrorResponse) },
			{ "geoname", typeof(GeoNameResponse) },
			{ "address", typeof(AddressResponse) },
		};

		private static readonly Uri S_baseAddress = new Uri("http://api.geonames.org/");

		private const string C_Svc_ExtendedFindNearby = "extendedFindNearby";
		private const string C_Svc_FindNearbyPopulatedPlace = "findNearbyPlaceName";
		private const string C_Svc_FindNearbyToponym = "findNearby";
		private const string C_Svc_Hierarchy = "hierarchy";

		#region [ExtendedFindNearBy]

		public static async Task<IGeoNameResponse> ExtendedFindNearby(ExtendedFindNearbyRequest request, int maxTries = 1)
		{
			return await GetQueryResponseAsync(C_Svc_ExtendedFindNearby, request, CreateExendedFindNearbyQueryResponse, maxTries, 0);
		}

		private static async Task<IGeoNameResponse> CreateExendedFindNearbyQueryResponse(XDocument doc, string itemName)
		{
			if (itemName == "address")
			{
				return await AddressResponse.FromXml(doc.Root);
			}
			else if (itemName == "geoname")
			{
				return await GeoNameResponse.FromXml(doc.Root);
			}
			else
			{
				return null;
			}
		}

		#endregion

		#region [FindNearbyPopulatedPlace]

		public static async Task<IGeoNameResponse> FindNearbyPopulatedPlace(FindNearbyPlaceRequest request, int maxTries = 1)
		{
			return await GetQueryResponseAsync(C_Svc_FindNearbyPopulatedPlace, request, CreateFindNearbyPopulatedPlaceQueryResponse, maxTries, 0);
		}

		private static async Task<IGeoNameResponse> CreateFindNearbyPopulatedPlaceQueryResponse(XDocument doc, string itemName)
		{
			if (itemName == "geoname")
			{
				return await GeoNameResponse.FromXml(doc.Root);
			}
			else
			{
				return null;
			}
		}

		#endregion

		#region [FindNearbyToponym]

		public static async Task<IGeoNameResponse> FindNearbyToponym(FindNearbyToponymRequest request, int maxTries = 1)
		{
			return await GetQueryResponseAsync(C_Svc_FindNearbyToponym, request, CreateFindNearbyToponymQueryResponse, maxTries, 0);
		}

		private static async Task<IGeoNameResponse> CreateFindNearbyToponymQueryResponse(XDocument doc, string itemName)
		{
			if (itemName == "geoname")
			{
				return await GeoNameResponse.FromXml(doc.Root);
			}
			else
			{
				return null;
			}
		}

		#endregion

		#region [GetHierarchy] 

		public static async Task<IGeoNameResponse> GetHierarchy(HierarchyRequest request, int maxTries = 1)
		{
			return await GetQueryResponseAsync(C_Svc_Hierarchy, request, CreateHierarchyQueryResponse, maxTries, 0);
		}

		private static async Task<IGeoNameResponse> CreateHierarchyQueryResponse(XDocument doc, string itemName)
		{
			if (itemName == "geoname")
			{
				return await GeoNameResponse.FromXml(doc.Root);
			}
			else
			{
				return null;
			}
		}

		#endregion

		#region [GetQueryResponseAsync]

		private static async Task<IGeoNameResponse> GetQueryResponseAsync(
			string method,
			GeoNameRequest request,
			Func<XDocument, string, Task<IGeoNameResponse>> createQueryResponse,
			int maxTries, 
			int nTry
		)
		{
			if (request == null) throw new ArgumentNullException(nameof(request));
			if (createQueryResponse == null) throw new ArgumentNullException(nameof(createQueryResponse));

			maxTries = Math.Min(1, maxTries);

			using (var client = CreateGeoNamesClient())
			{
				var response = await client.GetAsync(request.ToQueryString(method));
				if (response.IsSuccessStatusCode)
				{
					try
					{
						var xml = await response.Content.ReadAsStringAsync();
						var doc = XDocument.Parse(xml);
						try {
							var itemName = doc.Root.Elements().Select(x => x.Name.LocalName).FirstOrDefault();
							if (itemName == "status")
							{
								return (await ErrorResponse.FromXml(doc.Root)) ?? new ErrorResponse(new GeoNamesException("Unexpected response type."));
							}
							else { 
								return await createQueryResponse(doc, itemName);
							}
						}
						catch
						{
							return new ErrorResponse(new GeoNamesException("Cannot create response type."));
						}
					}
					catch (XmlException)
					{
						return new ErrorResponse(new GeoNamesException("Cannot parse response xml.", statusCode: response.StatusCode));
					}
					catch
					{
						return new ErrorResponse(new GeoNamesException("Cannot process response.", statusCode: response.StatusCode));
					}
				}
				else
				{
					if (nTry < maxTries - 1)
					{
						return await GetQueryResponseAsync(method, request, createQueryResponse, maxTries, nTry++);
					}
					else
					{
						return new ErrorResponse(new GeoNamesException("Unsuccessful query.", statusCode: response.StatusCode));
					}
				}
			}
		}

		#endregion

		#region [CreateGeoNamesClient]

		private static HttpClient CreateGeoNamesClient()
		{
			return new HttpClient() { BaseAddress = S_baseAddress };
		}

		#endregion
	}
}
