using System;
using System.Web.Mvc;
using TeamTech.Common;
using WebTech.ServicesApi.Services;
using WebTech.Utilities;

namespace WebTech.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistroCliente()
        {

            return View();
        }

        public ActionResult RegistroCotizacion()
        {
            return View();
        }

        public ActionResult RegistroFechaEntrega()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SaveClienteData_PersonaNatural(string dni, string NombresCompletos, string  direccion, string  distrito, string celular, string canal_Atencion,string asesorComercial,string tipoclient,string mail)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var Response = ServicesHomeClient.Instancia.InsertDataClient( new Models.Client() {
                    AsessorCommercial = asesorComercial,
                    canalAtencion= canal_Atencion,
                    celular = celular,
                    Direccion_client = direccion,
                    Identificador_client =dni,
                    mail=mail,
                    tipo_cliente =  tipoclient,
                    Nombres_client = NombresCompletos,
                   distrito = distrito 
                });
                jsonResponse.Success = true;
                jsonResponse.Data = Response;

            }
            catch (Exception)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
            }

            return Json(jsonResponse);
        }
        [HttpPost]
        public ActionResult SaveClienteData_Empresa(string ruc ,string  nombre_emprea ,string  dirrecion ,string  distrito_empresa ,string  representante_empresa ,string  dniRepresentante_empresa ,string  celular_empresa ,string  correo_empresa ,string  canal_atencion_empresa ,string  asesor_comercial,string tipoclient)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var Response = ServicesHomeClient.Instancia.InsertDataClient(new Models.Client()
                {
                    AsessorCommercial = asesor_comercial,
                    canalAtencion = canal_atencion_empresa,
                    celular = celular_empresa,
                    Direccion_client = dirrecion,
                    Identificador_client = ruc,
                    mail = correo_empresa,
                    tipo_cliente = tipoclient,
                    Nombres_client = nombre_emprea,
                    distrito = distrito_empresa,
                    representate = representante_empresa,
                    identificador_representante= dniRepresentante_empresa
                });
                jsonResponse.Success = true;
                jsonResponse.Data = Response;
            }
            catch (Exception)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
            }

            return Json(jsonResponse);
        }

        [HttpPost]
        public ActionResult GetDataConsultDatosCompany(string ruc)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var dataCompany = ServicesHomeClient.Instancia.ConsultDatosCompany(ruc);

                if (dataCompany != null)
                {
                    jsonResponse.Data = dataCompany;
                    jsonResponse.Success = true;
                }
                else
                {
                    jsonResponse.Warning = false;
                    jsonResponse.Message = "Empresa no existe";
                }

            }
            catch (Exception)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
            }

            return Json(jsonResponse);
        }
        [HttpPost]
        public ActionResult GetDataConsultDatosPersonal(string dni)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var datapersonal = ServicesHomeClient.Instancia.ConsultDatosPersonal(dni);

                if (datapersonal != null)
                {
                    jsonResponse.Data = datapersonal;
                    jsonResponse.Success = true;
                }
                else
                {
                    jsonResponse.Warning = false;
                    jsonResponse.Message = "Empresa no existe";
                }

            }
            catch (Exception)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
            }

            return Json(jsonResponse);
        }
    }
}