using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NGeo.GeoNames
{
    public interface IConsumeGeoNames : IDisposable
	{
		ReadOnlyCollection<Toponym> FindNearbyPlaceName(NearbyPlaceNameFinder finder);

        ReadOnlyCollection<PostalCode> LookupPostalCode(PostalCodeLookup lookup);

        ReadOnlyCollection<NearbyPostalCode> FindNearbyPostalCodes(NearbyPostalCodesFinder finder);

        ReadOnlyCollection<PostalCodedCountry> PostalCodeCountryInfo(string userName);

        Toponym Get(int geoNameId, string userName);

        ReadOnlyCollection<Toponym> Children(int geoNameId, string userName,
            ResultStyle resultStyle = ResultStyle.Medium, int maxRows = 200);

        ReadOnlyCollection<Country> Countries(string userName);

        Hierarchy Hierarchy(int geoNameId, string userName, ResultStyle resultStyle = ResultStyle.Medium);

        ReadOnlyCollection<Toponym> Search(SearchOptions searchOptions);

        TimeZoneExtended TimeZone(TimeZoneLookup lookup);
    }

	public interface IConsumeGeoNamesAsync : IDisposable 
	{
		Task<ReadOnlyCollection<Toponym>> FindNearbyPlaceNameAsync(NearbyPlaceNameFinder finder);

		Task<ReadOnlyCollection<PostalCode>> LookupPostalCodeAsync(PostalCodeLookup lookup);

		Task<ReadOnlyCollection<NearbyPostalCode>> FindNearbyPostalCodesAsync(NearbyPostalCodesFinder finder);

		Task<ReadOnlyCollection<PostalCodedCountry>> PostalCodeCountryInfoAsync(string userName);

		Task<Toponym> GetAsync(int geoNameId, string userName);

		Task<ReadOnlyCollection<Toponym>> ChildrenAsync(int geoNameId, string userName,
			ResultStyle resultStyle = ResultStyle.Medium, int maxRows = 200);

		Task<ReadOnlyCollection<Country>> CountriesAsync(string userName);

		Task<Hierarchy> HierarchyAsync(int geoNameId, string userName, ResultStyle resultStyle = ResultStyle.Medium);

		Task<ReadOnlyCollection<Toponym>> SearchAsync(SearchOptions searchOptions);

		Task<TimeZoneExtended> TimeZoneAsync(TimeZoneLookup lookup);
	}
}