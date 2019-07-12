using System;
using System.Web.Mvc;
using TeamTech.Common;
using WebTech.Core;
using WebTech.ServicesApi.Services;
using WebTech.Utilities;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Net.Mail;
using System.Configuration;

namespace WebTech.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (!Object.Equals(WebSession.Usuario, null))
            {
                return View();
            }
            else { return RedirectToAction("Login", "Account"); }

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
        #region MyRegion
        [HttpPost]
        public ActionResult ListarTypeServices()
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var resonseDAtaTypeServices = RESTServicesTypeServicios.Instancia.ListarTypeServices();

                if (resonseDAtaTypeServices != null)
                {
                    jsonResponse.Data = resonseDAtaTypeServices;
                    jsonResponse.Success = true;
                }
                else
                {
                    jsonResponse.Success = false;
                }
            }
            catch (Exception e)
            {
                jsonResponse.Warning = true;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
                QueueManager queueManager = new QueueManager(ConfigurationManager.AppSettings["quequeConexion"].ToString());
                string mensaje = "{\"Id\": \"" + e.HResult + "\",Source:\"" + e.Source + "\",Message:\"" + e.Message + "\",HelpLink:\"" + e.HelpLink + "\"}";
                queueManager.SendQueue(mensaje, "quequeerrorestech");
            }
            return Json(jsonResponse);
        }

        [HttpPost]
        public ActionResult ListarServicesbyType(int TypeServicesId)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var resonseDataServicesbyType = RESTServicesServicios.Instancia.ListarServicesbyType(TypeServicesId);

                if (resonseDataServicesbyType != null)
                {
                    jsonResponse.Data = resonseDataServicesbyType;
                    jsonResponse.Success = true;
                }
                else
                {
                    jsonResponse.Success = false;
                }
            }
            catch (Exception e)
            {
                jsonResponse.Warning = true;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
                QueueManager queueManager = new QueueManager(ConfigurationManager.AppSettings["quequeConexion"].ToString());
                string mensaje = "{\"Id\": \"" + e.HResult + "\",Source:\"" + e.Source + "\",Message:\"" + e.Message + "\",HelpLink:\"" + e.HelpLink + "\"}";
                queueManager.SendQueue(mensaje, "quequeerrorestech");
            }
            return Json(jsonResponse);
        }
        #endregion 

        #region Modulo RegistroCliente
        [HttpPost]
        public ActionResult SaveClienteData_PersonaNatural(string dni, string NombresCompletos, string direccion, string distrito, string celular, string canal_Atencion, string asesorComercial, string tipoclient, string mail)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var Response = SOATServicesClient.Instancia.InsertDataClient(new Models.Client()
                {
                    AsessorCommercial = asesorComercial,
                    canalAtencion = canal_Atencion,
                    celular = celular,
                    Direccion_client = direccion,
                    Identificador_client = dni,
                    mail = mail,
                    tipo_cliente = tipoclient,
                    Nombres_client = NombresCompletos,
                    distrito = distrito
                });
                jsonResponse.Success = true;
                jsonResponse.Data = Response;

            }
            catch (Exception e)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
                QueueManager queueManager = new QueueManager(ConfigurationManager.AppSettings["quequeConexion"].ToString());
                string mensaje = "{\"Id\": \"" + e.HResult + "\",Source:\"" + e.Source + "\",Message:\"" + e.Message + "\",HelpLink:\"" + e.HelpLink + "\"}";
                queueManager.SendQueue(mensaje, "quequeerrorestech");
            }

            return Json(jsonResponse);
        }
        [HttpPost]
        public ActionResult SaveClienteData_Empresa(string ruc, string nombre_emprea, string dirrecion, string distrito_empresa, string representante_empresa, string dniRepresentante_empresa, string celular_empresa, string correo_empresa, string canal_atencion_empresa, string asesor_comercial, string tipoclient)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var Response = SOATServicesClient.Instancia.InsertDataClient(new Models.Client()
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
                    identificador_representante = dniRepresentante_empresa
                });
                jsonResponse.Success = true;
                jsonResponse.Data = Response;
            }
            catch (Exception e)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
                QueueManager queueManager = new QueueManager(ConfigurationManager.AppSettings["quequeConexion"].ToString());
                string mensaje = "{\"Id\": \"" + e.HResult + "\",Source:\"" + e.Source + "\",Message:\"" + e.Message + "\",HelpLink:\"" + e.HelpLink + "\"}";
                queueManager.SendQueue(mensaje, "quequeerrorestech");
            }

            return Json(jsonResponse);
        }

        [HttpPost]
        public ActionResult GetDataConsultDatosCompany(string ruc)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var dataCompany = SOATServicesClient.Instancia.ConsultDatosCompany(ruc);

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
            catch (Exception e)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
                QueueManager queueManager = new QueueManager(ConfigurationManager.AppSettings["quequeConexion"].ToString());
                string mensaje = "{\"Id\": \"" + e.HResult + "\",Source:\"" + e.Source + "\",Message:\"" + e.Message + "\",HelpLink:\"" + e.HelpLink + "\"}";
                queueManager.SendQueue(mensaje, "quequeerrorestech");
            }

            return Json(jsonResponse);
        }
        [HttpPost]
        public ActionResult GetDataConsultDatosPersonal(string dni)
        {
            var jsonResponse = new JsonResponse { Success = false };

            try
            {
                var datapersonal = SOATServicesClient.Instancia.ConsultDatosPersonal(dni);

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
            catch (Exception e)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
                QueueManager queueManager = new QueueManager(ConfigurationManager.AppSettings["quequeConexion"].ToString());
                string mensaje = "{\"Id\": \"" + e.HResult + "\",Source:\"" + e.Source + "\",Message:\"" + e.Message + "\",HelpLink:\"" + e.HelpLink + "\"}";
                queueManager.SendQueue(mensaje, "quequeerrorestech");
            }

            return Json(jsonResponse);
        }

        [HttpPost]
        public ActionResult GetListEmpleadoAsesores()
        {
            var jsonResponse = new JsonResponse { Success = false };
            try
            {
                var dataAsesores = SOTAServicesEmpleado.Instancia.ListEmpleadoAsesores();
                if (dataAsesores != null)
                {
                    jsonResponse.Data = dataAsesores;
                    jsonResponse.Success = true;
                }
                else
                {
                    jsonResponse.Warning = false;
                    jsonResponse.Message = "Empresa no existe";
                }

            }
            catch (Exception e)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
                QueueManager queueManager = new QueueManager(ConfigurationManager.AppSettings["quequeConexion"].ToString());
                string mensaje = "{\"Id\": \"" + e.HResult + "\",Source:\"" + e.Source + "\",Message:\"" + e.Message + "\",HelpLink:\"" + e.HelpLink + "\"}";
                queueManager.SendQueue(mensaje, "quequeerrorestech");
            }
            return Json(jsonResponse);
        }

        [HttpPost]
        public ActionResult GetInfoEmpleadoByIdQuequeMessage(int EmployeeeId, string nombre, string Identitficador, string tipoCliente)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var item = SOTAServicesEmpleado.Instancia.GetInfoEmpleadoById(EmployeeeId);

                if (item != null)
                {
                    jsonResponse.Success = true;
                    QueueManager queueManager = new QueueManager(ConfigurationManager.AppSettings["quequeConexion"].ToString());
                    string quequeMessage = "{\"TO\": \"" + item.Email_Employee + "\", \"Subject\": \"Asignación Nuevo Cliente GRUPO TECH\",\"Body\":\"Asesor comercial : " + item.FullName + " Se te asignado un nuevo cliente para su respectivo seguimiento en las solicitudes de los servicios que realice.<br><br> Cliente :  <strong>" + nombre + "</strong> <br> DNI :  <strong>" + Identitficador + "</strong> <br> Tipo Cliente :  <strong>" + tipoCliente + "</strong> \"}";
                    queueManager.SendQueue(quequeMessage, "quequemailernotification");

                }
                else
                {
                    jsonResponse.Success = false;
                }
            }
            catch (Exception e)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
                QueueManager queueManager = new QueueManager(ConfigurationManager.AppSettings["quequeConexion"].ToString());
                string mensaje = "{\"Id\": \"" + e.HResult + "\",Source:\"" + e.Source + "\",Message:\"" + e.Message + "\",HelpLink:\"" + e.HelpLink + "\"}";
                queueManager.SendQueue(mensaje, "quequeerrorestech");
            }

            return Json(jsonResponse);
        }

        #endregion
    }
}