using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
