using System;
using Dust.Core.SignatureBaseStringParts;
using fit.Fixtures;

namespace Wiki.Machinery
{
    public class OAuthParameterCollectingFixture : RowEntryFixture
    {
        public string ConsumerKey,Token,SignatureMethod;

        public override void Reset()
        {
            ConsumerKey = Token = SignatureMethod = null;
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
                    SignatureMethod
                ));
            }
        }

        public event Action<OAuthParameters> Added;
    }
}