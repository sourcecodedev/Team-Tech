using System.Configuration;
using Tecactus.Api.Reniec;
using Tecactus.Api.Sunat;
using System.Data.SqlClient;
using System.Data;
using System;
using ServicesTech.Dominio;

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceDevTech : IServiceDevTech
    {
        public Empresa ConsultDatosCompany(string RUC)
        {
            var tokensApi = new Ruc(ConfigurationManager.AppSettings["tokensApiReniecSunat"].ToString());
            Company company = tokensApi.get(RUC);

            Empresa empresa_data = new Empresa();
            empresa_data.actividad_comercio_exterior = company.actividad_comercio_exterior;
            empresa_data.condicion_contribuyente = company.condicion_contribuyente;
            empresa_data.direccion = company.direccion;
            empresa_data.estado_contribuyente = company.estado_contribuyente;
            empresa_data.fecha_inicio_actividades = company.fecha_inicio_actividades;
            empresa_data.fecha_inscripcion = company.fecha_inscripcion;
            empresa_data.nombre_comercial = company.nombre_comercial;
            empresa_data.razon_social = company.razon_social;
            empresa_data.ruc = company.ruc;
            empresa_data.sistema_contabilidad = company.sistema_contabilidad;
            empresa_data.sistema_emision_comprobante = company.sistema_emision_comprobante;
            empresa_data.tipo_contribuyente = company.tipo_contribuyente;


            return empresa_data;
        }

        public PersonaNatural ConsultDatosPersonal(string dni)
        {
            var tokensApi = new Dni(ConfigurationManager.AppSettings["tokensApiReniecSunat"].ToString());
            Person person = tokensApi.get(dni);

            PersonaNatural personaNatural = new PersonaNatural();

            personaNatural.dni = person.dni;
            personaNatural.nombres = person.nombres;
            personaNatural.apellido_materno = person.apellido_materno;
            personaNatural.apellido_paterno = person.apellido_paterno;
            personaNatural.caracter_verificacion = person.caracter_verificacion;
            personaNatural.caracter_verificacion_anterior = person.caracter_verificacion_anterior;

            return personaNatural;
        }

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
                            _usuarioModel.Uestado = dataReader["estado"].ToString();
                            _usuarioModel.PK_empleado = (int)dataReader["PK_empleado"];
                            _usuarioModel.NombreEmpleado = dataReader["nombreEmpleado"].ToString();
                            _usuarioModel.Apellido_empleado = dataReader["apellido_empleado"].ToString();
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
