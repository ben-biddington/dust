using System.Collections.Generic;

namespace Dust.Core.SignatureBaseStringParts
{
    public class OAuthParameters
    {
        private readonly ConsumerKey _key;
        private readonly TokenKey _tokenKey;
        private readonly string _signatureMethod;
        private readonly string _timestamp;

        public OAuthParameters(ConsumerKey key, TokenKey tokenKey, string signatureMethod, string timestamp)
        {
            _key = key;
            _tokenKey = tokenKey;
            _signatureMethod = signatureMethod;
            _timestamp = timestamp;
        }

        public static OAuthParameters Empty = new OAuthParameters(
            new ConsumerKey(string.Empty), 
            new TokenKey(string.Empty), 
            string.Empty, 
            string.Empty
        );

        internal List<Parameter> List()
        {
            return new List<Parameter>
            {
                new Parameter("oauth_version", "1.0"),
                new Parameter("oauth_consumer_key", _key.Value),
                new Parameter("oauth_token", _tokenKey.Value),
                new Parameter("oauth_signature_method", _signatureMethod),
                new Parameter("oauth_timestamp", _timestamp)
            };
        }
    }
}