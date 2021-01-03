import { Component, OnInit, ViewChild } from '@angular/core';
import { MensagesErrorComponent } from 'src/app/mensages-error/mensages-error.component';
import { Usuario } from '../shared/model/usuario.model';
import { UsuarioService } from '../shared/services/usuario.service';

@Component({
  selector: 'app-usuario-list',
  templateUrl: './usuario-list.component.html',
  styleUrls: ['./usuario-list.component.css']
})
export class UsuarioListComponent implements OnInit {
  public usuarios: Usuario[];
  @ViewChild(MensagesErrorComponent) errorMsgComponent: MensagesErrorComponent;

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit() {
    this.getListaUsuarios();
  }

  getListaUsuarios() {
    this.usuarioService.getUsuarios()
      .subscribe((usuarios: Usuario[]) => {
        this.usuarios = usuarios;
      }, () => { this.errorMsgComponent.setError('Falha ao buscar usuarios.'); });
  }

  deletaUsuario(id: number) {
    this.usuarioService.deleteUsuario(id)
      .subscribe(() => {
        this.getListaUsuarios();
      }, () => { this.errorMsgComponent.setError('Falha ao deletar usuário.'); });
  }

}
