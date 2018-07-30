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


  constructor(private tarefaService: TarefaService, private usuarioService: UsuarioService) { }

  ngOnInit() {
    this.getUsuarios();
    //this.getTarefas();
  }

  pageRefresh() {
    location.reload();
  }

  limpar():void{
    this.tarefas = undefined;
  }

  getUsuarios(): void {
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
    /*
    // oops ... subscribe() is missing so nothing happens
    this.heroesService.deleteHero(hero.id);
    */
  }

  deleteTarefa(tarefa: Tarefa): void {
    this.tarefas = this.tarefas.filter(h => h !== tarefa);
    this.tarefaService.deleteTarefa(tarefa.id).subscribe();
    /*
    // oops ... subscribe() is missing so nothing happens
    this.heroesService.deleteHero(hero.id);
    */
  }
  updateUsuario(tarefa: Tarefa) {
    if (this.editUsuarios) {
      this.usuarioService.updateUsuario(this.editUsuarios)
        .subscribe(usuario => {
          // replace the hero in the heroes list with update from server
          const ix = usuario ? this.usuarios.findIndex(h => h.id === usuario.id) : -1;
          if (ix > -1) { this.usuarios[ix] = usuario; }
        });
      this.editUsuarios = undefined;
    }
  }
}
