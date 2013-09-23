using Dust.Core.SignatureBaseStringParts.Parameters;
using System.Linq;

namespace Dust.Http {
	public class AuthorizationHeader {
		private readonly OAuthParameters _oAuthParameters;
		private readonly string _realm;

		public AuthorizationHeader(OAuthParameters oAuthParameters, string realm) {
			_oAuthParameters = oAuthParameters;
			_realm = realm;
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
			return string.Join(", ", bits.Where(it => false == it.Equals(string.Empty)).ToArray());
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
			get {
				return HasRealm ? string.Format("realm=\"{0}\"", _realm) : string.Empty; 
			}
		}

		private bool HasRealm {
			get { return _realm != null; }
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