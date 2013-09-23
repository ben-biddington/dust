using Dust.Core.SignatureBaseStringParts.Parameters;
using Dust.Http;
using Dust.Lang;
using fit;
using fitlibrary;
using Wiki.Machinery.Support;

namespace Wiki.Machinery.Http {
	public class AuthorizationHeaderFlowFixture : DoFixture {
		private OAuthParameters _oauthParameters;
		private string _realm;

		public Fixture Given_the_oauth_options() {
            return new OAuthParameterCollectingFixture().Tap(it =>
                it.Added += opts => _oauthParameters = opts
            );
		}

		public void And_realm(string what) {
			_realm = what;
		}

		public Fixture Then_it_equals(string what) {
			string result = new AuthorizationHeader(_oauthParameters, _realm).Value;
			return new YesNoFixture(result.Equals(what), "Expected [" +  what + "]. Got [" + result + "]", 2);
		}

		public Fixture Then_it_matches(string what) {
			var result = new AuthorizationHeader(_oauthParameters, _realm);
			return new YesNoFixture(result.Matches(what), "Expected [" +  what + "]. Got [" + result + "]", 2);
		}
	}
}