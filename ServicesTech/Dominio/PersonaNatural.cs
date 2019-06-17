using System.Runtime.Serialization;

namespace ServicesTech.Dominio
{
    [DataContract]
    public class PersonaNatural
    {
        [DataMember]
        public string dni { get; set; }
        [DataMember]
        public string nombres { get; set; }
        [DataMember]
        public string apellido_paterno { get; set; }
        [DataMember]
        public string apellido_materno { get; set; }
        [DataMember]
        public string caracter_verificacion { get; set; }
        [DataMember]
        public string caracter_verificacion_anterior { get; set; }
    }
}