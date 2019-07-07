using TeamTech.Common.Generics;
using WebTech.Models;
using WebTech.ServicesApi.Interface;
using WebTech.ServiceUsuario;

namespace WebTech.ServicesApi.Services
{
    public class SOATServicesUsuario : Singleton<SOATServicesUsuario>, ISOATServicesUsuario<UsuarioModel>
    {
        public int ValidateAccessLoginTeamTech(string usu, string pass)
        {
            ServiceUsuarioClient _serviceUsuario = new ServiceUsuarioClient();

            return _serviceUsuario.ValidateAccessLogin(usu, pass);
        }
        public UsuarioModel GetDatabyUserTech(string usu)
        {
            ServiceUsuarioClient _serviceUsuario = new ServiceUsuarioClient();
            UsuarioModel _usuarioModel = new UsuarioModel();

            var usuario = _serviceUsuario.GetDatabyUserTech(usu);

            _usuarioModel.Apellido_empleado = usuario.Apellido_Employee;
            _usuarioModel.NombreEmpleado = usuario.Nombre_Employee;
            _usuarioModel.PK_empleado = usuario.PK_empleado;
            _usuarioModel.RolId = usuario.RolId;
            _usuarioModel.RolNombre = usuario.RolNombre;
            _usuarioModel.Uestado = usuario.Active_Employeee;
            _usuarioModel.Username = usuario.Username;

            return _usuarioModel;
        }
    }
}