using System;
using System.IO;
using System.Net;
using Dust;
using Dust.Core;
using Dust.Core.SignatureBaseStringParts.Parameters;
using Dust.Core.SignatureBaseStringParts.Parameters.Nonce;
using Dust.Http;
using fit;
using fitlibrary;
using Wiki.Machinery.Support;

namespace Wiki.Machinery.Examples {
	public class TwitterConnectionFlowFixture : DoFixture {
		private Consumer _consumer;

		public void Assuming_we_have_a_consumer_for_twitter() {
			_consumer = Settings.Twitter;
		}

		public Fixture Then_we_can_obtain_a_request_token() {
			var oAuthParameters = new OAuthParameters(
				_consumer.ConsumerKey, 
				new TokenKey(string.Empty), 
				"HMAC-SHA1", 
				new DefaultTimestampSequence().Next(), 
				new DefaultNonceSequence(), 
				string.Empty, 
				"1.0"
			);
			
			var signatureBaseString =
				new SignatureBaseString(
					new Request {
						Url = new Uri("https://api.twitter.com/oauth/request_token"), 
						Verb = "GET"
					},
					oAuthParameters
				);

			var signature = new HmacSha1().Sign(signatureBaseString.Value, _consumer.Secret, null);

			oAuthParameters.SetSignature(signature);

			var header = new AuthorizationHeader(oAuthParameters, string.Empty);

			var req = (HttpWebRequest)WebRequest.Create("https://api.twitter.com/oauth/request_token");

			req.Headers.Add("Authorization", header.Value);

			Console.WriteLine(header.Value);

			using (var response = (HttpWebResponse)req.GetResponse()) {
				var expected = HttpStatusCode.OK;
				var actual = response.StatusCode;
				
				using(var rdr = new StreamReader(response.GetResponseStream()))

				return new YesNoFixture(actual == expected, "Expected [" + expected +"]. Got [" +  actual+ "]", 2);
			}
		}
	}

	public class Consumer {
		private readonly ConsumerKey _consumerKey;
		private readonly string _secret;

		public Consumer(ConsumerKey consumerKey, string secret) {
			_consumerKey = consumerKey;
			_secret = secret;
		}

		public ConsumerKey ConsumerKey {
			get { return _consumerKey; }
		}

		public string Secret {
			get { return _secret; }
		}
	}
}
