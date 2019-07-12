
using System.Runtime.Serialization; 
namespace ServicesTech.Dominio
{
    [DataContract]
    public class Services
    {
        [DataMember]
        public int ServicesId { get; set; }
        [DataMember]
        public string Name_Services { get; set; }
        [DataMember]
        public decimal PriceTotal { get; set; }
        [DataMember]
        public TypeServices TypeServices { get; set; }
    }
}