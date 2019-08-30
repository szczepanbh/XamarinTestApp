

namespace XamarinTestApp
{
    using Android.Content.Res;
    using Newtonsoft.Json;
    using System.IO;

    public class AppSettingsManager : IAppSettingsManager
    {
        const string _appSettingsFileName = "appsettings.json";

        private readonly AssetManager _manager;

        public AppSettingsManager(AssetManager manager)
        {
            _manager = manager;
        }

        public IAppSettings GetConfig()
        {
            using (var sr = new StreamReader(_manager.Open(_appSettingsFileName)))
            {
                var content = sr.ReadToEnd();
                var configuration = JsonConvert.DeserializeObject<AppSettings>(content);
                return configuration;
            }
        }
    }
}