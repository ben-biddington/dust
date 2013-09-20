namespace Dust.Core
{
    internal struct Parameter
    {
        private readonly string _name;
        private readonly string _value;

        internal Parameter(string name, string value)
        {
            _name = name;
            _value = value;
        }

        internal string Name
        {
            get { return _name; }
        }

        internal string Value
        {
            get { return _value; }
        }

        public override string ToString()
        {
            return string.Format("{0}={1}", Name, Escape(Value));
        }

        private string Escape(string what)
        {
            return new UrlEncoding().Escape(what);
        }
    }
}