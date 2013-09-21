using Dust.Lang;

namespace Dust.Core.SignatureBaseStringParts.Parameters {
	internal class ParameterPart {
		private readonly OAuthParameters _oAuthParameters;
		private readonly Request _request;

		internal ParameterPart(Request request, OAuthParameters oAuthParameters) {
			_request = request;
			_oAuthParameters = oAuthParameters;
		}

		internal string Value {
			get {
				return Escape(Parameters.ToString());
			}
		}

		private string Escape(string what) {
			return new ParameterEncoding().Escape(what);
		}

		private Parameters Parameters {
			get {
				return new QueryString(_request).Parameters.Tap(it => it.Add(OAuthParameters));
			}
		}

		private Parameter[] OAuthParameters {
			get {
				return _oAuthParameters.List().ToArray();
			}
		}
	}
}