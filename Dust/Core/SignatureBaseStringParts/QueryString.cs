using System;
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

        	Parameters = new Parameters(MapAll());
        }

    	private Parameter[] MapAll() {
    		return _values.AllKeys.SelectMany<string,Parameter>(Map).ToArray();
    	}

    	private IEnumerable<Parameter> Map(string key)
        {
    		return ValueFor(key).Split(',').Select(v => new Parameter(key, v));
        }

    	private string ValueFor(string key) {
    		return _values[key];
    	}
    }
}