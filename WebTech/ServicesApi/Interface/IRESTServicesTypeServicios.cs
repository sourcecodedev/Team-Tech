using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTech.ServicesApi.Interface
{
    public interface IRESTServicesTypeServicios<T> where T : class
    { 
        List<T> ListarTypeServices();
    }
}
