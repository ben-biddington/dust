using System;
using Dust.Core.SignatureBaseStringParts;

namespace Dust.Core {
	public class Request {
		public Uri Url { get; set; }	
		public string Verb { get; set; }	
	}

	public class SignatureBaseString {
		private readonly Request _request;
	    private readonly OAuthParameters _oAuthParameters;

	    public SignatureBaseString(Request request, OAuthParameters oAuthParameters)
		{
		    _request = request;
		    _oAuthParameters = oAuthParameters;
		}

	    public string Value {
			get {
				return RequestMethod + Ampersand + RequestUrl + Ampersand + Parameters;
			}
		}

		protected string Ampersand {
			get { return "&"; }
		}

		protected string Parameters {
			get { return new ParameterPart(_request, _oAuthParameters).Value; }
		}

		protected string RequestMethod {
			get { return _request.Verb.ToUpper(); }
		}

		private string RequestUrl {
			get { return new EarlPart(_request.Url).Value; }
		}
	}
}