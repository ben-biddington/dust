using System;

namespace Wiki.Machinery {
	internal class EarlPart {
		private readonly Uri _uri;

		public EarlPart(Uri uri) {
			_uri = uri;
		}

		public string Value {
			get { return string.Format("{0}://{1}", _uri.Scheme, _uri.Authority); }
		}
	}
}