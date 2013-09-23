using Dust.Core.SignatureBaseStringParts.Parameters;
using Dust.Http;
using Dust.Lang;
using fit;
using fitlibrary;

namespace Wiki.Machinery {
	public class AuthorizationHeaderFlowFixture : DoFixture {
		private RequestElementCollectionFixture _parts;
		private OAuthParameters _oauthParameters;

		public Fixture Given_the_request_elements() {
			return _parts = new RequestElementCollectionFixture();
		}	

		public Fixture Given_the_oauth_options() {
            return new OAuthParameterCollectingFixture().Tap(it =>
                it.Added += opts => _oauthParameters = opts
            );
		}

		public Fixture Then_it_equals(string what) {
			string result = new AuthorizationHeader(_oauthParameters).Value;
			return new YesNoFixture(result.Equals(what), "Expected [" +  what + "]. Got [" + result + "]", 2);
		}
	}
}