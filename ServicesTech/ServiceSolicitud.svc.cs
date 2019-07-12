using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServicesTech.Dominio;

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceSolicitud" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceSolicitud.svc o ServiceSolicitud.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceSolicitud : IServiceSolicitud
    {
        public List<Solicitud> ConsultarSolicitud()
        {
            throw new NotImplementedException();
        }

        public Solicitud ConsultarSolicitudes(int SolicitudId)
        {
            throw new NotImplementedException();
        }

        public void RegistrarSolicitud(Solicitud _Solicitud)
        {
            throw new NotImplementedException();
        }
    }
}
