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
  editUsuarios: Usuario; // the hero currently being edited
  myControl = new FormControl();

  public tarefas: Tarefa[];
  public ediTarefa: Tarefa;
  selectedOption: string;
/*

  @ViewChild(CourseContentRegisterComponent)
  public contentComponent: CourseContentRegisterComponent;*/

  // the hero currently being edited

  constructor(private tarefaService: TarefaService,private usuarioService: UsuarioService) { }

  ngOnInit() {
    this.getUsuarios();
  }

  getUsuarios(): void {
    this.usuarioService.getUsuarios()
      .subscribe(usuarios => this.usuarios = usuarios);
  }
  getTarefas(): void {
    this.tarefaService.getTarefas()
      .subscribe(tarefas => (this.tarefas = tarefas));
  }
  getTarefarByUsuario(std: string): void {
    this.tarefas = this.tarefas.filter(tar => tar.responsavel.nome === std);
  }
}
