///<reference path="../services/tarefa/tarefa.ts"/>
import { Component, OnInit, ViewChild } from '@angular/core';
import {Tarefa} from '../services/tarefa/tarefa';
import {TarefaService} from '../services/tarefa/tarefa.service';
import { filter } from 'rxjs/operators';
import {UsuarioService} from '../services/usuario/usuario.service';
import {Usuario} from '../services/usuario/usuario';
import {FormControl} from '@angular/forms';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {
  usuarios: Usuario[];
  editUsuarios: Usuario;
  myControl = new FormControl();
  public selectedUsuario: Usuario;

  public tarefas: Tarefa[];
  public editTarefa: Tarefa;
  public selectedTarefa: Usuario;

  public alterarUsuario: boolean = false;


  constructor(private tarefaService: TarefaService, private usuarioService: UsuarioService) { }

  ngOnInit() {
    this.getUsuarios();
  }

  abrirAlterador():void{
    this.alterarUsuario ? this.alterarUsuario = false : this.alterarUsuario = true;
  }

  limpar():void{
    this.tarefas = undefined;
  }

  getUsuarios(): void {
    this.editUsuarios = undefined;
    this.usuarioService.getUsuarios()
      .subscribe(usuarios => this.usuarios = usuarios);
  }

  getTarefas(): void {
    this.tarefaService.getTarefas()
      .subscribe(tarefas => (this.tarefas = tarefas));
  }

  getTarefasByUsuario(usuario: Usuario): void {
    this.tarefaService.getTarefasByUsuario(usuario)
      .subscribe(tarefas => (this.tarefas = tarefas));
  }

  displayFn(user?: Usuario): string | undefined {
    return user ? user.nome : undefined;
  }

  addUsuario(nome: string): void {
    this.editUsuarios = undefined;
    nome = nome.trim();
    if (!nome) { return; }

    // The server will generate the id for this new Usuario
    const newUsuario: Usuario = { nome } as Usuario;
    this.usuarioService.addUsuario(newUsuario)
      .subscribe(usuario => this.usuarios.push(usuario));
  }

  addTarefa(descricao: string, concluido: boolean, responsavel: Usuario): void {
    this.editTarefa = undefined;
    descricao = descricao.trim();
    if (!descricao) { return; }

    // The server will generate the id for this new Usuario
    const newTarefa: Tarefa = { descricao , concluido , responsavel } as Tarefa;
    this.tarefaService.addTarefa(newTarefa)
      .subscribe(tarefas => this.tarefas.push(tarefas));
  }

  deleteUsuario(usuario: Usuario): void {
    this.usuarios = this.usuarios.filter(h => h !== usuario);
    this.usuarioService.deleteUsuario(usuario.id).subscribe();
  }

  deleteTarefa(tarefa: Tarefa): void {
    this.tarefas = this.tarefas.filter(h => h !== tarefa);
    this.tarefaService.deleteTarefa(tarefa.id).subscribe();
  }

  updateConcluirTarefa(tarefa: Tarefa) {
    tarefa.concluido = tarefa.concluido = true;
    this.editTarefa = tarefa;
    if (this.editTarefa) {
      this.tarefaService.updateTarefa(this.editTarefa)
        .subscribe(tarefas => {
          // replace the hero in the heroes list with update from server
          const ix = tarefas ? this.tarefas.findIndex(h => h.id === tarefas.id) : -1;
          if (ix > -1) { this.tarefas[ix] = tarefa; }
        });
      this.editTarefa = undefined;
    }
  }
  updateUsuario(usuario: Usuario, newNome: string) {
    usuario.nome = newNome;
    this.editUsuarios = usuario;
    if (this.editUsuarios) {
      this.usuarioService.updateUsuario(this.editUsuarios)
        .subscribe(usuarios => {
          // replace the hero in the heroes list with update from server
          const ix = usuarios ? this.usuarios.findIndex(h => h.id === usuarios.id) : -1;
          if (ix > -1) { this.usuarios[ix] = usuario; }
        });
      this.editUsuarios = undefined;
    }
  }
}
