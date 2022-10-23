using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntradaDeLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EntradaDeLogs.Tests
{
    [TestClass()]
    public class LogReaderTests
    {
        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LerArquivoLog_LancaExecao_SeArquivoNaoExiste()
        {
            LogReader logReader = new LogReader();
            string pathInexistente = @"C:\diretorioInexistente";

            logReader.LerArquivoLog(pathInexistente);
        }
    }
}