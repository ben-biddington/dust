using System;
using System.Collections.Generic;
using System.Linq;
using Dust.Lang;

namespace Dust.Core.SignatureBaseStringParts
{
    internal class Parameters
    {
        private readonly List<Parameter> _parameters;

        internal Parameters(params Parameter[] parameters)
        {
            _parameters = parameters.ToList();
        }

        internal void Add(params Parameter[] parameter)
        {
            _parameters.AddRange(parameter);
        }

        public override string ToString()
        {
            return string.Join("&", Sort().Select(it => it.ToString()).ToArray());
        }

        private IEnumerable<Parameter> Sort()
        {
            return _parameters.ToArray().Tap(it => Array.Sort(it, new ParameterComparison()));
        }
    }
}