using ConexaoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntradaDeLogs
{
    public class ProcessamentoLogs
    {
        public void ProcessarLogs(string filePath) 
        {
            FileWrapper fileWrapper = new FileWrapper();
            LogReader logReader = new LogReader(fileWrapper);
            Console.WriteLine($"Lendo arquivo: {filePath}");

            var linhas = logReader.LerArquivoLog(filePath);
            foreach (var linha in linhas)
            {
                Console.WriteLine($"Linha: {linha}");
            }


            OperacoesLogs conexao = new OperacoesLogs();
            AuditoriaLog dadosBanco = conexao.GetLogs()[0];
            Console.WriteLine($"Dados do Banco: Id:{dadosBanco.Id} Data:{dadosBanco.DataHora} Ip:{dadosBanco.Ip} " +
                                $"Tipo: {dadosBanco.Tipo} Mensagem:{dadosBanco.Mensagem}");
        }
    }
}
