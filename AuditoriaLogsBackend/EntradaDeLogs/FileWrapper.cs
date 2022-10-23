using EntradaDeLogs.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EntradaDeLogs
{
    public class FileWrapper : IFileWrapper
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public List<string> ReadLines(string path)
        {
            return File.ReadLines(path).ToList();
        }
    }
}
