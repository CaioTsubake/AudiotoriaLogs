using System.Collections.Generic;

namespace EntradaDeLogs.Interfaces
{
    public interface IFileWrapper
    {
        bool Exists(string path);
        List<string> ReadLines(string path);
    }
}
