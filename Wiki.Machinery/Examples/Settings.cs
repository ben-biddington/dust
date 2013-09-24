using System;
using System.Configuration;
using Dust;
using Dust.Lang;

namespace Wiki.Machinery.Examples {
	internal static class Settings {
		internal static Consumer Twitter {
			get { return new Consumer(new ConsumerKey(Key), Secret); }
		}

		private static string Key { get { return SettingFor("twitter.consumer.key"); } }
		private static string Secret { get { return SettingFor("twitter.consumer.secret"); } }

		private static string SettingFor(string name) {
			return ConfigurationManager.AppSettings[name].Tap(it => {
				if (null == it)
	                throw new Exception("Unable to locate appsetting for [" + name + "]. Do you have an App.config?");                                  	
			});
		}
	}
}