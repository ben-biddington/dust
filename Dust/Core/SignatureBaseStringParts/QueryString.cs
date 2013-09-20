using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Dust.Core.SignatureBaseStringParts
{
    internal class QueryString
    {
        private readonly NameValueCollection _values;

        internal Parameters Parameters { get; private set; }

        public QueryString(Request request)
        {
            _values = HttpUtility.ParseQueryString(request.Url.Query);

            var keys = _values.AllKeys;

            IEnumerable<Parameter> parameters = keys.SelectMany<string,Parameter>(Map);

            Parameters = new Parameters(parameters.ToArray());
        }

        private IEnumerable<Parameter> Map(string key)
        {
            var value = _values[key];

            return value.Split(',').Select(v => new Parameter(key, v));
        }
    }
}