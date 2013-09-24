using System.Collections.Generic;
using Dust.Core.SignatureBaseStringParts.Parameters.Nonce;
using Dust.Lang;

namespace Dust.Core.SignatureBaseStringParts.Parameters
{
	public class OAuthParameters
    {
        private readonly ConsumerKey _key;
        private readonly TokenKey _tokenKey;
        private readonly string _signatureMethod;
        private readonly string _timestamp;
        private readonly NonceSequence _nonce;
    	private string _signature;
    	private readonly string _version;

    	public OAuthParameters(
			ConsumerKey key, 
			TokenKey tokenKey, 
			string signatureMethod, 
			string timestamp, 
			NonceSequence nonce, 
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
    		_version = version ?? "1.0";
    	}

        public static OAuthParameters Empty = new OAuthParameters(
            new ConsumerKey(string.Empty), 
            new TokenKey(string.Empty), 
            string.Empty, 
            string.Empty, 
            new DefaultNonceSequence(), 
			string.Empty, 
			null
        );

    	internal List<Parameter> List()
        {
            return new List<Parameter>
            {
            	ConsumerKey, 
                Version,
				SignatureMethod,
                Timestamp,
                Nonce
            }.Tap(it => {
				if (_tokenKey.Exists) {
					it.Add(Token);
				}
			}).Tap(it => it.Sort(new ParameterComparison()));
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
    		get { return new Parameter(Name.Nonce, _nonce.Next()); }
    	}

    	internal Parameter Version {
    		get { return new Parameter(Name.Version, _version); }
    	}
    }
}