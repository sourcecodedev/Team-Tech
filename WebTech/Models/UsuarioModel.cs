 

namespace WebTech.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public string RolNombre { get; set; }
        public string TimeZoneId { get; set; }
        public int TimeZoneGMT { get; set; }
        public string Uestado { get; set; }
        public string NombreEmpleado { get; set; }
        public string Apellido_empleado { get; set; }
        public int PK_empleado { get; set; }
    }
}