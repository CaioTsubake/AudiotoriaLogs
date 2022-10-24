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
        private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=AuditoriaLogs;Trusted_Connection=True;";

        public List<AuditoriaLog> GetLogs() 
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                var resultado = conexao.Query<AuditoriaLog>("SELECT * FROM Logs").ToList();

                return resultado;
            }
        }

        public void InserirLogs(List<AuditoriaLog> logs) 
        {
            var query = "INSERT INTO Logs VALUES (@DataHora, @Ip, @Tipo, @Mensagem)";

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Execute(query, logs);
            }
        }

        public List<AuditoriaLog> BuscarPorMensagem(string mensagem) 
        {
            var query = $"SELECT * FROM Logs WHERE Mensagem LIKE '%{mensagem}%'";

            using (var conexao = new SqlConnection(_connectionString))
            {
                var resultado = conexao.Query<AuditoriaLog>(query).ToList();

                return resultado;
            }
        }

        public List<AuditoriaLog> BuscarPorDatas(DateTime dataInicial, DateTime dataFinal)
        {
            var query = $"SELECT * FROM Logs WHERE DataHora BETWEEN '{dataInicial}' AND '{dataFinal}'";

            using (var conexao = new SqlConnection(_connectionString))
            {
                var resultado = conexao.Query<AuditoriaLog>(query).ToList();

                return resultado;
            }
        }
    }
}
