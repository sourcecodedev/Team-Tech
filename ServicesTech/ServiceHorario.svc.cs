using System;
using System.Collections.Generic;
 
using ServicesTech.Dominio;

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceHorario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceHorario.svc o ServiceHorario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceHorario : IServiceHorario
    {
        public List<Horario> ConsultarDisponible()
        {
            throw new NotImplementedException();
        }

        public void RegistrarHorario(Horario horario)
        {
            throw new NotImplementedException();
        }
    }
}
