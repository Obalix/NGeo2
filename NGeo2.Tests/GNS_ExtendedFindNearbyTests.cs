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
	public class GNS_ExtendedFindNearbyTests
	{
#if (NET40)
		[TestMethod]
		public void ExtendedFindNearby_NoUserName_Sync()
		{
			this.ExtendedFindNearby_NoUserName().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task ExtendedFindNearby_NoUserName()
		{
			var request = new ExtendedFindNearbyRequest() {
				UserName = "",
				Latitude = 47.3m,
				Longitude = 9m,
				Style = Style.FULL
			};
			var response = await GeoNameService.ExtendedFindNearby(request);

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
		public void ExtendedFindNearby_EuropeanLocation_047300000N_09000000E_Sync()
		{
			this.ExtendedFindNearby_EuropeanLocation_047300000N_09000000E().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task ExtendedFindNearby_EuropeanLocation_047300000N_09000000E()
		{
			var request = new ExtendedFindNearbyRequest() {
				Latitude = 47.3m,
				Longitude = 9m,
				Style = Style.FULL
			};
			var response = await GeoNameService.ExtendedFindNearby(request);

			response.ShouldNotBeNull();
			response.Items.ShouldNotBeNull();
			response.Items.Length.ShouldEqual(8);
			response.ShouldBeType<GeoNameResponse>();

			var toponymResponse = response as GeoNameResponse;
			toponymResponse.ShouldNotBeNull();
			toponymResponse.Items.Length.ShouldEqual(8);

			toponymResponse.Items[0].TopynymId.ShouldEqual(6295630);
			toponymResponse.Items[1].TopynymId.ShouldEqual(6255148);
			toponymResponse.Items[2].TopynymId.ShouldEqual(2658434);
			toponymResponse.Items[3].TopynymId.ShouldEqual(2658821);
			toponymResponse.Items[4].TopynymId.ShouldEqual(7285001);
			toponymResponse.Items[5].TopynymId.ShouldEqual(7286562);
			toponymResponse.Items[6].TopynymId.ShouldEqual(6559633);
			toponymResponse.Items[7].TopynymId.ShouldEqual(7910950);
		}

#if (NET40)
		[TestMethod]
		public void ExtendedFindNearby_UsLocation_USA_047613959N_122320833W_Sync()
		{
			this.ExtendedFindNearby_UsLocation_USA_047613959N_122320833W().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task ExtendedFindNearby_UsLocation_USA_047613959N_122320833W()
		{
			var request = new ExtendedFindNearbyRequest() {
				Latitude = 47.613959m,
				Longitude = -122.320833m,
				Style = Style.FULL
			};
			var response = await GeoNameService.ExtendedFindNearby(request);

			response.ShouldNotBeNull();
			response.Items.ShouldNotBeNull();
			response.Items.Length.ShouldEqual(1);
			response.ShouldBeType<AddressResponse>();

			var toponymResponse = response as AddressResponse;
			toponymResponse.ShouldNotBeNull();
			toponymResponse.Items.Length.ShouldEqual(1);

			toponymResponse.Items[0].Latitude.ShouldEqual(47.61396m);
			toponymResponse.Items[0].Longitude.ShouldEqual(-122.32078m);
		}

#if (NET40)
		[TestMethod]
		public void ExtendedFindNearby_Execute_EuropeanLocation_047300000N_09000000E_Sync()
		{
			this.ExtendedFindNearby_Execute_EuropeanLocation_047300000N_09000000E().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task ExtendedFindNearby_Execute_EuropeanLocation_047300000N_09000000E()
		{
			var request = new ExtendedFindNearbyRequest() {
				Latitude = 47.3m,
				Longitude = 9m,
				Style = Style.FULL
			};
			var response = await request.Execute();

			response.ShouldNotBeNull();
			response.Items.ShouldNotBeNull();
			response.Items.Length.ShouldEqual(8);
			response.ShouldBeType<GeoNameResponse>();

			var toponymResponse = response as GeoNameResponse;
			toponymResponse.ShouldNotBeNull();
			toponymResponse.Items.Length.ShouldEqual(8);

			toponymResponse.Items[0].TopynymId.ShouldEqual(6295630);
			toponymResponse.Items[1].TopynymId.ShouldEqual(6255148);
			toponymResponse.Items[2].TopynymId.ShouldEqual(2658434);
			toponymResponse.Items[3].TopynymId.ShouldEqual(2658821);
			toponymResponse.Items[4].TopynymId.ShouldEqual(7285001);
			toponymResponse.Items[5].TopynymId.ShouldEqual(7286562);
			toponymResponse.Items[6].TopynymId.ShouldEqual(6559633);
			toponymResponse.Items[7].TopynymId.ShouldEqual(7910950);
		}
	}
}
