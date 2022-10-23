using System;

namespace ConexaoDb
{
    public class AuditoriaLog
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Ip { get; set; }
        public string Tipo { get; set; }
        public string Mensagem { get; set; }

    }
}
