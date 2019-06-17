using System;
using System.Configuration;

namespace TeamTech.Common
{
    public class ConfigurationAppSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int TimeOutSession()
        {
            var timeOutSession = ConfigurationManager.AppSettings.Get("TimeOutSession");

            if (string.IsNullOrEmpty(timeOutSession))
            {
                return 30;
            }
            return int.Parse(timeOutSession);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string CultureNameDefault()
        {
            var cultureNameDefault = ConfigurationManager.AppSettings.Get("CultureNameDefault");

            if (string.IsNullOrEmpty(cultureNameDefault))
            {
                return "es-PE";
            }
            return cultureNameDefault;
        }

        /// <summary>
        ///  Obtiene el identificador de la zona horaria.
        /// </summary>
        /// <returns>El identificador de la zona horaria.</returns>
        public static string TimeZoneId()
        {
            return ConfigurationManager.AppSettings.Get("TimeZoneId");
        }

        /// <summary>
        ///  Obtiene la diferencia horaria entre la hora estándar de la zona horaria actual
        ///     y la hora universal coordinada (hora UTC).
        ///    (es el principal estándar de tiempo por el cual el mundo regula los relojes y el tiempo.)
        /// </summary>
        /// <returns>Cantidad de tiempo (horas) que se va a agregar a la hora estándar</returns>
        public static int TimeZoneGMT()
        {
            var gtmStr = ConfigurationManager.AppSettings.Get("TimeZoneGMT");
            return string.IsNullOrEmpty(gtmStr) ? 0 : Convert.ToInt32(gtmStr);
        }

        public static bool ValidacionAD()
        {
            var validacionAD = ConfigurationManager.AppSettings.Get("ValidacionAD");

            if (string.IsNullOrEmpty(validacionAD))
            {
                return false;
            }
            return validacionAD == "1";
        }

        public static string DominiosAD()
        {
            return ConfigurationManager.AppSettings.Get("DominiosAD");
        }

        public static string ConnectionActiveDirectory()
        {
            return ConfigurationManager.AppSettings.Get("ConnectionActiveDirectory");
        }

        public static int TimeOutCache()
        {
            var timeOutCache = ConfigurationManager.AppSettings.Get("TimeOutCache");

            if (string.IsNullOrEmpty(timeOutCache))
            {
                return 1440;
            }
            return int.Parse(timeOutCache);
        }
    }
}
