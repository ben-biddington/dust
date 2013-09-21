using System;
using Dust.Core;
using Dust.Core.SignatureBaseStringParts;
using Dust.Core.SignatureBaseStringParts.Parameters;
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

		public void Given_the_request_parameters(string what) {
			_parts = new RequestElementCollectionFixture() {
				Url = string.Format("http://xxx?{0}", what)
			};
		}

        public Fixture And_oauth_options()
        {
            return new OAuthParameterCollectingFixture().Tap(it =>
                it.Added += opts => _oauthParameters = opts
            );
        }

		public Fixture Then_the_base_string_matches(string what) {
			return new YesNoFixture(BaseString.Matches(Uri.EscapeDataString(what)), "Expected [" + BaseString.Value + "] to match pattern [" +  what + "]", 2);
		}

		public Fixture Then_the_base_string_equals(string what) {
			return new YesNoFixture(BaseString.Value == what, 
				"Expected [" + BaseString.Value + "] to equal [" +  what + "]", 2
			);
		}

		public Fixture Then_the_base_string_contains(string what) {
            return new YesNoFixture(BaseString.Contains(what), "Expected [" + BaseString.Value + "] to contain [" + what + "]", 2);
		}

        public Fixture And_it_does_not_contain(string what) {
        	return Then_it_does_not_contain(what);
        }

		public Fixture Then_it_does_not_contain(string what)
        {
            return new YesNoFixture(BaseString.Omits(what), "Expected [" + BaseString.Value + "] NOT to contain [" + what + "]", 2);
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
