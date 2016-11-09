using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NGeo.GeoNames.Exceptions;
using NGeo.GeoNames.Model;

namespace NGeo.GeoNames.Responses
{
	public class ErrorResponse : QueryResponse<NGeoItem>, IGeoNameResponse
	{
		public static Task<ErrorResponse> FromJson(string json)
		{
			return SerializationHelper.FromJson<ErrorResponse>(json);
		}

		public static Task<ErrorResponse> FromXml(XElement el)
		{
			return SerializationHelper.FromXml<ErrorResponse>(
				el,
				r => SyncToTaskFactory.CreateTask(
					() => {
						var status = el.Element("status");
						r.Exception = new GeoNamesException((string)status.Attribute("message"), errorCode: (int?)status.Attribute("value"));
					}
				)
			);
		}

		public ErrorResponse() { }

		public ErrorResponse(GeoNamesException ex) { this.Exception = ex; }

		public override NGeoItem[] Items { get; protected set; }
	}
}
