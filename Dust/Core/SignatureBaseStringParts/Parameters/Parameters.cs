using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dust.Core.SignatureBaseStringParts.Parameters {
	internal class Parameters : IEnumerable<Parameter> {
		private readonly List<Parameter> _parameters;

		internal Parameters(params Parameter[] parameters) {
			_parameters = parameters.ToList();
		}

		internal void Add(params Parameter[] parameter) {
			_parameters.AddRange(parameter);
			Sort();
		}

		internal void Add(IEnumerable<Parameter> parameters) {
			_parameters.AddRange(parameters);
			Sort();
		}

		private void Sort() {
			_parameters.Sort(new ParameterComparison());
		}

		public override string ToString() {
			return string.Join("&", _parameters.Select(it => it.ToString()).ToArray());
		}

		public IEnumerator<Parameter> GetEnumerator() {
			return _parameters.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}