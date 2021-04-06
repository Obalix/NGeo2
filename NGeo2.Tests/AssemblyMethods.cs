using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NGeo
{
	[TestClass]
	public class AssemblyMethods
	{
		public static IConfigurationRoot Configuration;

		[AssemblyInitialize]
		public static void AsseblyInitialize(TestContext context)
		{
			Configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
				.AddJsonFile("appsettings.json", false)
				.Build();

			NGeoSettings.UserName = Configuration.GetSection("UserName")?.Value ?? string.Empty;
		}

		[AssemblyCleanup]
		public static void AssemblyCleanup()
		{

		}
	}
}
