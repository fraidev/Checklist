import {Tarefa} from '../tarefa/tarefa';

export interface Usuario {
  id: string;
  nome: string;
  tarefas: Tarefa[];
}
