using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntradaDeLogs
{
    public class LogReader
    {


        public void LerArquivoLog(string path) 
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Arquivo não encontrado.");
            }
        
        }
    }
}
