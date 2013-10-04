using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Dust;
using Dust.Lang;

namespace Wiki.Machinery.Examples {
	internal static class Settings {
		internal static Consumer Twitter {
			get { return ConsumerFor("twitter"); }
		}

	    internal static Consumer Xero
        {
            get { return ConsumerFor("xero"); }
        }

	    public static X509Certificate2 XeroSigningCert {
	        get
	        {
	            var path = SettingFor("xero.signingcert.path");

	            var fullPath = Path.GetFullPath(path);

                if (false == File.Exists(fullPath))
                    throw new FileNotFoundException("The cert file cannot be found.", fullPath);

                return new X509Certificate2(fullPath, SettingFor("xero.signingcert.password"));
	        }
	    }

	    private static Consumer ConsumerFor(string name)
	    {
	        return new Consumer(new ConsumerKey(SettingFor(name,".consumer.key")), SettingFor(name,".consumer.secret"));
	    }

	    private static string SettingFor(params string[] name)
	    {
	        var settingName = string.Join(string.Empty, name);

            return ConfigurationManager.AppSettings[settingName].Tap(it =>
			{
			    if (null == it)
                    throw new Exception("Unable to locate appsetting for [" + settingName + "]. Do you have an App.config?");

                if (it.Trim().StartsWith("YOUR_"))
                    throw new Exception("The appsetting for [" + settingName + "] seems to have the default value. Have you forgotten to set it?");
			});
		}
	}
}