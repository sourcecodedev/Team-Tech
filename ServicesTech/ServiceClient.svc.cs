using ServicesTech.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Tecactus.Api.Reniec;
using Tecactus.Api.Sunat;

namespace ServicesTech
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceClient" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceClient.svc o ServiceClient.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceClient : IServiceClient
    {
        public Empresa ConsultDatosCompany(string RUC)
        {

            Empresa empresa_data = new Empresa();
            try
            {
                var tokensApi = new Ruc("8oZnzpEUWYeK9DhpuZVwJbQjH77WPdSg744vY31O");
                Company company = tokensApi.get(RUC);

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

            }
            catch (Exception e)
            {

            }

            return empresa_data;
        }

        public PersonaNatural ConsultDatosPersonal(string dni)
        {
            var tokensApi = new Dni("8oZnzpEUWYeK9DhpuZVwJbQjH77WPdSg744vY31O");
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

        public int InsertDataClient(Client client)
        {
            int outputVal = 0;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["Connect_database"].ToString()))
            {
                try
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand("uspInsertDataClient", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@tipo_cliente", client.tipo_cliente);
                    command.Parameters.AddWithValue("@Identificador_client", client.Identificador_client);
                    command.Parameters.AddWithValue("@Nombres_client", client.Nombres_client);
                    command.Parameters.AddWithValue("@direccion_client", client.Direccion_client);
                    command.Parameters.AddWithValue("@representate", client.representate);
                    command.Parameters.AddWithValue("@identificador_representante", client.identificador_representante);
                    command.Parameters.AddWithValue("@celular", client.celular);
                    command.Parameters.AddWithValue("@mail", client.mail);
                    command.Parameters.AddWithValue("@canalAtencion", client.canalAtencion);
                    command.Parameters.AddWithValue("@AsessorCommercial", client.AsessorCommercial);
                    command.Parameters.AddWithValue("@distrito", client.distrito);
                    command.Parameters.Add("@valoutput", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();
                    outputVal = (int)command.Parameters["@valoutput"].Value;
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
