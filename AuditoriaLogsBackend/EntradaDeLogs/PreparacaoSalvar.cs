using ConexaoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntradaDeLogs
{
    public class PreparacaoSalvar
    {
        public AuditoriaLog ParseLog(string linha) 
        {
            AuditoriaLog log = new AuditoriaLog();

            var inicioMensagem = linha.IndexOf(": ");
            // Avançando 2 caracteres para não incluir ": "
            var mensagem = linha.Substring(inicioMensagem + 2);
            log.Mensagem = mensagem;

            return log;
        }
    }
}
