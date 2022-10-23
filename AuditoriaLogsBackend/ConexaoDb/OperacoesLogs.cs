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
    }
}
