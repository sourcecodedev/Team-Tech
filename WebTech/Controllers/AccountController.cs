using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamTech.Common;
using WebTech.Core;
using WebTech.Models;
using WebTech.ServicesApi.Services;
using WebTech.Utilities;

namespace WebTech.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult ValidateSessionPortalWeb( string usu, string pass)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                int response = ServicesAccount.Instancia.ValidateAccessLoginTeamTech(usu, pass);

                if (response == 1 )
                {
                    var _dataLogin_usuaario = ServicesAccount.Instancia.GetDatabyUserTech(usu);
                    GenerarTickectAutenticacion(_dataLogin_usuaario);
                    jsonResponse.Data = _dataLogin_usuaario.NombreEmpleado + "" + _dataLogin_usuaario.Apellido_empleado;
                    jsonResponse.Success = true;
                }
                else if(response == 0)
                {
                    jsonResponse.Success = false;
                    jsonResponse.Message = "Credenciales Incorrectas";
                }
                else
                {
                    jsonResponse.Success = false;
                    jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
                }

            }
            catch (Exception)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
            }
            return   Json(jsonResponse);
        }

        [HttpPost]
        public JsonResult VerifySession()
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                HttpSessionStateBase session = HttpContext.Session;
                if (session.Contents[ConstantesWeb.UsuarioSesion] == null)
                {
                    jsonResponse.Title = ConstantesWeb.SesionTerminada;
                    jsonResponse.Warning = true;
                    jsonResponse.Message = ConstantesWeb.SeTerminoLaSession;
                }
            }
            catch (Exception)
            { 
                jsonResponse.Success = false;
                jsonResponse.Message = ConstantesWeb.IntenteloMasTarde;
            }

            return Json(jsonResponse);
        }

        private void GenerarTickectAutenticacion(UsuarioModel usuarioModel)
        {
            usuarioModel.TimeZoneId = ConfigurationAppSettings.TimeZoneId();
            usuarioModel.TimeZoneGMT = ConfigurationAppSettings.TimeZoneGMT();

            AuthenticationHelper.CreateAuthenticationTicket(usuarioModel.Username, usuarioModel.TimeZoneId);

            WebSession.Usuario = usuarioModel;
 
        }
        public ActionResult LogOut()
        {
            LimpiarAutenticacion();

            return RedirectToAction(ConstantesWeb.LoginAction);
        }

        private void LimpiarAutenticacion()
        {
            AuthenticationHelper.SignOut();

            WebSession.Usuario = null;
            WebSession.Formularios = new List<FormularioModel>();
        }

    }
}
