using System;
using Dust.Core;
using Dust.Core.SignatureBaseStringParts;
using Dust.Lang;
using fit;
using fitlibrary;

namespace Wiki.Machinery {
	public class SignatureBaseStringFlowFixture : DoFixture {
		private RequestElementCollectionFixture _parts;
	    private OAuthParameters _oauthParameters = OAuthParameters.Empty;

		public Fixture Given_the_request_elements() {
			return _parts = new RequestElementCollectionFixture();
		}

		public Fixture Given_the_pieces() {
			return _parts = new RequestElementCollectionFixture();
		}

        public Fixture And_oauth_options()
        {
            return new NameValueCollectionFixture().Tap(it =>
                it.Added += opts => _oauthParameters = opts
            );
        }

		public Fixture Then_the_base_string_matches(string what) {
			return new YesNoFixture(BaseString.Matches(what), "Expected [" + BaseString.Value + "] to match pattern [" +  what + "]", 2);
		}

		public Fixture Then_the_base_string_contains(string what) {
            return new YesNoFixture(BaseString.Contains(what), "Expected [" + BaseString.Value + "] to contain [" + what + "]", 2);
		}

		private SignatureBaseString BaseString {
			get {
				return new SignatureBaseString(
					new Request {
						Url = new Uri(_parts.Url),
					    Verb = _parts.HttpRequestMethod ?? "GET"
					}, 
                    _oauthParameters
				);
			}
		}
	}
}
