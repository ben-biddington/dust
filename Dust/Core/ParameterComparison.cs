using System;
using System.Collections.Generic;

namespace Dust.Core
{
    internal class ParameterComparison : IComparer<Parameter>
    {
        public int Compare(Parameter x, Parameter y)
        {
            int result = string.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase);

            var sameName = result == 0;

            return sameName ? CompareValues(x,y) : result;
        }

        private int CompareValues(Parameter x, Parameter y)
        {
            return string.Compare(x.Value, y.Value, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}