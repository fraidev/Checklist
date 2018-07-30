import {Usuario} from '../usuario/usuario';

export interface Tarefa {
  id: string;
  criador: string;
  criacao: string;
  descricao: string;
  concluido: boolean;
  responsavel: Usuario;
}
