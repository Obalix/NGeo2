using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace NGeo.GeoNames.Exceptions
{
	[JsonObject("status", ItemConverterType =typeof(Json.GeoNamesExceptionConverter))]
	public class GeoNamesException : Exception
	{
		public GeoNamesException(string message, int? errorCode = null, HttpStatusCode? statusCode = null, Exception inner = null) : base(message, inner)
		{
			this.ErrorCode = errorCode;
			this.HttpStatusCode = statusCode;
		}

		public int? ErrorCode { get; private set; }

		public HttpStatusCode? HttpStatusCode { get; private set; }

		public override string Message => base.Message;
	}
}
