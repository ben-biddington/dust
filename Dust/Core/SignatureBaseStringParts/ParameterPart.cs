using Dust.Lang;

namespace Dust.Core.SignatureBaseStringParts
{
    internal class ParameterPart
    {
        private readonly OAuthParameters _oAuthParameters;
        private readonly Request _request;

        internal ParameterPart(Request request, OAuthParameters oAuthParameters)
        {
            _request = request;
            _oAuthParameters = oAuthParameters;
        }

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
                return new QueryString(_request).Parameters.Tap(it => it.Add(OAuthParameters));
            }
        }

        private Parameter[] OAuthParameters {
            get
            {
                return _oAuthParameters.List().ToArray();
            }
        }
    }
}