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

  inputMensagem = "";
  dataInicial = "";
  dataFinal = "";

  pegarTodosOsLogs(){
    this.logsService.pegarTodosOsLogs().subscribe(data => {
      this.LogsRecebidos = data;
    });
  }

  buscarPorMensagem(){
    this.logsService.pegarLogsComMensagem(this.inputMensagem).subscribe(data => {
      this.LogsRecebidos = data;
    });
  }

  buscarPorPeriodo(){
    console.log("buscando por datas: " + this.dataInicial + " " + this.dataFinal);
    this.logsService.pegarLogsPorPeriodo(this.dataInicial, this.dataFinal).subscribe(data => {
      this.LogsRecebidos = data;
    });

  }


}
