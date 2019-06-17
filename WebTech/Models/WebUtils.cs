using System;
using System.Net;
using System.Web;

namespace WebTech.Models
{
    public static class WebUtils
    {
        #region Manejo de URLs

        private static string _relativeWebRoot;

        /// <summary>
        ///     Retorna la ruta relativa al sitio
        /// </summary>
        public static string RelativeWebRoot
        {
            get { return _relativeWebRoot ?? (_relativeWebRoot = VirtualPathUtility.ToAbsolute("~/")); }
        }

        /// <summary>
        ///     Retorna la ruta absoluta al sitio
        /// </summary>
        public static Uri AbsoluteWebRoot
        {
            get
            {
                HttpContext context = HttpContext.Current;
                if (context == null)
                    throw new WebException("El actual HttpContext es nulo");

                if (context.Items["absoluteurl"] == null)
                    context.Items["absoluteurl"] = new Uri(context.Request.Url.GetLeftPart(UriPartial.Authority) + RelativeWebRoot);

                return context.Items["absoluteurl"] as Uri;
            }
        }

        public static bool IsValidUrl(string urlString)
        {
            Uri uri;
            return Uri.TryCreate(urlString, UriKind.Absolute, out uri)
                && ((uri.Scheme == Uri.UriSchemeHttp && NumberOfBits(urlString.ToLower(), "http://") == 1)
                 || (uri.Scheme == Uri.UriSchemeHttps && NumberOfBits(urlString.ToLower(), "https://") == 1)
                 || (uri.Scheme == Uri.UriSchemeFtp && NumberOfBits(urlString.ToLower(), "ftp://") == 1)
                 || (uri.Scheme == Uri.UriSchemeMailto && NumberOfBits(urlString.ToLower(), "mailto:") == 1)
                 || (uri.Scheme == Uri.UriSchemeMailto && NumberOfBits(urlString.ToLower(), "~/") == 1)
                   );
        }

        public static int NumberOfBits(string inputString, string bitToCheck)
        {
            return inputString.ToLower().Split(new[] { bitToCheck.ToLower() }, StringSplitOptions.None).Length - 1;
        }

        public static string GetUrlComplete(string urlSection)
        {
            if (string.IsNullOrEmpty(urlSection))
            {
                return AbsoluteWebRoot.AbsolutePath;
            }
            return string.Format("{0}/{1}", AbsoluteWebRoot.AbsoluteUri.TrimEnd('/'), urlSection.TrimEnd('/'));
        }

        #endregion Manejo de URLs

        #region Manejo de Excepciones

        public static string GetExceptionMessage(Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;
            string errorMessage = string.Format("{0}<br/>{1}", ex.Message, GetExceptionMessage(ex.InnerException));

            return errorMessage;
        }

        #endregion

        #region Debuging

        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        #endregion
    }
}