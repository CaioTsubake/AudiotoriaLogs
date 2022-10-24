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
            PreparacaoSalvar preparacao = new PreparacaoSalvar();
            OperacoesLogs conexao = new OperacoesLogs();
            Console.WriteLine($"Lendo arquivo: {filePath}");

            var linhas = logReader.LerArquivoLog(filePath);
            foreach (var linha in linhas)
            {
                Console.WriteLine($"Linha: {linha}");
            }

            var logsAuditoria = preparacao.ConverterLogs(linhas);

            var dataInicial = DateTime.Parse("2022-11-30 06:00:01");
            var dataFinal = DateTime.Parse("2022-11-30 06:47:01");


            var retornoBanco = conexao.BuscarPorDatas(dataInicial, dataFinal);
            foreach (var dadosBanco in retornoBanco)
            {
                Console.WriteLine($"Dados do Banco: Id:{dadosBanco.Id} Data:{dadosBanco.DataHora} Ip:{dadosBanco.Ip} " +
                                $"Tipo: {dadosBanco.Tipo} Mensagem:{dadosBanco.Mensagem}");
            }
        }
    }
}
