using ServicesTech;
using TeamTech.Common.Generics;
using WebTech.Models;
using WebTech.ServicesApi.Interface;


namespace WebTech.ServicesApi.Services
{
    public class ServicesAccount : Singleton<ServicesAccount>, IAccount<UsuarioModel>
    {
        public int ValidateAccessLoginTeamTech(string usu, string pass)
        { 
            ServiceDevTech serviceDevTech = new ServiceDevTech();

            return serviceDevTech.ValidateAccessLogin(usu, pass);
        }
        public UsuarioModel GetDatabyUserTech( string usu)
        {
            ServiceDevTech _serviceDevTech = new ServiceDevTech();
            UsuarioModel _usuarioModel = new UsuarioModel();
           
           var usuario =   _serviceDevTech.GetDatabyUserTech(usu);

            _usuarioModel.Apellido_empleado = usuario.Apellido_empleado;
            _usuarioModel.NombreEmpleado = usuario.NombreEmpleado;
            _usuarioModel.PK_empleado = usuario.PK_empleado; 
            _usuarioModel.RolId = usuario.RolId;
            _usuarioModel.RolNombre = usuario.RolNombre;
            _usuarioModel.Uestado = usuario.Uestado;
            _usuarioModel.Username = usuario.Username; 
             
            return _usuarioModel;
        }
    }
}