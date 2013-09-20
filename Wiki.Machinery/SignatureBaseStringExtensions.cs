using System.Text.RegularExpressions;
using Dust.Core;

namespace Wiki.Machinery {
	public static class SignatureBaseStringExtensions {
		public static bool Matches(this SignatureBaseString self, string pattern) {
			return Regex.IsMatch(self.Value, pattern);
		}

        public static bool Omits(this SignatureBaseString self, string pattern)
        {
            return false == self.Value.Contains(pattern);
        }

		public static bool Contains(this SignatureBaseString self, string pattern) {
			return self.Value.Contains(pattern);
		}
	}
}