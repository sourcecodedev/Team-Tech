using WebTech.Models;
using TeamTech.Common.Generics;
using WebTech.ServicesApi.Interface;
using System.Collections.Generic;

namespace WebTech.ServicesApi.Services
{
    public class SOTAServicesEmpleado : Singleton<SOTAServicesEmpleado>, ISOATServicesEmpleado<Empleado>
    {
      
        public List<Empleado> ListEmpleadoAsesores()
        {
            ServiceEmpleado.ServiceEmpleadoClient _empleadoClient = new ServiceEmpleado.ServiceEmpleadoClient();
            List<Empleado> Listempleados = new List<Empleado>();
            Empleado _empleado = null;

            foreach (var item in _empleadoClient.ListEmpleadoAsesores())
            {
                _empleado = new Empleado();
                _empleado.EmployeeeId = item.EmployeeeId;
                _empleado.FullName = item.FullName;
                Listempleados.Add(_empleado);
            }
            return Listempleados;
        }
        public Empleado GetInfoEmpleadoById(int EmployeeeId)
        {
            ServiceEmpleado.ServiceEmpleadoClient _empleadoClient = new ServiceEmpleado.ServiceEmpleadoClient();
            Empleado _empleado = null;
            var item = _empleadoClient.GetInfoEmpleadoById(EmployeeeId);
            _empleado = new Empleado();
            _empleado.EmployeeeId = item.EmployeeeId;
            _empleado.FullName = item.FullName;
            _empleado.Email_Employee = item.Email_Employee;

            return _empleado;
        }
    }
}