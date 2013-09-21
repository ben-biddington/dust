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

    public class TokenKey
    {
        private readonly string _value;

        public TokenKey(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    	public bool Exists {
    		get { return Value != null; }
    	}
    }
}