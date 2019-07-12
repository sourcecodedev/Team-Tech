 
using System.Runtime.Serialization;
  
namespace ServicesTech.Dominio
{
    [DataContract]
    public class TypeServices
    {
        [DataMember]
        public int TypeServicesId { get; set; }
        [DataMember]
        public string Name_TypeServices { get; set; }
    }
}