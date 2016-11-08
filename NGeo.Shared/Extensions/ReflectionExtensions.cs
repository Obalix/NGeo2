namespace System.Reflection
{
	public static class ReflectionExtensions
	{
		public static bool IsSameOrSubClass(this TypeInfo subclass, TypeInfo baseclass)
			=> subclass.IsSubclassOf(baseclass.AsType()) || subclass == baseclass;

		public static bool IsSameOrSubClass(this TypeInfo subclass, Type baseclass)
			=> IsSameOrSubClass(subclass, baseclass?.GetTypeInfo());
	}
}