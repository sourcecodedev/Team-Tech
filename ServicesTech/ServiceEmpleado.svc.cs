using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
 
using ServicesTech.Dominio;

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceEmpleado" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceEmpleado.svc o ServiceEmpleado.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceEmpleado : IServiceEmpleado
    {
        public Empleado GetInfoEmpleadoById(int EmployeeeId)
        {
            Empleado _Empleado = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["Connect_database"].ToString()))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand("uspGetInfoEmpleadoById", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeeId", EmployeeeId);
                    SqlDataReader sqlData = command.ExecuteReader();
                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            _Empleado = new Empleado();
                            _Empleado.EmployeeeId = int.Parse(sqlData["EmployeeeId"].ToString());
                            _Empleado.FullName = sqlData["FullName"].ToString();
                            _Empleado.Email_Employee = sqlData["Email_Employee"].ToString();
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
                return _Empleado;
        }

        public List<Empleado> ListEmpleadoAsesores()
        {
            List<Empleado> _lista_empleado = new List<Empleado>();
            Empleado _Empleado = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["Connect_database"].ToString()))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand("uspListEmpleadosAsesores", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlData = command.ExecuteReader();

                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            _Empleado = new Empleado();
                            _Empleado.EmployeeeId = int.Parse(sqlData["EmployeeeId"].ToString());
                            _Empleado.FullName = sqlData["FullName"].ToString();
                            _lista_empleado.Add(_Empleado);
                        }
                    }
                }
                catch (Exception) { }
                finally
                {
                    cn.Close();
                }
            }
            return _lista_empleado;
        }


    }
}
