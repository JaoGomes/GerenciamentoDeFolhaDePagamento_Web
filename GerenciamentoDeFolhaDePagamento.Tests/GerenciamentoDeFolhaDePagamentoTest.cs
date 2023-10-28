using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GerenciamentoDeFolhaDePagamento.Tests
{
    [TestClass]
    public class GerenciamentoDeFolhaDePagamentoTest
    {
        [TestMethod]
        public void ValidarUsuario()
        {
            Assert.AreEqual(1, Controllers.LoginController.ValidarUsuarioLogin("joao@gmail.com", "joao@123"));
        }

        [TestMethod]
        public void ValidarEmailUsuario()
        {
            Assert.AreEqual(1, Controllers.LoginController.ValidarEmailLogin("joao@gmail.com"));
        }

        [TestMethod]
        public void ValidarSenhaRedefinicao()
        {
            Assert.AreEqual(1, Controllers.LoginController.ValidarSenhaRedefinicao("joao@123", "joao@123"));
        }

        [TestMethod]
        public void ValidarAlteracaoRedefinir()
        {
            Assert.AreEqual("Alterada!", Controllers.LoginController.AlteracaoRedefinir("joao@123", "joao@123"));
        }
    }
}
