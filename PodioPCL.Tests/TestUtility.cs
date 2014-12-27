using PodioPCL.Utils.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace PodioPCL.Tests
{
	public static class TestUtility
	{
		public static LoginSettings LoginSettings { get; set; }

		public static LoginSettings LoadFromConfig(this LoginSettings loginSettings)
		{
			using (AppConfig.Change(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.config")))
			{
				var appSettings = ConfigurationManager.AppSettings;
				loginSettings.UserName = appSettings["UserName"];
				loginSettings.Password = appSettings["Password"];
				loginSettings.ClientId = appSettings["ClientId"];
				loginSettings.ClientSecret = appSettings["ClientSecret"];

				int appId = 0;
				if (int.TryParse(appSettings["AppId"], out appId))
				{
					loginSettings.AppId = appId;
				}

				loginSettings.AppToken = appSettings["AppToken"];

				return loginSettings;
			}
		}

		public static Podio GetPodio()
		{
			LoginSettings = new LoginSettings().LoadFromConfig();
			Podio podio = new Podio(LoginSettings.ClientId, LoginSettings.ClientSecret, new StaticAuthStore());
			return podio;
		}

		public static async Task<Podio> GetPodioAndUserLogin()
		{
			Podio podio = GetPodio();
			PodioOAuth oAuth = await podio.AuthenticateWithPassword(LoginSettings.UserName, LoginSettings.Password);
			return podio;
		}

		public static async Task<Podio> GetPodioAndAppLogin()
		{
			Podio podio = GetPodio();
			if (LoginSettings.AppId == null)
			{
				throw new ArgumentNullException("AppId must be set in the App.Config file.");
			}

			PodioOAuth oAuth = await podio.AuthenticateWithApp(LoginSettings.AppId.Value, LoginSettings.AppToken);
			return podio;
		}
	}
}
