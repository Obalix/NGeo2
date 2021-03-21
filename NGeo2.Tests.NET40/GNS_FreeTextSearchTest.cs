using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGeo.GeoNames;
using NGeo.GeoNames.Model;
using NGeo2.Shared.GeoNames.Requests;
using System;
using System.Threading.Tasks;

namespace NGeo
{
    [TestClass]
    public class GNS_FreeTextSearchTest
    {

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestSearch()
        {
          var request = new SearchRequest
            {
                UserName = "demo",
                Pattern = "Furnace",
                Style = Style.FULL
            };
            var t = GeoNameService.Search(request);

            t.Wait();

            var response = t.Result;

            Assert.IsNotNull(response);
            Assert.IsNull(response.Exception, response.Exception?.Message);
            Assert.IsTrue(response.Items.Length > 0, "Empty result set.");

            var i = 1;

            foreach (var item in response.Items)
            {
                TestContext.WriteLine($"{i++}");
                TestContext.WriteLine($"{(item as GeoName).AsciiName}");
            }
        }
    }
}
