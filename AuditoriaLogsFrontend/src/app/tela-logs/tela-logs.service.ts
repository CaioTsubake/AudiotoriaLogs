import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuditoriaLog } from '../model/auditoriaLogs.model';

@Injectable({
  providedIn: 'root'
})
export class TelaLogsService {

  constructor(private http: HttpClient) { }

  pegarTodosOsLogs(){
    let url = "https://localhost:44314/api/logs?mensagem";
    let resultado = this.http.get<AuditoriaLog[]>(url);

    return resultado;
  }
}
