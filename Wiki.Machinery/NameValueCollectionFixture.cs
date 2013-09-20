using System;
using Dust.Core.SignatureBaseStringParts;
using fit.Fixtures;

namespace Wiki.Machinery
{
    public class NameValueCollectionFixture : RowEntryFixture
    {
        public string ConsumerKey;

        public override void Reset()
        {
            ConsumerKey = null;
        }

        public override void EnterRow()
        {
            NotifyAdded();
        }

        private void NotifyAdded()
        {
            if (Added != null)
            {
                Added(new OAuthParameters(new ConsumerKey(ConsumerKey)));
            }
        }

        public event Action<OAuthParameters> Added;
    }
}