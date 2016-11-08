using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NGeo.Shared.GeoNames.Exceptions
{
	[JsonObject("status", ItemConverterType =typeof(Json.GeoNamesExceptionConverter))]
	public class GeoNamesException : Exception
	{
		public GeoNamesException(string message, int? errorCode = null, Exception inner = null) : base(message, inner)
		{
			this.ErrorCode = errorCode;
		}

		public int? ErrorCode { get; private set; }

		public override string Message => base.Message;
	}
}
