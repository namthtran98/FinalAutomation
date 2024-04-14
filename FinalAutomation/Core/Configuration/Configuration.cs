using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAutomation.Core.Configuration
{
    public class Configuration
    {
        public static string GetBrowser()
        {
            return new ConfigurationBuilder().AddJsonFile("config.json").Build()["browser"];
        }
        public static string GetEnviroment()
        {
            var EnviromentConfig = new ConfigurationBuilder().AddJsonFile("config.json").Build().GetSection("Environment");
            if (EnviromentConfig["Current"] == "HomePage")
            {
                return EnviromentConfig["HomePage"];
            }
            else
            {
                return EnviromentConfig["HomePage"];
            }
        }
    }
}
