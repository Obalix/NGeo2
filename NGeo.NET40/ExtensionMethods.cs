using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

#if (PCL45)

using System.Reflection;

#endif

namespace NGeo
{
    internal static class ExtensionMethods
    {
        internal static EnumMemberAttribute GetEnumMemberAttribute(this Enum value)
        {
            var type = value.GetType();
			// ReSharper disable SpecifyACultureInStringConversionExplicitly
#if (PCL45)
			var fieldInfo = type.GetRuntimeField(value.ToString());
#else
			var fieldInfo = type.GetField(value.ToString());
#endif
            // ReSharper restore SpecifyACultureInStringConversionExplicitly
            var attributes = fieldInfo.GetCustomAttributes(
                typeof(EnumMemberAttribute), false) as EnumMemberAttribute[];
            return (attributes != null && attributes.Length > 0) ? attributes[0] : null;
        }

        internal static void ApplyDefaultValues(this object value)
        {

#if (PCL45)
			foreach (var prop in value.GetType().GetRuntimeProperties())
			{
				//var attr = prop.CustomAttributes.OfType<DefaultValueAttribute>().FirstOrDefault() as DefaultValueAttribute;
				//var attr = prop.CustomAttributes.Select(x => x.)
				var attr = prop.GetCustomAttribute<DefaultValueAttribute>();

				if (attr != null)
					prop.SetValue(value, attr.Value);
			}
#else
			foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(value))
			{
                var attr = prop.Attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
				
                if (attr != null)
                    prop.SetValue(value, attr.Value);
            }
#endif
		}

		internal static string ToNullIfEmptyOrWhiteSpace(this string mayBeEmptyOrWhiteSpace)
        {
            return (!string.IsNullOrWhiteSpace(mayBeEmptyOrWhiteSpace)) ? mayBeEmptyOrWhiteSpace : null;
        }

    }
}
