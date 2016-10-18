using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGeo.GeoNames
{
	public class GeoNamesClient : IConsumeGeoNames, IConsumeGeoNamesAsync
	{
		public void Dispose()
		{

		}

		#region [Children]

		public ReadOnlyCollection<Toponym> Children(int geoNameId, string userName, ResultStyle resultStyle = ResultStyle.Medium, int maxRows = 200)
		{
			throw new NotImplementedException();
		}

		public Task<ReadOnlyCollection<Toponym>> ChildrenAsync(int geoNameId, string userName, ResultStyle resultStyle = ResultStyle.Medium, int maxRows = 200)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region [Countries]

		public ReadOnlyCollection<Country> Countries(string userName)
		{
			throw new NotImplementedException();
		}

		public Task<ReadOnlyCollection<Country>> CountriesAsync(string userName)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region [FindNearbyPlaceName]

		public ReadOnlyCollection<Toponym> FindNearbyPlaceName(NearbyPlaceNameFinder finder)
		{
			throw new NotImplementedException();
		}

		public Task<ReadOnlyCollection<Toponym>> FindNearbyPlaceNameAsync(NearbyPlaceNameFinder finder)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region [FindNearbyPostalCodes]

		public ReadOnlyCollection<NearbyPostalCode> FindNearbyPostalCodes(NearbyPostalCodesFinder finder)
		{
			throw new NotImplementedException();
		}

		public Task<ReadOnlyCollection<NearbyPostalCode>> FindNearbyPostalCodesAsync(NearbyPostalCodesFinder finder)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region [Get]

		public Toponym Get(int geoNameId, string userName)
		{
			throw new NotImplementedException();
		}

		public Task<Toponym> GetAsync(int geoNameId, string userName)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region [Hierarchy]

		public Hierarchy Hierarchy(int geoNameId, string userName, ResultStyle resultStyle = ResultStyle.Medium)
		{
			throw new NotImplementedException();
		}

		public Task<Hierarchy> HierarchyAsync(int geoNameId, string userName, ResultStyle resultStyle = ResultStyle.Medium)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region [LookupPostalCode]

		public ReadOnlyCollection<PostalCode> LookupPostalCode(PostalCodeLookup lookup)
		{
			throw new NotImplementedException();
		}

		public Task<ReadOnlyCollection<PostalCode>> LookupPostalCodeAsync(PostalCodeLookup lookup)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region [PostalCodeCountryInfo]

		public ReadOnlyCollection<PostalCodedCountry> PostalCodeCountryInfo(string userName)
		{
			throw new NotImplementedException();
		}

		public Task<ReadOnlyCollection<PostalCodedCountry>> PostalCodeCountryInfoAsync(string userName)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region [Search]

		public ReadOnlyCollection<Toponym> Search(SearchOptions searchOptions)
		{
			throw new NotImplementedException();
		}

		public Task<ReadOnlyCollection<Toponym>> SearchAsync(SearchOptions searchOptions)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region [TimeZone]

		public TimeZoneExtended TimeZone(TimeZoneLookup lookup)
		{
			throw new NotImplementedException();
		}

		public Task<TimeZoneExtended> TimeZoneAsync(TimeZoneLookup lookup)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
