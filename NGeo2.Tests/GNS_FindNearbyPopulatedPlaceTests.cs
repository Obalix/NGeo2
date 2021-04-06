using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGeo.GeoNames;
using NGeo.GeoNames.Model;
using NGeo.GeoNames.Requests;
using NGeo.GeoNames.Responses;
using Should;

namespace NGeo
{
	[TestClass]
	public class GNS_FindNearbyPopulatedPlaceTests
	{
#if (NET40)
		[TestMethod]
		public void FindNearbyPopulatedPlace_NoUserName_Sync()
		{
			this.FindNearbyPopulatedPlace_NoUserName().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task FindNearbyPopulatedPlace_NoUserName()
		{
			var request = new FindNearbyPopulatedPlaceRequest() {
				UserName = "",
				Latitude = 47.3m,
				Longitude = 9m,
				Style = Style.FULL
			};

			var response = await GeoNameService.FindNearbyPopulatedPlace(request);

			response.ShouldNotBeNull();
			response.Items.ShouldBeNull();
			response.ShouldBeType<ErrorResponse>();

			var errorResponse = response as ErrorResponse;
			errorResponse.ShouldNotBeNull();
			errorResponse.Exception.ShouldNotBeNull();
			errorResponse.Exception.Message.ShouldNotBeNull();
			errorResponse.Exception.ErrorCode.ShouldEqual(10);
		}

#if (NET40)
		[TestMethod]
		public void FindNearbyPopulatedPlace_EuropeanLocation_047300000N_09000000E_Sync()
		{
			this.FindNearbyPopulatedPlace_EuropeanLocation_047300000N_09000000E().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task FindNearbyPopulatedPlace_EuropeanLocation_047300000N_09000000E()
		{
			var request = new FindNearbyPopulatedPlaceRequest() {
				Latitude = 47.3m,
				Longitude = 9m,
				Style = Style.FULL
			};

			var response = await GeoNameService.FindNearbyPopulatedPlace(request);

			response.ShouldNotBeNull();
			response.Items.ShouldNotBeNull();
			response.Items.Length.ShouldEqual(1);
			response.ShouldBeType<GeoNameResponse>();

			var toponymResponse = response as GeoNameResponse;
			toponymResponse.ShouldNotBeNull();
			toponymResponse.Items.Length.ShouldEqual(1);

			toponymResponse.Items[0].TopynymId.ShouldEqual(7910950);
		}

#if (NET40)
		[TestMethod]
		public void FindNearbyPopulatedPlace_UsLocation_USA_047613959N_122320833W_Sync()
		{
			this.FindNearbyPopulatedPlace_UsLocation_USA_047613959N_122320833W().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task FindNearbyPopulatedPlace_UsLocation_USA_047613959N_122320833W()
		{
			var request = new FindNearbyPopulatedPlaceRequest() {
				Latitude = 47.613959m,
				Longitude = -122.320833m,
				Style = Style.FULL
			};

			var response = await GeoNameService.FindNearbyPopulatedPlace(request);

			response.ShouldNotBeNull();
			response.Items.ShouldNotBeNull();
			response.Items.Length.ShouldEqual(1);
			response.ShouldBeType<GeoNameResponse>();

			var toponymResponse = response as GeoNameResponse;
			toponymResponse.ShouldNotBeNull();
			toponymResponse.Items.Length.ShouldEqual(1);

			toponymResponse.Items[0].AdminCode3.ShouldEqual("7174408");
		}

#if (NET40)
		[TestMethod]
		public void FindNearbyPopulatedPlace_Execute_EuropeanLocation_047300000N_09000000E_Sync()
		{
			this.FindNearbyPopulatedPlace_Execute_EuropeanLocation_047300000N_09000000E().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task FindNearbyPopulatedPlace_Execute_EuropeanLocation_047300000N_09000000E()
		{
			var request = new FindNearbyPopulatedPlaceRequest() {
				Latitude = 47.3m,
				Longitude = 9m,
				Style = Style.FULL
			};

			var response = await request.Execute();

			response.ShouldNotBeNull();
			response.Items.ShouldNotBeNull();
			response.Items.Length.ShouldEqual(1);
			response.ShouldBeType<GeoNameResponse>();

			var toponymResponse = response as GeoNameResponse;
			toponymResponse.ShouldNotBeNull();
			toponymResponse.Items.Length.ShouldEqual(1);

			toponymResponse.Items[0].TopynymId.ShouldEqual(7910950);
		}
	}
}
