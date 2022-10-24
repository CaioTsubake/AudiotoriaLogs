using ConexaoDb;
using System;

namespace EntradaDeLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\caiot\Documents\Profissional\Code\Accenture\test.log";
            ProcessamentoLogs processamento = new ProcessamentoLogs();
            processamento.ProcessarLogs(filePath);

            Console.ReadLine();
        }
    }
}
