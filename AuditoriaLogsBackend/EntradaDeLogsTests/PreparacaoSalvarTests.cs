﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntradaDeLogs.Tests
{
    [TestClass()]
    public class PreparacaoSalvarTests
    {
        [TestMethod()]
        public void ParseLog_RetornaLogComMensagem_QuandoRecebeStringLog()
        {
            // Arrange
            string log = @"Nov 30 16:17:01 ip-172-31-27-153 CRON[22885]: pam_unix(cron:session): session opened for user root by (uid=0)";
            PreparacaoSalvar preparacao = new PreparacaoSalvar();

            // Act
            var resultado = preparacao.ParseLog(log);

            // Assert
            Assert.AreEqual("pam_unix(cron:session): session opened for user root by (uid=0)", resultado.Mensagem);
        }
    }
}