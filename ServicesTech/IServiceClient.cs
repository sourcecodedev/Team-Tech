using ServicesTech.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceClient" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceClient
    {
        [OperationContract] PersonaNatural ConsultDatosPersonal(string dni);
        [OperationContract] Empresa ConsultDatosCompany(string RUC);

        [OperationContract] int InsertDataClient(Client client);
    }
}
