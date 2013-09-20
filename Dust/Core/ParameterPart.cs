using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dust.Core {
	internal class ParameterPart {
		private readonly Request _request;

		internal string Value {
			get {
			    var parameters = Parameters();

			    var result = parameters.Select(it => it.ToString());

				return string.Join("&", result.ToArray());
			}
		}

	    private IEnumerable<Parameter> Parameters()
	    {
	        var nameValueCollection = HttpUtility.ParseQueryString(_request.Url.Query);

	        var keys = nameValueCollection.AllKeys;

	        Array.Sort(keys, new KeyComparison());

	        return keys.Select(key => new Parameter(key, nameValueCollection[key]));
	    }

		internal ParameterPart(Request request) {
			_request = request;
		}
	}

	internal class UrlEncoding {
		internal string Escape(string what) {
			return Uri.EscapeDataString(what);
		}
	}

	internal class KeyComparison : IComparer<string> {
		public int Compare(string x, string y) {
			return string.Compare(x, y);
		}
	}
}