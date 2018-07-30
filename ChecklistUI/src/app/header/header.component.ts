import {Component, ViewChild} from '@angular/core';
import {FormControl} from '@angular/forms';
import { UsuarioService } from '../services/usuario/usuario.service';
import { Usuario } from '../services/usuario/usuario';
import {ContentComponent} from '../content/content.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent {

  constructor() { }

  ngOnInit() {
  }
}
