using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using TeamTech.Common.Generics;
using WebTech.Models;
using WebTech.ServicesApi.Interface;

namespace WebTech.ServicesApi.Services
{
    public class RESTServicesTypeServicios : Singleton<RESTServicesTypeServicios>, IRESTServicesTypeServicios<TypeServices>
    {
         

        public List<TypeServices> ListarTypeServices()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string UrlGet = "http://localhost:59230/ServiceServicios.svc/TypeServices/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.
            Create(UrlGet);

            request.Method = "GET";
            HttpWebResponse response = null;

            response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            List<Models.TypeServices> LitTypeservices = js.Deserialize<List<Models.TypeServices>>(tramaJson);

            return LitTypeservices;
        }
    }
}