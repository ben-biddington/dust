using System.Collections.Generic;

namespace Dust.Core.SignatureBaseStringParts
{
    public class OAuthParameters
    {
        private readonly ConsumerKey _key;

        public OAuthParameters(ConsumerKey key)
        {
            _key = key;
        }

        public static OAuthParameters Empty = new OAuthParameters(new ConsumerKey(string.Empty));

        internal List<Parameter> List()
        {
            return new List<Parameter>
            {
                new Parameter("oauth_version", "1.0"),
                new Parameter("oauth_consumer_key", _key.Value)
            };
        }
    }
}