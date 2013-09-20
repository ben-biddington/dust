using System;
using System.Linq;

namespace Dust.Core
{
    internal class Parameters
    {
        private readonly Parameter[] _parameters;

        internal Parameters(params Parameter[] parameters)
        {
            Array.Sort(_parameters = parameters, new ParameterComparison());
        }

        public override string ToString()
        {
            return string.Join("&", _parameters.Select(it => it.ToString()).ToArray());
        }
    }
}