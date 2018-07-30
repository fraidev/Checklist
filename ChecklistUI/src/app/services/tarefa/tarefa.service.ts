///<reference path="../../../../node_modules/rxjs/internal/operators/filter.d.ts"/>
import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Tarefa} from './tarefa';
import {Usuario} from '../usuario/usuario';
import {catchError, filter} from 'rxjs/operators';

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
  searchTarefas(term: string): Observable<Tarefa[]> {
    term = term.trim();

    // Add safe, URL encoded search parameter if there is a search term
    const options = term ?
      { params: new HttpParams().set('descricao', term) } : {};

    return this.http.get<Tarefa[]>(this.checklistUrl, options);
  }
}
