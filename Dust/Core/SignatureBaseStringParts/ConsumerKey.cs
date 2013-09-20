namespace Dust.Core.SignatureBaseStringParts
{
    public class ConsumerKey
    {
        public string Value { get; private set; }

        public ConsumerKey(string value)
        {
            Value = value;
        }
    }
}