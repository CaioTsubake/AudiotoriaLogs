import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuditoriaLog } from '../model/auditoriaLogs.model';

@Injectable({
  providedIn: 'root'
})
export class TelaLogsService {

  constructor(private http: HttpClient) { }

  dominio = "https://localhost:44314";

  pegarTodosOsLogs(){
    let url = `${this.dominio}/api/logs?mensagem`;
    let resultado = this.http.get<AuditoriaLog[]>(url);

    return resultado;
  }

  pegarLogsComMensagem(mensagem: string){
    let url = `${this.dominio}/api/logs?mensagem=${mensagem}`;
    let resultado = this.http.get<AuditoriaLog[]>(url);

    return resultado;
  }

  pegarLogsPorPeriodo(dataInicial: string, dataFinal: string){
    let url = `${this.dominio}/api/logs?dataInicial=${dataInicial}&dataFinal=${dataFinal}`;
    let resultado = this.http.get<AuditoriaLog[]>(url);

    return resultado;
  }
}
