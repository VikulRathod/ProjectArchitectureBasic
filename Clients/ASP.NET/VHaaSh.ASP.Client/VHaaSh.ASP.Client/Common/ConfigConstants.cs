using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace VHaaSh.ASP.Client.Common
{
    public class ConfigConstants
    {
        public static int NumberOfLoginAttemptsAllowed
        {
            get
            {
                return int.Parse(ConfigurationManager.
                    AppSettings["NumberOfLoginAttemptsAllowed"]);
            }
        }
        public static string FromEmail
        {
            get
            {
                return ConfigurationManager.
                    AppSettings["FromEmail"];
            }
        }
        public static string FromEmailPassword
        {
            get
            {
                return ConfigurationManager.
                    AppSettings["FromEmailPassword"];
            }
        }
        public static string EmailServer
        {
            get
            {
                return ConfigurationManager.
                    AppSettings["EmailServer"];
            }
        }
        public static int EmailServerPort
        {
            get
            {
                return int.Parse(ConfigurationManager.
                    AppSettings["EmailServerPort"]);
            }
        }
        public static bool EnableSsl
        {
            get
            {
                return bool.Parse(ConfigurationManager.
                    AppSettings["EnableSsl"]);
            }
        }

    }
}