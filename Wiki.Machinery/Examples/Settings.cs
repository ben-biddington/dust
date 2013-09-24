using System.Configuration;
using Dust;

namespace Wiki.Machinery.Examples {
	internal static class Settings {
		internal static Consumer Twitter {
			get {
				var settings = ConfigurationManager.AppSettings;
				
				return new Consumer(
					new ConsumerKey(settings["twitter.consumer.key"]), 
					settings["twitter.consumer.secret"]
				);
			}
		}	
	}
}