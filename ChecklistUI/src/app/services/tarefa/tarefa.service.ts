///<reference path="../../../../node_modules/rxjs/internal/operators/filter.d.ts"/>
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Tarefa} from './tarefa';
import {Usuario} from '../usuario/usuario';

@Injectable({
  providedIn: 'root'
})
export class TarefaService {
  checklistUrl = 'https://localhost:5001/api/Tarefas';  // URL to web api

  constructor(
    private http: HttpClient) {
  }

  /** GET heroes from the server */
  getTarefas (): Observable<Tarefa[]> {
    return this.http.get<Tarefa[]>(this.checklistUrl);
  }
  getTarefasByUsuario (usuario: Usuario): Observable<Tarefa[]> {
    return this.http.get<Tarefa[]>(this.checklistUrl + '/byUsuario/' + usuario.id);
  }
  addTarefa (tarefa: Tarefa): Observable<Tarefa> {
    return this.http.post<Tarefa>(this.checklistUrl, tarefa);
  }
}
