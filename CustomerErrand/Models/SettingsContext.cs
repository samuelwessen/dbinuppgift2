using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CustomerErrand.Models
{
    public static class SettingsContext
    {
        private static Settings _settings { get; set; }

       
        public static async Task<IEnumerable<string>> NewGetStatus()
        {
            var list = new List<string>();

            

            foreach (var status in _settings.status)
            {
                list.Add(status);
            }
             return list;
        }

        public static int GetMaxItemsCount()
        {
            return _settings.maxItemsCount;
        }


        public class Settings
        {
            public string[] status { get; set; }
            public int maxItemsCount { get; set; }
        }


        //nytt
        public static async Task CreateSettingsFileAsync()
        {
            StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.CreateFileAsync("Settings.json",
            Windows.Storage.CreationCollisionOption.ReplaceExisting);
        }
        public static async Task WriteToSettingsFileAsync()
        {
            StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync("Settings.json");
            await FileIO.WriteTextAsync(file, "{\"status\": [\"new\", \"active\", \"completed\"], \"maxItemsCount\": 4}");
        }
        public static async Task ReadSettingsFileAsync()
        {
            StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync("Settings.json");

            string settingstext = await FileIO.ReadTextAsync(file);
            _settings = JsonConvert.DeserializeObject<Settings>(settingstext);

        }

        public static async void JsonSetting()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile jsonsettings = await storageFolder.CreateFileAsync("newsettings.json", CreationCollisionOption.ReplaceExisting);

            jsonsettings = await storageFolder.GetFileAsync("newsettings.json");
            await FileIO.WriteTextAsync(jsonsettings, "{\"status\": [\"new\", \"active\", \"completed\"], \"maxItemsCount\": 4}");
        }

    }
}
