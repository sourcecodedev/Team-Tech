using ServicesTech.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceServicios" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceServicios
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "TypeServices", ResponseFormat = WebMessageFormat.Json)]
        List<TypeServices> ListarTypeServices();
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Services/{TypeServicesId}", ResponseFormat = WebMessageFormat.Json)]
        List<Services> ListarServicesbyType(int TypeServicesId);
    }
}
