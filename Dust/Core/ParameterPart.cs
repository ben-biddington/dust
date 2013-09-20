namespace Dust.Core
{
    internal class ParameterPart
    {
        private readonly Request _request;

        internal string Value
        {
            get
            {
                return Parameters.ToString();
            }
        }

        private Parameters Parameters
        {
            get
            {
                return new QueryString(_request).Parameters;
            }
        }

        internal ParameterPart(Request request)
        {
            _request = request;
        }
    }
}