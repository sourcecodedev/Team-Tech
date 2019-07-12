using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using TeamTech.Common.Generics;
using WebTech.ServicesApi.Interface;

namespace WebTech.ServicesApi.Services
{
    public class RESTServicesServicios : Singleton<RESTServicesServicios>, IRESTServicesServicios<Models.Services>
    {
        public List<Models.Services> ListarServicesbyType(int TypeServicesId)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string UrlGet = "http://localhost:59230/ServiceServicios.svc/Services/" + TypeServicesId;
            HttpWebRequest request = (HttpWebRequest)WebRequest.
            Create(UrlGet);

            request.Method = "GET";
            HttpWebResponse   response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            List<Models.Services> Litservices = js.Deserialize<List<Models.Services>>(tramaJson);

            return Litservices;
        }
    }
}