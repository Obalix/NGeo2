using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Should;

namespace NGeo.GeoNames
{
    [TestClass]
    public class ConsumeGeoNamesTests
    {
        [TestMethod]
        public void GeoNames_IConsumeGeoNames_ShouldImplementIDisposable()
        {
            var contract = new Mock<IConsumeGeoNames>();
            contract.Object.ShouldImplement<IDisposable>();
        }

        [TestMethod]
        public void GeoNames_FindNearbyPlaceName_ShouldBeInterfaceMethod()
        {
            var contract = new Mock<IConsumeGeoNames>();
            contract.Setup(m => m.FindNearbyPlaceName(It.IsAny<NearbyPlaceNameFinder>()))
                .Returns(new ReadOnlyCollection<Toponym>(new List<Toponym>()));
            var results = contract.Object.FindNearbyPlaceName(null);
            results.ShouldNotBeNull();
        }

		[TestMethod]
		public async Task GeoNames_FindNearbyPlaceName_ShouldBeInterfaceMethod_Async()
		{
			var contract = new Mock<IConsumeGeoNamesAsync>();
			contract.Setup(m => m.FindNearbyPlaceNameAsync(It.IsAny<NearbyPlaceNameFinder>()))
				.Returns(SyncToTaskFactory.CreateTask(() => new ReadOnlyCollection<Toponym>(new List<Toponym>())));
			var results = await contract.Object.FindNearbyPlaceNameAsync(null);
			results.ShouldNotBeNull();
		}

		[TestMethod]
        public void GeoNames_LookupPostalCode_ShouldBeInterfaceMethod()
        {
            var contract = new Mock<IConsumeGeoNames>();
            contract.Setup(m => m.LookupPostalCode(It.IsAny<PostalCodeLookup>()))
                .Returns(new ReadOnlyCollection<PostalCode>(new List<PostalCode>()));
            var results = contract.Object.LookupPostalCode(null);
            results.ShouldNotBeNull();
		}

		[TestMethod]
		public async Task GeoNames_LookupPostalCode_ShouldBeInterfaceMethod_Async()
		{
			var contract = new Mock<IConsumeGeoNamesAsync>();
			contract.Setup(m => m.LookupPostalCodeAsync(It.IsAny<PostalCodeLookup>()))
				.Returns(SyncToTaskFactory.CreateTask(() => new ReadOnlyCollection<PostalCode>(new List<PostalCode>())));
			var results = await contract.Object.LookupPostalCodeAsync(null);
			results.ShouldNotBeNull();
		}

		[TestMethod]
        public void GeoNames_FindNearbyPostalCodes_ShouldBeInterfaceMethod()
        {
            var contract = new Mock<IConsumeGeoNames>();
            contract.Setup(m => m.FindNearbyPostalCodes(It.IsAny<NearbyPostalCodesFinder>()))
                .Returns(new ReadOnlyCollection<NearbyPostalCode>(new List<NearbyPostalCode>()));
            var results = contract.Object.FindNearbyPostalCodes(null);
            results.ShouldNotBeNull();
		}

		[TestMethod]
		public async Task GeoNames_FindNearbyPostalCodes_ShouldBeInterfaceMethod_Async()
		{
			var contract = new Mock<IConsumeGeoNamesAsync>();
			contract.Setup(m => m.FindNearbyPostalCodesAsync(It.IsAny<NearbyPostalCodesFinder>()))
				.Returns(SyncToTaskFactory.CreateTask(() => new ReadOnlyCollection<NearbyPostalCode>(new List<NearbyPostalCode>())));
			var results = await contract.Object.FindNearbyPostalCodesAsync(null);
			results.ShouldNotBeNull();
		}

		[TestMethod]
        public void GeoNames_PostalCodeCountryInfo_ShouldBeInterfaceMethod()
        {
            var contract = new Mock<IConsumeGeoNames>();
            contract.Setup(m => m.PostalCodeCountryInfo(It.IsAny<string>()))
                .Returns(new ReadOnlyCollection<PostalCodedCountry>(new List<PostalCodedCountry>()));
            var results = contract.Object.PostalCodeCountryInfo(null);
            results.ShouldNotBeNull();
        }

