using fit;
using fitlibrary;

namespace Wiki.Machinery {
	public class SignatureBaseStringFlowFixture : DoFixture {
		private SignatureCollectionFixture _parts;

		public Fixture Given_the_pieces() {
			return _parts = new SignatureCollectionFixture();
		}

		public bool Then_the_base_string_contains(string what) {
			var baseString = new SignatureBaseString(_parts.Url);
			return baseString.Contains(what);
		}
	}

	public class SignatureCollectionFixture : ColumnFixture {
		public string Url { get; set; }
	}
}
