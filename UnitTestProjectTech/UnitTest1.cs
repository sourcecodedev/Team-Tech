using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectTech
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestServiceCliente_Empresa()
        {
            ServiceClient.ServiceClientClient client = new ServiceClient.ServiceClientClient();
            var data = client.ConsultDatosCompany("20100130204");

            Assert.Equals("BBVA", data.nombre_comercial);
        }

        [TestMethod]
        public void TestServiceCliente_Persona()
        {
            ServiceClient.ServiceClientClient client = new ServiceClient.ServiceClientClient();
            var data = client.ConsultDatosPersonal("42595200");

            Assert.Equals("SILVERA ABAD,ANDRES AVELINO", data.nombres);
        }
 

        [TestMethod]
        public void TestServiceUsuario_Login_GetdataUsers()
        {
            ServiceUsuario.ServiceUsuarioClient usuario = new ServiceUsuario.ServiceUsuarioClient();
            var data_usuario = usuario.GetDatabyUserTech("yferia");

            Assert.Equals("Administrator", data_usuario.RolNombre);
        }

    }
}
