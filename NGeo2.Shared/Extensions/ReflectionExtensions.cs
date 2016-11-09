using System.Collections.Generic;
using System.Linq;

namespace System.Reflection
{
	internal static class ReflectionExtensions
	{
#if (NET40)
		public static bool IsSameOrSublcass(this Type subclass, Type baseclass) 
			=> subclass.IsSubclassOf(baseclass) || subclass == baseclass;

		public static IEnumerable<Type> BaseClasses(this Type subclass)
		{
			if (subclass == null || subclass.BaseType == null) return Enumerable.Empty<Type>();

			return Enumerable.Repeat(subclass.BaseType, 1)
				.Concat(BaseClasses(subclass.BaseType));
		}
#else
		public static bool IsSameOrSubClass(this TypeInfo subclass, TypeInfo baseclass)
			=> subclass.IsSubclassOf(baseclass.AsType()) || subclass == baseclass;

		public static bool IsSameOrSubClass(this TypeInfo subclass, Type baseclass)
			=> IsSameOrSubClass(subclass, baseclass?.GetTypeInfo());

		public static IEnumerable<Type> BaseClasses(this Type subclass)
			=> BaseClasses(subclass?.GetTypeInfo());

		public static IEnumerable<Type> BaseClasses(this TypeInfo subclass)
		{
			if (subclass == null || subclass.BaseType == null) return Enumerable.Empty<Type>();

			return Enumerable.Repeat(subclass.BaseType, 1)
				.Concat(BaseClasses(subclass.BaseType));
		}
#endif
	}
}