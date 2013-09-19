using System;

namespace Dust.Core {
	internal class EarlPart {
		private readonly Uri _uri;

		internal EarlPart(Uri uri) {
			_uri = uri;
		}

		internal string Value {
			get { return string.Format("{0}://{1}", _uri.Scheme, Authority); }
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