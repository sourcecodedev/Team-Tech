using ServicesTech.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceSolicitud" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceSolicitud
    {
        [OperationContract] void RegistrarSolicitud(Solicitud _Solicitud);
        [OperationContract] List<Solicitud> ConsultarSolicitud();
        [OperationContract] Solicitud ConsultarSolicitudes(int SolicitudId);
    }
}
