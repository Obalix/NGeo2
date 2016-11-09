namespace NGeo.GeoNames.Requests
{
	/// <summary>
	/// Webservice Type : REST
	/// Url : api.geonames.org/extendedFindNearby?
	/// Parameters : lat,lng
	/// Result : returns the most detailed information available for the lat/lng query as xml document
	/// It is a combination of several services.Example:
	/// In the US it returns the address information.
	/// In other countries it returns the hierarchy service: http://api.geonames.org/extendedFindNearby?lat=47.3&lng=9&username=demo
	/// </summary>
	public class ExtendedFindNearbyRequest : BasicNearbyRequest
	{

	}
}
