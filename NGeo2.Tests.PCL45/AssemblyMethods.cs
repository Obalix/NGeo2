using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NGeo
{
	[TestClass]
	public class AssemblyMethods
	{
		[AssemblyInitialize]
		public static void AsseblyInitialize(TestContext context)
		{
			NGeoSettings.UserName = Properties.Settings.Default.UserName;
		}

		[AssemblyCleanup]
		public static void AssemblyCleanup()
		{

		}
	}
}
