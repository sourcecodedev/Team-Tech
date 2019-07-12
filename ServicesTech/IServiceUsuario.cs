using ServicesTech.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceUsuario
    {

        [OperationContract] int ValidateAccessLogin(string email, string passuser);

        [OperationContract] UsuarioModel GetDatabyUserTech(string username);
    }
}
