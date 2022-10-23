﻿using EntradaDeLogs.Interfaces;
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
        private IFileWrapper _fileWrapper;

        public LogReader(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
        }

        public List<string> LerArquivoLog(string path) 
        {
            if (!_fileWrapper.Exists(path))
            {
                throw new FileNotFoundException("Arquivo não encontrado.");
            }

            return _fileWrapper.ReadLines(path);    
        }
    }
}
