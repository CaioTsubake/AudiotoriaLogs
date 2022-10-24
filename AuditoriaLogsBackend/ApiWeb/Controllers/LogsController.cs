using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConexaoDb;

namespace ApiWeb.Controllers
{
    public class LogsController : ApiController
    {
        public string GetHeartbeat() 
        {
            return "Ok";
        }

        public List<AuditoriaLog> GetLogs(string mensagem) 
        {
            LogsActions logsActions = new LogsActions();

            List<AuditoriaLog> resultado = logsActions.BuscarLogsComMensagem(mensagem);

            return resultado;
        }

        public List<AuditoriaLog> GetLogsPorPeriodo(string dataInicial, string dataFinal)
        {
            try
            {
                LogsActions logsActions = new LogsActions();

                List<AuditoriaLog> resultado = logsActions.BuscarLogsPorPeriodo(dataInicial, dataFinal);

                return resultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
