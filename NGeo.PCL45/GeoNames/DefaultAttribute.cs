using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGeo.GeoNames
{
	
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class DefaultAttribute : Attribute
	{
		public DefaultAttribute(object value)
		{
			this._value = value;
		}

		private object _value;

		public object Value => _value;
	}
}
