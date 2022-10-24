using ConexaoDb;
using System;
using System.Collections.Generic;

namespace ApiWeb
{
    public class LogsActions
    {
        private readonly OperacoesLogs _conexao = new OperacoesLogs();
        public List<AuditoriaLog> BuscarLogsComMensagem(string mensagem)
        {
            try
            {
                List<AuditoriaLog> resultadoBusca = _conexao.BuscarPorMensagem(mensagem);

                return resultadoBusca;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AuditoriaLog> BuscarLogsPorPeriodo(string dataInicial, string dataFinal)
        {
            DateTime dataHoraInicial;
            DateTime dataHoraFinal;
            if (!DateTime.TryParse(dataInicial, out dataHoraInicial))
            {
                throw new FormatException("Data Inicial em formato invalido.");
            }

            if (!DateTime.TryParse(dataFinal, out dataHoraFinal))
            {
                throw new FormatException("Data Final em formato invalido.");
            }

            List<AuditoriaLog> resultadoBusca = _conexao.BuscarPorDatas(dataHoraInicial, dataHoraFinal);

            return resultadoBusca;
        }
    }
}