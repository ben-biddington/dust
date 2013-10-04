using System;
using System.IO;
using System.Net;
using Dust;
using Dust.Core;
using Dust.Core.SignatureBaseStringParts.Parameters;
using Dust.Core.SignatureBaseStringParts.Parameters.Nonce;
using Dust.Core.SignatureBaseStringParts.Parameters.Timestamp;
using Dust.Http;
using fit;
using fitlibrary;
using Wiki.Machinery.Http;
using Wiki.Machinery.Support;

namespace Wiki.Machinery.Examples {
    public class TwitterConnectionFlowFixture : DoFixture {
		private Consumer _consumer;

		public void Assuming_we_have_a_consumer_for_twitter() {
			_consumer = Settings.Twitter;
		}

		public Fixture Then_we_can_connect() {
			var oAuthParameters = new OAuthParameters(
				_consumer.ConsumerKey, 
				new TokenKey(string.Empty), 
				"HMAC-SHA1", 
				new DefaultTimestampSequence(), 
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

            var response = TInternet.Get(req);
            const HttpStatusCode expected = HttpStatusCode.OK;
            var actual = response.StatusCode;

		    return new YesNoFixture(actual == expected, "Expected [" + expected +"]. Got [" +  actual+ "]", 2);
		}
	}
}
