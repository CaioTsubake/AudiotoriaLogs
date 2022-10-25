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

            var logsAuditoria = preparacao.ConverterLogs(linhas);
            conexao.InserirLogs(logsAuditoria);
            Console.WriteLine($"Arquivo processado com sucesso. {logsAuditoria.Count} logs foram adicionados.");
        }
    }
}
