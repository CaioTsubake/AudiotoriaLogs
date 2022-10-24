using ConexaoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWeb
{
    public class LogsActions
    {
        public List<AuditoriaLog> BuscarLogsComMensagem(string mensagem) 
        {
            OperacoesLogs conexao = new OperacoesLogs();
            List<AuditoriaLog> resultadoBusca = conexao.BuscarPorMensagem(mensagem);

            return resultadoBusca;
        }

        public List<AuditoriaLog> BuscarLogsPorPeriodo(string dataInicial, string dataFinal)
        {
            OperacoesLogs conexao = new OperacoesLogs();
            var dataHoraInicial = DateTime.Parse(dataInicial);
            var dataHoraFinal = DateTime.Parse(dataFinal);

            List<AuditoriaLog> resultadoBusca = conexao.BuscarPorDatas(dataHoraInicial, dataHoraFinal);

            return resultadoBusca;
        }
    }
}