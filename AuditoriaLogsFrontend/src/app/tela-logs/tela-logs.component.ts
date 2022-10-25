import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { AuditoriaLog } from '../model/auditoriaLogs.model';
import { TelaLogsService } from './tela-logs.service';

@Component({
  selector: 'app-tela-logs',
  templateUrl: './tela-logs.component.html',
  styleUrls: ['./tela-logs.component.css']
})
export class TelaLogsComponent implements OnInit {

  constructor(private logsService: TelaLogsService) { }

  ngOnInit(): void {
    this.pegarTodosOsLogs();
  }

  colunasTabela: string[] = ['Id', 'DataHora', 'Ip', 'Tipo', 'Mensagem'];

  LogsRecebidos : AuditoriaLog[] = [];

  dataSource = new MatTableDataSource(this.LogsRecebidos);

  pegarTodosOsLogs(){
    this.logsService.pegarTodosOsLogs().subscribe(data => {
      this.LogsRecebidos = data;
    });
  }



}
