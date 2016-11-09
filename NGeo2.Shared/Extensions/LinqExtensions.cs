using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
	internal static class LinqExtensions
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

		public static TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
		{
			if (dict.ContainsKey(key))
			{
				return dict[key];
			}
			else
			{
				return defaultValue;
			}
		}
	}
}
