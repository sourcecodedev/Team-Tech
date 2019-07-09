
using ServicesTech.Dominio;
using System.Collections.Generic;
using System.ServiceModel;
 

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceEmpleado" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceEmpleado
    {
        [OperationContract] List<Empleado> ListEmpleadoAsesores();
        [OperationContract] Empleado GetInfoEmpleadoById(int EmployeeeId);
    }
}
