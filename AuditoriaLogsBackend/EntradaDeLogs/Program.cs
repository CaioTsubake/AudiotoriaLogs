using System;

namespace EntradaDeLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWrapper fileWrapper = new FileWrapper();
            LogReader logReader = new LogReader(fileWrapper);
            string filePath = @"C:\Users\caiot\Documents\Profissional\Code\Accenture\auth.log";
            Console.WriteLine($"Lendo arquivo: {filePath}");

            var linhas = fileWrapper.ReadLines(filePath);
            // Lendo 5 linhas do arquivo como teste
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Linha: {linhas[i]}");
            }

            Console.ReadLine();

        }
    }
}
