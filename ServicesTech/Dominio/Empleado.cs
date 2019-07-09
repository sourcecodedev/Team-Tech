
using System.Runtime.Serialization;

namespace ServicesTech.Dominio
{
    [DataContract]
    public class Empleado
    {
        [DataMember]
        public int EmployeeeId { get; set; }
        [DataMember]
        public string Nombre_Employee { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Apellido_Employee { get; set; }
        [DataMember]
        public string Email_Employee { get; set; }
        [DataMember]
        public string celular_Employee { get; set; }
        [DataMember]
        public string Active_Employeee { get; set; }
        [DataMember]
        public string UsersId { get; set; }
    }
}