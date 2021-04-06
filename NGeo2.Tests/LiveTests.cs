﻿using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGeo.GeoNames.Responses;
using Should;

namespace NGeo
{
	[TestClass]
	public class LiveTests
	{
#if (NET40)
		[TestMethod]
		public void Live_extendedFindNearby_047300000N_09000000E_full_Sync()
		{
			this.Live_extendedFindNearby_047300000N_09000000E_full().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task Live_extendedFindNearby_047300000N_09000000E_full()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri("http://api.geonames.org/");

			var response = await client.GetAsync("extendedFindNearby?lat=47.3&lng=9&username=obalix&style=full");
			response.IsSuccessStatusCode.ShouldBeTrue();

			if (response.IsSuccessStatusCode)
			{
				var xml = await response.Content.ReadAsStringAsync();

				var doc = XDocument.Parse(xml);
				var queryResult = await GeoNameResponse.FromXml(doc.Root);

				queryResult.ShouldNotBeNull();
				queryResult.Exception.ShouldBeNull();
				queryResult.Items.ShouldNotBeNull();
				queryResult.Items.Count().ShouldBeGreaterThan(1);
			}
		}

#if (NET40)
		[TestMethod]
		public void Live_extendedFindByNearby_USA_047613959N_122320833W_Sync()
		{
			this.Live_extendedFindByNearby_USA_047613959N_122320833W().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task Live_extendedFindByNearby_USA_047613959N_122320833W()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri("http://api.geonames.org/");

			var response = await client.GetAsync("extendedFindNearby?lat=47.613959&lng=-122.320833&username=obalix&style=full");
			response.IsSuccessStatusCode.ShouldBeTrue();

			if (response.IsSuccessStatusCode)
			{
				var xml = await response.Content.ReadAsStringAsync();

				var doc = XDocument.Parse(xml);
				var queryResult = await AddressResponse.FromXml(doc.Root);

				queryResult.ShouldNotBeNull();
				queryResult.Exception.ShouldBeNull();
				queryResult.Items.ShouldNotBeNull();
				queryResult.Items.Count().ShouldBeGreaterThanOrEqualTo(1); // US placed only return address
			}
		}

#if (NET40)
		[TestMethod]
		public void Live_extendedFindByNearby_CAN_49285619N_123123184W_Sync()
		{
			this.Live_extendedFindByNearby_CAN_49285619N_123123184W().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task Live_extendedFindByNearby_CAN_49285619N_123123184W()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri("http://api.geonames.org/");

			var response = await client.GetAsync("extendedFindNearby?lat=49.285619&lng=-123.123184&username=obalix&style=full");
			response.IsSuccessStatusCode.ShouldBeTrue();

			if (response.IsSuccessStatusCode)
			{
				var xml = await response.Content.ReadAsStringAsync();

				var doc = XDocument.Parse(xml);
				var queryResult = await GeoNameResponse.FromXml(doc.Root);

				queryResult.ShouldNotBeNull();
				queryResult.Exception.ShouldBeNull();
				queryResult.Items.ShouldNotBeNull();
				queryResult.Items.Count().ShouldBeGreaterThan(1);
			}
		}

#if (NET40)
		[TestMethod]
		public void Live_findNearby_047300000N_09000000E_full_Sync()
		{
			this.Live_findNearby_047300000N_09000000E_full().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task Live_findNearby_047300000N_09000000E_full()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri("http://api.geonames.org/");
			
			var response = await client.GetAsync("findNearby?lat=47.3&lng=9&username=obalix&style=full");
			response.IsSuccessStatusCode.ShouldBeTrue();

			if (response.IsSuccessStatusCode)
			{
				var xml = await response.Content.ReadAsStringAsync();;

				var doc = XDocument.Parse(xml);
				var queryResult = await GeoNameResponse.FromXml(doc.Root);

				queryResult.ShouldNotBeNull();
				queryResult.Exception.ShouldBeNull();
				queryResult.Items.ShouldNotBeNull();
				queryResult.Items.Count().ShouldBeGreaterThan(0);
			}
		}

#if (NET40)
		[TestMethod]
		public void Live_findNearbyPlaceName_047300000N_09000000E_full_Sync()
		{
			this.Live_findNearbyPlaceName_047300000N_09000000E_full().Wait();
		}
#else
		[TestMethod]
#endif
		public async Task Live_findNearbyPlaceName_047300000N_09000000E_full()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri("http://api.geonames.org/");

			var response = await client.GetAsync("findNearbyPlaceName?lat=47.3&lng=9&username=obalix&style=full");
			response.IsSuccessStatusCode.ShouldBeTrue();

			if (response.IsSuccessStatusCode)
			{
				var xml = await response.Content.ReadAsStringAsync(); ;

				var doc = XDocument.Parse(xml);
				var queryResult = await GeoNameResponse.FromXml(doc.Root);

				queryResult.ShouldNotBeNull();
				queryResult.Exception.ShouldBeNull();
				queryResult.Items.ShouldNotBeNull();
				queryResult.Items.Count().ShouldBeGreaterThan(0);
			}
		}
	}
}
