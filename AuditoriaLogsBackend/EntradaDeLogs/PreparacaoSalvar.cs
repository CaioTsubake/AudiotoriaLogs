using ConexaoDb;
using System;

namespace EntradaDeLogs
{
    public class PreparacaoSalvar
    {
        public AuditoriaLog ParseLog(string linha) 
        {
            AuditoriaLog log = new AuditoriaLog();

            // os primeiros 15 digitos são sempre a data
            // o primeiro espaço depois da data mostra onde o ip termina
            var dadosSemData = linha.Remove(0, 16);
            var fimIp = dadosSemData.IndexOf(' ');
            var stringIp = dadosSemData.Substring(0, fimIp);
            // Removendo o "ip-" da linha
            stringIp = stringIp.Replace("ip-", "");
            log.Ip = stringIp;

            var comecoTipo = linha.IndexOf(' ', 16);
            var fimTipo = linha.IndexOf(": ");
            var tamanhoTipo = fimTipo - comecoTipo;
            var tipo = linha.Substring(comecoTipo, tamanhoTipo).Trim();
            log.Tipo = tipo;


            var inicioMensagem = linha.IndexOf(": ");
            // Avançando 2 caracteres para não incluir ": "
            var mensagem = linha.Substring(inicioMensagem + 2);
            log.Mensagem = mensagem;

            return log;
        }
    }
}
