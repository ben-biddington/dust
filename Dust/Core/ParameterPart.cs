using System.Collections.Generic;
using Dust.Lang;

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
                return new QueryString(_request).Parameters.Tap(it => it.Add(OAuthParameters));
            }
        }

        private Parameter[] OAuthParameters {
            get
            {
                return new OAuthParameters().List().ToArray();
            }
        }

        internal ParameterPart(Request request)
        {
            _request = request;
        }
    }

    internal class OAuthParameters
    {
        internal List<Parameter> List()
        {
            return new List<Parameter>()
            {
                new Parameter("oauth_version", "1.0")
            };
        }
    }
}