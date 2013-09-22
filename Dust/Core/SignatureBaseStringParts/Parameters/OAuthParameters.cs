using System.Collections.Generic;
using Dust.Lang;

namespace Dust.Core.SignatureBaseStringParts.Parameters
{
    public class OAuthParameters
    {
        private readonly ConsumerKey _key;
        private readonly TokenKey _tokenKey;
        private readonly string _signatureMethod;
        private readonly string _timestamp;
        private readonly string _nonce;
    	private readonly string _signature;
    	private readonly string _version;

    	public OAuthParameters(
			ConsumerKey key, 
			TokenKey tokenKey,
			string signatureMethod, 
			string timestamp, 
			string nonce, 
			string signature,
			string version
		)
        {
            _key = key;
            _tokenKey = tokenKey;
            _signatureMethod = signatureMethod;
            _timestamp = timestamp;
            _nonce = nonce;
        	_signature = signature;
    		_version = version;
    	}

        public static OAuthParameters Empty = new OAuthParameters(
            new ConsumerKey(string.Empty), 
            new TokenKey(string.Empty), 
            string.Empty, 
            string.Empty, 
            string.Empty, 
			string.Empty, 
			string.Empty
        );

        internal List<Parameter> List()
        {
            return new List<Parameter>
            {
                new Parameter(Name.Version, "1.0"),
                new Parameter(Name.ConsumerKey, _key.Value),
                new Parameter(Name.SignatureMethod, _signatureMethod),
                new Parameter(Name.Timestamp, _timestamp),
                new Parameter(Name.Nonce, _nonce)
            }.Tap(it => {
				if (_tokenKey.Exists) {
					it.Add(new Parameter(Name.Token, _tokenKey.Value));
				}
			});
        }
    }
}