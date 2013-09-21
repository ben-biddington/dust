using System;
using Dust;
using Dust.Core;
using Dust.Core.SignatureBaseStringParts;
using Dust.Core.SignatureBaseStringParts.Parameters;
using fit.Fixtures;

namespace Wiki.Machinery
{
    public class OAuthParameterCollectingFixture : RowEntryFixture
    {
        public string ConsumerKey,Token,SignatureMethod,Timestamp,Nonce;

        public override void Reset()
        {
            ConsumerKey = Token = SignatureMethod = Timestamp = Nonce = null;
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
                    Timestamp, 
                    Nonce
                ));
            }
        }

        public event Action<OAuthParameters> Added;
    }
}