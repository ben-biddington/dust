using Dust;
using Dust.Core;
using fit;
using fitlibrary;

namespace Wiki.Machinery {
	public class HmacSigningFlowFixture : DoFixture {
		private string _signatureBaseString;
		private string _consumerSecret;
		private string _tokenSecret;

		public void Given_the_signature_base_string(string what) {
			_signatureBaseString = what;
		}

		public void And_consumer_secret(string what) {
			_consumerSecret = what;
		}

		public void And_token_secret(string what) {
			_tokenSecret = what;
		}

		public Fixture Then_the_signature_is(string expected) {
			string actual = new Consumer().Sign(_signatureBaseString, _consumerSecret, _tokenSecret);

			return new YesNoFixture(expected == actual, 
				"Invalid signature. Expected [" +  expected + "]. Got [" + actual + "].", 2
			);
		}
	}
}