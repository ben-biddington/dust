using System;

namespace Dust.Core {
	public class Request {
		public Uri Url { get; set; }	
		public string Verb { get; set; }	
	}

	public class SignatureBaseString {
		private readonly Request _request;

		public SignatureBaseString(Request request) {
			_request = request;
		}

		public string Value {
			get {
				return RequestMethod + RequestUrl;
			}
		}

		protected string RequestMethod {
			get { return _request.Verb.ToUpper(); }
		}

		private string RequestUrl {
			get { return new EarlPart(_request.Url).Value; }
		}
	}
}