		[TestMethod]
		public async Task GeoNames_PostalCodeCountryInfo_ShouldBeInterfaceMethod_Async()
		{
			var contract = new Mock<IConsumeGeoNamesAsync>();
			contract.Setup(m => m.PostalCodeCountryInfoAsync(It.IsAny<string>()))
				.Returns(SyncToTaskFactory.CreateTask(() => new ReadOnlyCollection<PostalCodedCountry>(new List<PostalCodedCountry>())));
			var results = await contract.Object.PostalCodeCountryInfoAsync(null);
			results.ShouldNotBeNull();
		}

		[TestMethod]
        public void GeoNames_Get_ShouldBeInterfaceMethod()
        {
            var contract = new Mock<IConsumeGeoNames>();
            contract.Setup(m => m.Get(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new Toponym());
            var result = contract.Object.Get(0, null);
            result.ShouldNotBeNull();
		}

		[TestMethod]
		public async Task GeoNames_Get_ShouldBeInterfaceMethod_Async()
		{
			var contract = new Mock<IConsumeGeoNamesAsync>();
			contract.Setup(m => m.GetAsync(It.IsAny<int>(), It.IsAny<string>()))
				.Returns(SyncToTaskFactory.CreateTask(() => new Toponym()));
			var result = await contract.Object.GetAsync(0, null);
			result.ShouldNotBeNull();
		}

		[TestMethod]
        public void GeoNames_Children_ShouldBeInterfaceMethod()
        {
            var contract = new Mock<IConsumeGeoNames>();
            contract.Setup(m => m.Children(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<ResultStyle>(), It.IsAny<int>()))
                .Returns(new ReadOnlyCollection<Toponym>(new List<Toponym>()));
            var results = contract.Object.Children(0, null);
            results.ShouldNotBeNull();
        }

		[TestMethod]
		public async Task GeoNames_Children_ShouldBeInterfaceMethod_Async()
		{
			var contract = new Mock<IConsumeGeoNamesAsync>();
			contract.Setup(m => m.ChildrenAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<ResultStyle>(), It.IsAny<int>()))
				.Returns(SyncToTaskFactory.CreateTask(() => new ReadOnlyCollection<Toponym>(new List<Toponym>())));
			var results = await contract.Object.ChildrenAsync(0, null);
			results.ShouldNotBeNull();
		}

		[TestMethod]
        public void GeoNames_Countries_ShouldBeInterfaceMethod()
        {
            var contract = new Mock<IConsumeGeoNames>();
            contract.Setup(m => m.Countries(It.IsAny<string>()))
                .Returns(new ReadOnlyCollection<Country>(new List<Country>()));
            var results = contract.Object.Countries(null);
            results.ShouldNotBeNull();
		}

		[TestMethod]
		public async Task GeoNames_Countries_ShouldBeInterfaceMethod_Async()
		{
			var contract = new Mock<IConsumeGeoNamesAsync>();
			contract.Setup(m => m.CountriesAsync(It.IsAny<string>()))
				.Returns(SyncToTaskFactory.CreateTask(() => new ReadOnlyCollection<Country>(new List<Country>())));
			var results = await contract.Object.CountriesAsync(null);
			results.ShouldNotBeNull();
		}

		[TestMethod]
        public void GeoNames_Hierarchy_ShouldBeInterfaceMethod()
        {
            var contract = new Mock<IConsumeGeoNames>();
            contract.Setup(m => m.Hierarchy(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<ResultStyle>()))
                .Returns(new Hierarchy());
            var results = contract.Object.Hierarchy(0, null);
            results.ShouldNotBeNull();
		}

		[TestMethod]
		public async Task GeoNames_Hierarchy_ShouldBeInterfaceMethod_Async()
		{
			var contract = new Mock<IConsumeGeoNamesAsync>();
			contract.Setup(m => m.HierarchyAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<ResultStyle>()))
				.Returns(SyncToTaskFactory.CreateTask(() => new Hierarchy()));
			var results = await contract.Object.HierarchyAsync(0, null);
			results.ShouldNotBeNull();
		}

		[TestMethod]
		public async Task GeoNames_TimeZone_ShouldBeInterfaceMethod_Async()
        {
            var contract = new Mock<IConsumeGeoNamesAsync>();
            contract.Setup(m => m.TimeZoneAsync(It.IsAny<TimeZoneLookup>()))
                .Returns(SyncToTaskFactory.CreateTask(() => new TimeZoneExtended()));
            var results = await contract.Object.TimeZoneAsync(null);
            results.ShouldNotBeNull();
        }
    }
}
