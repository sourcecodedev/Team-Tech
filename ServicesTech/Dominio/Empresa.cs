
using System.Runtime.Serialization;

namespace ServicesTech.Dominio
{
    [DataContract]
    public class Empresa
    {
        [DataMember]
        public string ruc { get; set; }
        [DataMember]
        public string razon_social { get; set; }
        [DataMember]
        public string tipo_contribuyente { get; set; }
        [DataMember]
        public string nombre_comercial { get; set; }
        [DataMember]
        public string fecha_inscripcion { get; set; }
        [DataMember]
        public string fecha_inicio_actividades { get; set; }
        [DataMember]
        public string estado_contribuyente { get; set; }
        [DataMember]
        public string condicion_contribuyente { get; set; }
        [DataMember]
        public string direccion { get; set; }

        public string sistema_emision_comprobante { get; set; }
        [DataMember]
        public string actividad_comercio_exterior { get; set; }
        [DataMember]
        public string sistema_contabilidad { get; set; }
    }
}