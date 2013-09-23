using System;
using Dust.Core.SignatureBaseStringParts.Parameters;

namespace Dust.Http {
	public class AuthorizationHeader {
		private readonly OAuthParameters _oAuthParameters;

		public AuthorizationHeader(OAuthParameters oAuthParameters) {
			_oAuthParameters = oAuthParameters;
		}

		public string Value {
			get { return Prefix + Parameters; }
		}

		protected string Parameters {
			get {
				return 
					"realm=\"http://sp.example.com/\", " +
					"" + ConsumerKey + ", " +
					"oauth_token=\"ad180jjd733klru7\", " +
					"oauth_signature_method=\"HMAC-SHA1\", " +
					"oauth_signature=\"wOJIO9A2W5mFwDgiDvZbTSMK%2FPY%3D\", " +
					"oauth_timestamp=\"137131200\", " +
					"oauth_nonce=\"4572616e48616d6d65724c61686176\", " +
					"oauth_version=\"1.0\"";
			}
		}

		protected string ConsumerKey {
			get {
				return string.Format("{0}=\"{1}\"", _oAuthParameters.ConsumerKey.Name, _oAuthParameters.ConsumerKey.Value);
			}
		}

		private Parameter Realm {
			get { return new Parameter("realm", "http://sp.example.com"); }
		}

		private string Prefix {
			get { return "OAuth "; }
		}
	}
}