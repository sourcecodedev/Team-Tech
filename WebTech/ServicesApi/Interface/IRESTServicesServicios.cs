using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTech.ServicesApi.Interface
{
    interface IRESTServicesServicios<T> where T : class
    {
        List<T> ListarServicesbyType(int TypeServicesId);
    }
}
