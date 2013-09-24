using System;

namespace Dust.Core.SignatureBaseStringParts.Parameters.Nonce {
	public class DefaultTimestampSequence : TimestampSequence {
		public string Next() {
			TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
			int secondsSinceEpoch = (int)t.TotalSeconds;
			return secondsSinceEpoch.ToString();
		}
	}
}