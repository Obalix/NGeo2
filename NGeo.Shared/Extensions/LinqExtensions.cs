using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
	public static class LinqExtensions
	{
		public static void ForEach<T>(this List<T> list, Action<T> body)
		{
			list.ForEach((x, i) => body(x));
		}

		public static void ForEach<T>(this List<T> list, Action<T, int> body)
		{
			for (var i = 0; i < list.Count; ++i)
			{
				body(list[i], i);
			}
		}
	}
}
