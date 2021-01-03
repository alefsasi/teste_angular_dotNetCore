import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MensagesErrorComponent } from 'src/app/mensages-error/mensages-error.component';
import { Usuario } from '../shared/model/usuario.model';
import { UsuarioService } from '../shared/services/usuario.service';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-usuario-update',
  templateUrl: './usuario-update.component.html',
  styleUrls: ['./usuario-update.component.css']
})
export class UsuarioUpdateComponent implements OnInit {

  @ViewChild(MensagesErrorComponent) errorMsgComponent: MensagesErrorComponent;
  public usuario: Usuario = <Usuario>{};

  constructor(private usuarioService: UsuarioService,
    private router: Router,
    private activatedRoute: ActivatedRoute,) { }

  ngOnInit(): void {
    this.getUsuario(this.activatedRoute.snapshot.params.id);
  }


  getUsuario(id: number) {
    this.usuarioService.getUsuariobyId(id)
      .subscribe((usuario: Usuario) => {
        this.usuario = usuario;
      }, () => { this.errorMsgComponent.setError('Falha ao buscar usuario.'); });
  }

  updateUsuario(usuario: Usuario) {
    this.usuarioService.updateUsuario(usuario)
      .subscribe(
        () => { this.router.navigateByUrl('usuario/listar'); },
        (err) => { this.errorMsgComponent.setError(err ? `Falha ao atualizar usuario: ${err.message}` : "Falha ao atualizar usuario"); });
  }
}
