using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ConexaoDb
{
    public class OperacoesLogs
    {
        public List<AuditoriaLog> GetLogs() 
        {
            var connectionString = @"Server=.\SQLEXPRESS;Database=AuditoriaLogs;Trusted_Connection=True;";

            using (var conexao = new SqlConnection(connectionString))
            {
                var resultado = conexao.Query<AuditoriaLog>("SELECT * FROM Logs").ToList();

                return resultado;
            }
        }

        public void InserirLogs(List<AuditoriaLog> logs) 
        {
            var connectionString = @"Server=.\SQLEXPRESS;Database=AuditoriaLogs;Trusted_Connection=True;";
            var query = "INSERT INTO Logs VALUES (@DataHora, @Ip, @Tipo, @Mensagem)";

            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Execute(query, logs);
            }
        }
    }
}
