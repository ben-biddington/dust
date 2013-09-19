using System;
using System.Collections.Generic;
using System.Web;

namespace Dust.Core {
	internal class ParameterPart {
		private readonly Request _request;

		internal string Value {
			get {
				var nameValueCollection = HttpUtility.ParseQueryString(_request.Url.Query);

				var result = new List<string>();

				var keys = nameValueCollection.AllKeys;

				Array.Sort(keys, new KeyComparison());

				foreach (var key in keys) {
					result.Add(string.Format("{0}={1}", key, Escape(nameValueCollection[key])));
				}

				return string.Join("&", result.ToArray());
			}
		}

		private object Escape(string what) {
			return new UrlEncoding().Escape(what);
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