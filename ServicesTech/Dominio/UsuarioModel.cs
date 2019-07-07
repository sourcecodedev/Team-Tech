using System.Runtime.Serialization;
namespace ServicesTech.Dominio
{
    [DataContract]
    public class UsuarioModel
    {
        [DataMember]
        public int RolId { get; set; }
        [DataMember]
        public string RolNombre { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Active_Employeee { get; set; }
        [DataMember]
        public string Nombre_Employee { get; set; }
        [DataMember]
        public string Apellido_Employee { get; set; }
        [DataMember]
        public int PK_empleado { get; set; }
        [DataMember]
        public string Email_Employee { get; set; }
    }
}