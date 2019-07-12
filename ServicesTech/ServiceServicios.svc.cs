using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ServicesTech.Dominio;

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceServicios" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceServicios.svc o ServiceServicios.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceServicios : IServiceServicios
    {
        public List<Services> ListarServicesbyType(int TypeServicesId)
        {
            List<Services> Lista_services = new List<Services>();
            Services _Services = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["Connect_database"].ToString()))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand("uspListServicesbyType", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TypeServicesId", TypeServicesId);
                    SqlDataReader sqlData = command.ExecuteReader();

                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            _Services = new Services();
                            _Services.ServicesId = int.Parse(sqlData["ServicesId"].ToString());
                            _Services.Name_Services = sqlData["Name_TypeServices"].ToString();
                            _Services.PriceTotal = (decimal)sqlData["PriceTotal"];
                            _Services.TypeServices.TypeServicesId = int.Parse(sqlData["TypeServices"].ToString());
                            _Services.TypeServices.Name_TypeServices = (sqlData["Name_TypeServices"].ToString());
                            Lista_services.Add(_Services);
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

            return Lista_services;
        } 
        public List<TypeServices> ListarTypeServices()
        {
            List<TypeServices> _Lista_TypeServices = new List<TypeServices>();
            TypeServices services = null;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["Connect_database"].ToString()))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand("uspListTypeServices", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlData = command.ExecuteReader();

                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            services = new TypeServices();
                            services.TypeServicesId = int.Parse(sqlData["TypeServicesId"].ToString());
                            services.Name_TypeServices = sqlData["Name_TypeServices"].ToString();
                            _Lista_TypeServices.Add(services);
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
            return _Lista_TypeServices;
        }
    }
}
