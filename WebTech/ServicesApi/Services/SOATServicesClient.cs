
using TeamTech.Common.Generics;
using WebTech.Models;
using WebTech.ServiceClient;
using WebTech.ServicesApi.Interface;

namespace WebTech.ServicesApi.Services
{
    public class SOATServicesClient : Singleton<SOATServicesClient>, ISOATServicesClient<Client>
    {
        public Empresa ConsultDatosCompany(string ruc)
        {
           ServiceClientClient _serviceClientClient = new ServiceClientClient();

            Empresa _data_empresa = new Empresa();

            var data = _serviceClientClient.ConsultDatosCompany(ruc);

            _data_empresa.actividad_comercio_exterior = data.actividad_comercio_exterior;
            _data_empresa.condicion_contribuyente = data.condicion_contribuyente;
            _data_empresa.direccion = data.direccion;
            _data_empresa.estado_contribuyente = data.estado_contribuyente;
            _data_empresa.fecha_inicio_actividades = data.fecha_inicio_actividades;
            _data_empresa.fecha_inscripcion = data.fecha_inscripcion;
            _data_empresa.nombre_comercial = data.nombre_comercial;
            _data_empresa.razon_social = data.razon_social;
            _data_empresa.ruc = data.ruc;
            _data_empresa.sistema_contabilidad = data.sistema_contabilidad;
            _data_empresa.sistema_emision_comprobante = data.sistema_emision_comprobante;
            _data_empresa.tipo_contribuyente = data.tipo_contribuyente;

            return _data_empresa;
        }

        public PersonaNatural ConsultDatosPersonal(string dni)
        {
            ServiceClientClient _serviceClientClient = new ServiceClientClient();

            PersonaNatural persona = new PersonaNatural();

            var data = _serviceClientClient.ConsultDatosPersonal(dni);

            persona.apellido_materno = data.apellido_materno;
            persona.apellido_paterno = data.apellido_paterno;
            persona.caracter_verificacion = data.caracter_verificacion;
            persona.caracter_verificacion_anterior = data.caracter_verificacion_anterior;
            persona.dni = data.dni;
            persona.nombres = data.nombres;

            return persona;
        }

        public int InsertDataClient(Client data)
        {
            ServiceClientClient _serviceClientClient = new ServiceClientClient();
            var value_ouput = _serviceClientClient.InsertDataClient(new ServicesTech.Dominio.Client()
            {

                AsessorCommercial = data.AsessorCommercial,
                canalAtencion = data.canalAtencion,
                celular = data.celular,
                Direccion_client = data.Direccion_client,
                Identificador_client = data.Identificador_client,
                identificador_representante = data.identificador_representante,
                mail = data.mail,
                Nombres_client = data.Nombres_client,
                PersonaNaturalId = data.PersonaNaturalId,
                representate = data.representate,
                tipo_cliente = data.tipo_cliente

            });

            return value_ouput;
        }
    }
}