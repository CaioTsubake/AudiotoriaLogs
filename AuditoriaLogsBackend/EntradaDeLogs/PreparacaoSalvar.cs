using ConexaoDb;
using System;
using System.Collections.Generic;

namespace EntradaDeLogs
{
    public class PreparacaoSalvar
    {
        public List<AuditoriaLog> ConverterLogs(List<string> inputs) 
        {
            List <AuditoriaLog> logs = new List<AuditoriaLog>();

            foreach (var linha in inputs)
            {
                if (!string.IsNullOrEmpty(linha))
                {
                    AuditoriaLog log = ParseLog(linha);
                    logs.Add(log);
                }
            }

            return logs;
        }

        public AuditoriaLog ParseLog(string linha)
        {
            AuditoriaLog log = new AuditoriaLog();

            log.DataHora = ObterDataHora(linha);
            log.Ip = ObterIp(linha);
            log.Tipo = ObterTipo(linha);
            log.Mensagem = ObterMensagem(linha);

            return log;
        }

        private DateTime ObterDataHora(string linha)
        {
            var stringDataHora = linha.Substring(0, 15);
            var partesData = stringDataHora.Split(' ');
            // Como não sabemos o ano que os logs foram gravados, assumiremos o ano atual
            int ano = DateTime.Now.Year;

            // O mes vem como uma string de 3 letras então precisa ser determinado qual o numero correspondente
            var nomeMes = partesData[0];
            int mes = DeterminarNumeroMes(nomeMes);
   
            int dia = Convert.ToInt32(partesData[1]);
            var dataHora = new DateTime(ano, mes, dia);

            // Pegando as partes que constituem o horario da data recebida
            var horario = partesData[2];
            var parteshorario = horario.Split(':');
            int hora = Convert.ToInt32(parteshorario[0]);
            int minuto = Convert.ToInt32(parteshorario[1]);
            int segundo = Convert.ToInt32(parteshorario[2]);
            var timeSpan = new TimeSpan(hora, minuto, segundo);

            // Adicionando o timeSpan ao Datetime, faz com que o horario seja o timeSpan
            // Ex: Adicionar TimeSpan(15,30,0) faz com que o horario da data seja alterado para 15:30
            dataHora = dataHora.Date + timeSpan;

            return dataHora;
        }

        private int DeterminarNumeroMes(string nomeMes)
        {
            int numeroMes = 1;
            switch (nomeMes.ToUpper())
            {
                case "JAN":
                    numeroMes = 1;
                    break;
                case "FEB":
                    numeroMes = 2;
                    break;
                case "MAR":
                    numeroMes = 3;
                    break;
                case "APR":
                    numeroMes = 4;
                    break;
                case "MAY":
                    numeroMes = 5;
                    break;
                case "JUN":
                    numeroMes = 6;
                    break;
                case "JUL":
                    numeroMes = 7;
                    break;
                case "AUG":
                    numeroMes = 8;
                    break;
                case "SEP":
                    numeroMes = 9;
                    break;
                case "OCT":
                    numeroMes = 10;
                    break;
                case "NOV":
                    numeroMes = 11;
                    break;
                case "DEC":
                    numeroMes = 12;
                    break;
                default:
                    break;
            }

            return numeroMes;
        }

        private static string ObterIp(string linha)
        {
            // os primeiros 15 digitos são sempre a data
            // o primeiro espaço depois da data mostra onde o ip termina
            var dadosSemData = linha.Remove(0, 16);
            var fimIp = dadosSemData.IndexOf(' ');
            var stringIp = dadosSemData.Substring(0, fimIp);
            // Removendo o "ip-" da linha
            stringIp = stringIp.Replace("ip-", "");
            return stringIp;
        }
        private static string ObterTipo(string linha)
        {
            var comecoTipo = linha.IndexOf(' ', 16);
            var fimTipo = linha.IndexOf(": ");
            var tamanhoTipo = fimTipo - comecoTipo;
            var tipo = linha.Substring(comecoTipo, tamanhoTipo).Trim();
            return tipo;
        }
        private static string ObterMensagem(string linha)
        {
            var inicioMensagem = linha.IndexOf(": ");
            // Avançando 2 caracteres para não incluir ": "
            var mensagem = linha.Substring(inicioMensagem + 2);
            return mensagem;
        }

    }
}
