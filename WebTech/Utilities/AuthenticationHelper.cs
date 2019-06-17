using System; 
using System.Web;
using System.Web.Security;
using TeamTech.Common;

namespace WebTech.Utilities
{
    public static class AuthenticationHelper
    {
        private const bool CreatePersistentCookie = true;

        public static void CreateAuthenticationTicket(string username)
        {
            CreateAuthenticationTicket(username, string.Empty);
        }

        public static void CreateAuthenticationTicket(string username, string timeZoneId)
        {
            var dateTimeZone = string.IsNullOrEmpty(timeZoneId) ? DateTime.Now : DateTime.UtcNow.ToTimeZoneTime(timeZoneId);

            FormsAuthentication.SetAuthCookie(username, CreatePersistentCookie);

            var ticketAuthentication = new FormsAuthenticationTicket(
                1,
                username,
                dateTimeZone,
                dateTimeZone.AddMinutes(ConfigurationAppSettings.TimeOutSession()),
                CreatePersistentCookie,
                username,
                FormsAuthentication.FormsCookiePath
            );

            var encryptTicket = FormsAuthentication.Encrypt(ticketAuthentication);
            var formsAuthenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);

            HttpContext.Current.Response.Cookies.Add(formsAuthenticationCookie);
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();

            HttpContext.Current.Response.Cookies.Clear();
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
    }

}