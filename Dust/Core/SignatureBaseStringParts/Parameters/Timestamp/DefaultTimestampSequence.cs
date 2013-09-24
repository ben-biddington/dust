using System;

namespace Dust.Core.SignatureBaseStringParts.Parameters.Timestamp {
	public class DefaultTimestampSequence : TimestampSequence {
		public string Next() {
			TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
			int secondsSinceEpoch = (int)t.TotalSeconds;
			return secondsSinceEpoch.ToString();
		}
	}
}