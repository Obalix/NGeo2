using System;
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
	public class GNS_FindNearbyToponymTests
	{
		[TestMethod]
		public async Task FindNearbyToponym_NoUserName()
		{
			var request = new FindNearbyToponymRequest() {
				Latitude = 47.3m,
				Longitude = 9m,
				Style = Style.FULL
			};

			var response = await GeoNameService.FindNearbyToponym(request);

			response.ShouldNotBeNull();
			response.Items.ShouldBeNull();
			response.ShouldBeType<ErrorResponse>();

			var errorResponse = response as ErrorResponse;
			errorResponse.ShouldNotBeNull();
			errorResponse.Exception.ShouldNotBeNull();
			errorResponse.Exception.Message.ShouldNotBeNull();
			errorResponse.Exception.ErrorCode.ShouldEqual(10);
		}

		[TestMethod]
		public async Task FindNearbyToponym_EuropeanLocation_047300000N_09000000E()
		{
			var request = new FindNearbyToponymRequest() {
				UserName = "obalix",
				Latitude = 47.3m,
				Longitude = 9m,
				Style = Style.FULL
			};

			var response = await GeoNameService.FindNearbyToponym(request);

			response.ShouldNotBeNull();
			response.Items.ShouldNotBeNull();
			response.Items.Length.ShouldEqual(1);
			response.ShouldBeType<GeoNameResponse>();

			var toponymResponse = response as GeoNameResponse;
			toponymResponse.ShouldNotBeNull();
			toponymResponse.Items.Length.ShouldEqual(1);

			toponymResponse.Items[0].TopynymId.ShouldEqual(10628563);
		}

		[TestMethod]
		public async Task FindNearbyToponym_UsLocation_USA_047613959N_122320833W()
		{
			var request = new FindNearbyToponymRequest() {
				UserName = "obalix",
				Latitude = 47.613959m,
				Longitude = -122.320833m,
				Style = Style.FULL
			};

			var response = await GeoNameService.FindNearbyToponym(request);

			response.ShouldNotBeNull();
			response.Items.ShouldNotBeNull();
			response.Items.Length.ShouldEqual(1);
			response.ShouldBeType<GeoNameResponse>();

			var toponymResponse = response as GeoNameResponse;
			toponymResponse.ShouldNotBeNull();
			toponymResponse.Items.Length.ShouldEqual(1);

			toponymResponse.Items[0].TopynymId.ShouldEqual(5793415);
		}
	}
}
