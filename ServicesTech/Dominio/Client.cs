using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicesTech.Dominio
{
    [DataContract]
    public class Client
    {
 
        [DataMember]
        public int PersonaNaturalId { get; set; }
        [DataMember]
        public string Identificador_client { get; set; }
        [DataMember]
        public string Nombres_client { get; set; }
        [DataMember]
        public string Direccion_client { get; set; }
        [DataMember]
        public string representate { get; set; }
        [DataMember]
        public string identificador_representante { get; set; }
        [DataMember]
        public string celular { get; set; }
        [DataMember]
        public string mail { get; set; }
        [DataMember]
        public string canalAtencion { get; set; }
        [DataMember]
        public string tipo_cliente { get; set; }
        [DataMember]
        public string AsessorCommercial { get; set; }

        [DataMember]
        public int distrito { get; set; }
    }
}