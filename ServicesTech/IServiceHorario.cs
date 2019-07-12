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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceHorario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceHorario
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ConsultarDisponible", ResponseFormat = WebMessageFormat.Json)]
        List<Horario> ConsultarDisponible();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "RegistrarHorario", ResponseFormat = WebMessageFormat.Json)]
        void RegistrarHorario(Horario horario);
    }
}
