
using WebTech.Models;

namespace WebTech.ServicesApi.Interface
{
    interface ISOATServicesClient<T> where T : class
    {
        int InsertDataClient(T data);
        Empresa ConsultDatosCompany(string ruc);
        PersonaNatural ConsultDatosPersonal(string dni);
    }
}
