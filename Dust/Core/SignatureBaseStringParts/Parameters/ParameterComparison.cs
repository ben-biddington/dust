using System;
using System.Collections.Generic;

namespace Dust.Core.SignatureBaseStringParts.Parameters
{
    internal class ParameterComparison : IComparer<Parameter>
    {
        public int Compare(Parameter x, Parameter y)
        {
            int result = CompareCore(x.Name, y.Name);

            var sameName = result == 0;

            return sameName ? CompareValues(x,y) : result;
        }

        private int CompareValues(Parameter x, Parameter y) {
        	return CompareCore(x.Value, y.Value);
        }

    	private int CompareCore(string x, string y) {
    		return string.Compare(x, y, StringComparison.InvariantCulture);
    	}
    }
}