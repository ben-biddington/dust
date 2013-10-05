using Dust.Core.SignatureBaseStringParts.Parameters.Nonce;
using Dust.Core.SignatureBaseStringParts.Parameters.Timestamp;
using Dust.Lang;

namespace Dust.Core.SignatureBaseStringParts.Parameters
{
	public class OAuthParameters
    {
        private readonly ConsumerKey _key;
        private readonly TokenKey _tokenKey;
        private readonly string _signatureMethod;
	    private string _signature;
    	private readonly string _version;
        private readonly string _nonce, _timestamp;

	    public static OAuthParameters Empty = new OAuthParameters(
	        new ConsumerKey(string.Empty), 
	        new TokenKey(string.Empty), 
	        string.Empty, 
	        new DefaultTimestampSequence(), 
	        new DefaultNonceSequence(), 
	        string.Empty, 
	        null
        );

	    public OAuthParameters(
			ConsumerKey key, 
			TokenKey tokenKey, 
			string signatureMethod, 
			TimestampSequence timestamps, 
			NonceSequence nonces, 
			string signature, 
			string version
		)
        {
    	    _key = key;
            _tokenKey = tokenKey;
            _signatureMethod = signatureMethod;
    	    _signature = signature;
    		_version = version ?? "1.0";

    	    _nonce = nonces.Next();
    	    _timestamp = timestamps.Next();
        }

	    internal Parameters List() {
    		return new Parameters(
    				ConsumerKey,
    				Version,
    				SignatureMethod,
    				Timestamp,
    				Nonce
				).Tap(it => {
					if (_tokenKey.Exists) {
    					it.Add(Token);
					}
				});
    	}

    	internal Parameter Token {
    		get { return new Parameter(Name.Token, _tokenKey.Value); }
    	}

    	internal Parameter ConsumerKey {
    		get { return new Parameter(Name.ConsumerKey, _key.Value); }
    	}

    	internal Parameter SignatureMethod {
    		get { return new Parameter(Name.SignatureMethod, _signatureMethod); }
    	}

		public void SetSignature(string what) {
			_signature = what;
		}

		internal Parameter Signature {
    		get { return new Parameter(Name.Signature, _signature); }
    	}

    	internal Parameter Timestamp {
    		get { return new Parameter(Name.Timestamp, _timestamp); }
    	}

    	internal Parameter Nonce {
    		get { return new Parameter(Name.Nonce, _nonce); }
    	}

    	internal Parameter Version {
    		get { return new Parameter(Name.Version, _version); }
    	}
    }
}