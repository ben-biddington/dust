using System;

namespace Dust.Core.SignatureBaseStringParts {
	internal class EarlPart {
		private readonly Uri _uri;

		internal EarlPart(Uri uri) {
			_uri = uri;
		}

		internal string Value {
			get {
				return Escape(string.Format("{0}://{1}{2}", _uri.Scheme, Authority, Path()));
			}
		}

		private string Path() {
			return _uri.LocalPath.TrimEnd('/');
		}

		private string Escape(string what) {
			return new UrlEncoding().Escape(what);
		}

		private string Authority {
			get {
				if (_uri.Port == 80 || _uri.Port == 443)
					return _uri.Host;

				return _uri.Authority;
			}
		}
	}
}