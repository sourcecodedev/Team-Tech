using ServicesTech.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceUsuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceUsuario.svc o ServiceUsuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceUsuario : IServiceUsuario
    {

        public UsuarioModel GetDatabyUserTech(string username)
        {
            UsuarioModel _usuarioModel = null;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["Connect_database"].ToString()))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand("uspGetDatabyUserTech", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", username);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            _usuarioModel = new UsuarioModel();
                            _usuarioModel.RolId = int.Parse(dataReader["RolId"].ToString());
                            _usuarioModel.RolNombre = dataReader["RolNombre"].ToString();
                            _usuarioModel.Username = dataReader["Username"].ToString();
                            _usuarioModel.Active_Employeee = dataReader["estado"].ToString();
                            _usuarioModel.PK_empleado = (int)dataReader["EmployeeeId"];
                            _usuarioModel.Nombre_Employee = dataReader["nombre_Employee"].ToString();
                            _usuarioModel.Apellido_Employee = dataReader["Apellido_Employee"].ToString();
                        }
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    cn.Close();
                }
            }
            return _usuarioModel;
        }

        public int ValidateAccessLogin(string usuario, string passuser)
        {
            int outputVal = 0;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["Connect_database"].ToString()))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand("uspValidateAccessLoginTeamTech", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", usuario);
                    command.Parameters.AddWithValue("@password", passuser);
                    command.Parameters.Add("@outputVal", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();
                    outputVal = (int)command.Parameters["@outputVal"].Value;
                }
                catch (Exception)
                {
                    outputVal = -1;
                }
                finally
                {
                    cn.Close();

                }
            }
            return outputVal;

        }

    }
}
