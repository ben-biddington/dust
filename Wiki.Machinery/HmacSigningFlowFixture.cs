using System;
using System.Security.Cryptography;
using System.Text;
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

	internal class Consumer {
		public string Sign(string signatureBaseString, string consumerSecret, string tokenSecret) {
			var key = string.Format("{0}&{1}", consumerSecret, tokenSecret);

			var signature = SignCore(signatureBaseString, key);

			return Base64Encode(signature);
		}

		private string Base64Encode(byte[] bytes) {
			return Convert.ToBase64String(bytes);
		}

		private byte[] SignCore(string text, string key) {
			var encoding = Encoding.ASCII;

			byte[] keyBytes = encoding.GetBytes(key);
			byte[] textBytes = encoding.GetBytes(text);

			using (var hmac = new HMACSHA1(keyBytes)) {
				return hmac.ComputeHash(textBytes);
			}
		}
	}
}