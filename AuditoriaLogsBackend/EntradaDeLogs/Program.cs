using ConexaoDb;
using System;
using System.Configuration;

namespace EntradaDeLogs
{
    class Program
    {
        static void Main(string[] args)
        {

            string filePath = ConfigurationSettings.AppSettings["pathLogs"];
            ProcessamentoLogs processamento = new ProcessamentoLogs();
            processamento.ProcessarLogs(filePath);

            Console.WriteLine("Processo terminado com sucesso! Aperte qualquer tecla para sair.");
            Console.ReadLine();
        }
    }
}
