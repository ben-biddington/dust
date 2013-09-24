using System;
using Dust;
using Dust.Core.SignatureBaseStringParts.Parameters;
using Dust.Core.SignatureBaseStringParts.Parameters.Nonce;
using fit.Fixtures;

namespace Wiki.Machinery
{
    public class OAuthParameterCollectingFixture : RowEntryFixture
    {
        public string ConsumerKey,Token,SignatureMethod,Timestamp,Nonce,Signature,Version;

        public override void Reset()
        {
            ConsumerKey = Token = SignatureMethod = Timestamp = Nonce = Signature = Version = null;
        }

        public override void EnterRow()
        {
            NotifyAdded();
        }

        private void NotifyAdded()
        {
            if (Added != null)
            {
                Added(new OAuthParameters(
                    new ConsumerKey(ConsumerKey), 
                    new TokenKey(Token), 
                    SignatureMethod, 
                    new DummyTimestampSequence(Timestamp), 
                    new DummyNonceSequence(Nonce), 
					Signature, 
					Version
                ));
            }
        }

        public event Action<OAuthParameters> Added;
    }

	internal class DummyTimestampSequence : TimestampSequence {
		private readonly string _timestamp;

		public DummyTimestampSequence(string timestamp) {
			_timestamp = timestamp;
		}

		public string Next() {
			return _timestamp;
		}
	}

	internal class DummyNonceSequence : NonceSequence {
		private readonly string _value;

		public DummyNonceSequence(string value) {
			_value = value;
		}

		public string Next() {
			return _value;
		}
	}
}