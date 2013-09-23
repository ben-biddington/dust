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
				return Join(
					Realm,
					ConsumerKey,
					Token,
					SignatureMethod,
					Signature,
					Timestamp,
					Nonce,
					Version
				);
			}
		}

		private string Join(params string[] bits) {
			return string.Join(", ", bits);
		}

		private string Version {
			get { return ToString(_oAuthParameters.Version); }
		}

		private string Nonce {
			get { return ToString(_oAuthParameters.Nonce); }
		}

		private string Timestamp {
			get { return ToString(_oAuthParameters.Timestamp); }
		}

		private string Signature {
			get { return ToString(_oAuthParameters.Signature); }
		}

		private string SignatureMethod {
			get { return ToString(_oAuthParameters.SignatureMethod); }
		}

		private string Token {
			get { return ToString(_oAuthParameters.Token);}
		}

		private string ConsumerKey {
			get { return ToString(_oAuthParameters.ConsumerKey); }
		}

		private string Realm {
			get { return "realm=\"http://sp.example.com/\""; }
		}

		private string ToString(Parameter parameter) {
			return string.Format(
				"{0}=\"{1}\"", 
				parameter.Name, 
				Escape(parameter.Value)
			);
		}

		private string Escape(string value) {
			return new ParameterEncoding().Escape(value);
		}

		private string Prefix {
			get { return "OAuth "; }
		}
	}
}