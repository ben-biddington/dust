using System.Text.RegularExpressions;
using Dust.Http;

namespace Wiki.Machinery.Http {
	public static class AuthorizationHeaderExtensions {
		public static bool Matches(this AuthorizationHeader self, string pattern) {
			return Regex.IsMatch(self.Value, pattern);
		}
	}
}