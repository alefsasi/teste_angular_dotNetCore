import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { MensagesErrorComponent } from 'src/app/mensages-error/mensages-error.component';
import { Usuario } from '../shared/model/usuario.model';
import {UsuarioService} from '../shared/services/usuario.service';

@Component({
  selector: 'app-usuario-create',
  templateUrl: './usuario-create.component.html',
  styleUrls: ['./usuario-create.component.css']
})
export class UsuarioCreateComponent implements OnInit {
  @ViewChild(MensagesErrorComponent) errorMsgComponent: MensagesErrorComponent;
  
  constructor(private usuarioService: UsuarioService, private router: Router) { }
  
  ngOnInit(): void {
  }
  createUsuario(usuario: Usuario) {
    this.usuarioService.createUsuario(usuario)
      .subscribe(
        () => { this.router.navigateByUrl('usuario/listar'); },
        (err) => { this.errorMsgComponent.setError(err ? `Falha ao criar usuario: ${err.message}` : "Falha ao criar usuario"); });
  }
}
