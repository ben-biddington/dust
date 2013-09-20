using System.Collections.Generic;
using System.Security.Principal;

namespace Dust.Core.SignatureBaseStringParts
{
    public class OAuthParameters
    {
        private readonly ConsumerKey _key;
        private readonly TokenKey _tokenKey;

        public OAuthParameters(ConsumerKey key, TokenKey tokenKey)
        {
            _key = key;
            _tokenKey = tokenKey;
        }

        public static OAuthParameters Empty = new OAuthParameters(new ConsumerKey(string.Empty), new TokenKey(string.Empty));

        internal List<Parameter> List()
        {
            return new List<Parameter>
            {
                new Parameter("oauth_version", "1.0"),
                new Parameter("oauth_consumer_key", _key.Value),
                new Parameter("oauth_token", _tokenKey.Value)
            };
        }
    }
}