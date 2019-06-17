using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTech.ServicesApi.Interface
{
    interface IAccount<T> where T : class
    {
        int ValidateAccessLoginTeamTech(string usu, string pass);
    }
}
