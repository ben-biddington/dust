using System;
using Dust.Core;
using fit;
using fitlibrary;

namespace Wiki.Machinery {
	public class SignatureBaseStringFlowFixture : DoFixture {
		private RequestElementCollectionFixture _parts;

		public Fixture Given_the_request_elements() {
			return _parts = new RequestElementCollectionFixture();
		}

		public Fixture Given_the_pieces() {
			return _parts = new RequestElementCollectionFixture();
		}

		public bool Then_the_base_string_matches(string what) {
			return BaseString.Matches(what);
		}

		public bool Then_the_base_string_contains(string what) {
			return BaseString.Contains(what);
		}

		private SignatureBaseString BaseString {
			get {
				return new SignatureBaseString(
					new Request {
						Url = new Uri(_parts.Url),
					    Verb = _parts.HttpRequestMethod ?? "GET"
					}
				);
			}
		}
	}
}
