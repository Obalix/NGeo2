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
	public class GNS_GetHierarchyTests
	{
		[TestMethod]
		public async Task GetHierarchy_NoUserName()
		{
			var request = new HierarchyRequest() {
				UserName = "",
				GeoNameId = 7910950,
				Style = Style.FULL
			};
			var response = await GeoNameService.GetHierarchy(request);
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
		public async Task GetHierarchy_EuropeanLocation_047300000N_09000000E()
		{
			var request = new HierarchyRequest() {
				GeoNameId = 7910950,
				Style = Style.FULL
			};
			var response = await GeoNameService.GetHierarchy(request);

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

		[TestMethod]
		public async Task GetHierarchy_UsLocation_USA_047613959N_122320833W()
		{
			var request = new HierarchyRequest() {
				GeoNameId = 5789123,
				Style = Style.FULL
			};
			var response = await GeoNameService.GetHierarchy(request);

			response.ShouldNotBeNull();
			response.Items.ShouldNotBeNull();
			response.Items.Length.ShouldEqual(6);
			response.ShouldBeType<GeoNameResponse>();

			var toponymResponse = response as GeoNameResponse;
			toponymResponse.ShouldNotBeNull();
			toponymResponse.Items.Length.ShouldEqual(6);

			toponymResponse.Items[0].TopynymId.ShouldEqual(6295630);
			toponymResponse.Items[1].TopynymId.ShouldEqual(6255149);
			toponymResponse.Items[2].TopynymId.ShouldEqual(6252001);
			toponymResponse.Items[3].TopynymId.ShouldEqual(5815135);
			toponymResponse.Items[4].TopynymId.ShouldEqual(5799783);
			toponymResponse.Items[5].TopynymId.ShouldEqual(5789123);
		}
	}
}
