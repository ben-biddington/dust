using System;
using System.Text.RegularExpressions;

namespace Dust.Core {
	public class SignatureBaseString {
		private readonly string _url;

		public SignatureBaseString(string url) {
			_url = url;
		}

		public bool Contains(string what) {
			return Regex.IsMatch(what, Value);
		}

		protected string Value {
			get { return new EarlPart(new Uri(_url)).Value; }
		}
	}
}