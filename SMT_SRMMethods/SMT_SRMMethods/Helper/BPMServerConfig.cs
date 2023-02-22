using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPM.Server;
namespace SMT_SRMMethods.Helper
{
     public class BPMServerConfig
    {
        public static string GetValue(string key)
        {
            string configValue = ConfigurationManager.AppSettings[key];
            if (configValue == null&& configValue.ToString() =="")
            {
                return BPM.Server.Config.ApplicationDataSection.Current.CurrentConfiguration.AppSettings.Settings[key].Value;
            }
            else
            {
                return configValue;
            }
           
        }
    }
}
