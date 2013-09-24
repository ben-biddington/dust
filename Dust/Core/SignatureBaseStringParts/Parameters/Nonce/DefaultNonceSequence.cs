using System;

namespace Dust.Core.SignatureBaseStringParts.Parameters.Nonce {
	public class DefaultNonceSequence : NonceSequence {
		public string Next() {
			return string.Empty;
		}
	}

	public class DefaultTimestampSequence {
		public string Next() {
			TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
			int secondsSinceEpoch = (int)t.TotalSeconds;
			return secondsSinceEpoch.ToString();
		}
	}
}