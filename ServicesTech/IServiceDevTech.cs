
using ServicesTech.Dominio; 
using System.ServiceModel;
 

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceDevTech
    {


        [OperationContract] int ValidateAccessLogin(string email, string passuser);

        [OperationContract] PersonaNatural ConsultDatosPersonal(string dni);
        [OperationContract] Empresa ConsultDatosCompany(string RUC);

        [OperationContract] UsuarioModel GetDatabyUserTech(string username);
        
        [OperationContract] int InsertDataClient(Client client);
    }
}
