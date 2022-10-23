using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using EntradaDeLogs.Interfaces;

namespace EntradaDeLogs.Tests
{
    [TestClass()]
    public class LogReaderTests
    {
        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LerArquivoLog_LancaExecao_SeArquivoNaoExiste()
        {
            // Arrange
            string pathInexistente = @"C:\ArquivoInexistente.txt";
            var mock = new Moq.Mock<IFileWrapper>();
            mock.Setup(f => f.Exists(pathInexistente)).Returns(false);
            LogReader logReader = new LogReader(mock.Object);

            // Act
            logReader.LerArquivoLog(pathInexistente);
        }

        [TestMethod]
        public void LerArquivoLog_RetornaMesmaQuantidadeDeLinhas_SeOArquivoExiste()
        {
            // Arrange
            string path = @"auth.log.txt";
            var mock = new Moq.Mock<IFileWrapper>();
            mock.Setup(f => f.Exists(path)).Returns(true);
            mock.Setup(f => f.ReadLines(path)).Returns(new List<string> 
            {
                "Nov 30 17:49:18 ip-172-31-27-153 sshd[23029]: Invalid user patil from 218.26.11.118",
                "Nov 30 17:49:18 ip-172-31-27-153 sshd[23029]: input_userauth_request: invalid user patil [preauth]"
            });

            LogReader logReader = new LogReader(mock.Object);

            // Act
            List<string> resultado = logReader.LerArquivoLog(path);

            // Assert
            Assert.AreEqual(2, resultado.Count);
        }

        [TestMethod]
        public void LerArquivoLog_RetornaLinhasPresentes_SeOArquivoExiste()
        {
            // Arrange
            string path = @"auth.log.txt";
            List<string> conteudoEsperado = new List<string>
            {
                "Nov 30 17:49:18 ip-172-31-27-153 sshd[23029]: Invalid user patil from 218.26.11.118",
                "Nov 30 17:49:18 ip-172-31-27-153 sshd[23029]: input_userauth_request: invalid user patil [preauth]"
            };

            var mock = new Moq.Mock<IFileWrapper>();
            mock.Setup(f => f.Exists(path)).Returns(true);
            mock.Setup(f => f.ReadLines(path)).Returns(conteudoEsperado);

            LogReader logReader = new LogReader(mock.Object);

            // Act
            List<string> resultado = logReader.LerArquivoLog(path);

            // Assert
            Assert.AreEqual(conteudoEsperado[0], resultado[0]);
            Assert.AreEqual(conteudoEsperado[1], resultado[1]);
        }
    }
}