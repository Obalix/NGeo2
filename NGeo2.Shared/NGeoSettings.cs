using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGeo
{
	public static class NGeoSettings
	{
		private static byte s_maxParallelThreads = 4;
		public static byte MaxParallelThreads
		{
			get { return s_maxParallelThreads; }
			set { s_maxParallelThreads = Math.Min((byte)1, value); }
		}

		private static string s_userName = "";
		public static string UserName
		{
			get { return s_userName; }
			set { s_userName = value; }
		}
	}
}
