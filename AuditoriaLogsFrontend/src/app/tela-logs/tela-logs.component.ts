import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { AuditoriaLog } from '../model/auditoriaLogs.model';

@Component({
  selector: 'app-tela-logs',
  templateUrl: './tela-logs.component.html',
  styleUrls: ['./tela-logs.component.css']
})
export class TelaLogsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  colunasTabela: string[] = ['Id', 'DataHora', 'Ip', 'Tipo', 'Mensagem'];

  LogsRecebidos : AuditoriaLog[] =[
    {
      "Id": 2,
      "DataHora": "2022-11-30T06:39:00",
      "Ip": "172-31-27-153",
      "Tipo": "CRON[21882]",
      "Mensagem": "pam_unix(cron:session): session closed for user root"
  },
  {
      "Id": 3,
      "DataHora": "2022-11-30T06:47:01",
      "Ip": "172-31-27-153",
      "Tipo": "CRON[22087]",
      "Mensagem": "pam_unix(cron:session): session opened for user root by (uid=0)"
  },
  {
      "Id": 5,
      "DataHora": "2022-11-30T06:47:03",
      "Ip": "172-31-27-153",
      "Tipo": "CRON[22087]",
      "Mensagem": "pam_unix(cron:session): session closed for user root"
  },
  ];

  dataSource = new MatTableDataSource(this.LogsRecebidos);



}
