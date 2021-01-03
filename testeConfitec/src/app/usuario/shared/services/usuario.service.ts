import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../model/usuario.model';

@Injectable()
export class UsuarioService {

  constructor(private http: HttpClient) { }
  
  public apiUsuario = `${environment.urlApi}/usuario`;

  getUsuarios(): Observable<Usuario[]> {
    const url = `${this.apiUsuario}/listar`
    return this.http.get<Usuario[]>(url);
   
  }
  getUsuariobyId(id: number): Observable<Usuario> {
    const url = `${this.apiUsuario}/${id}`;
    return this.http.get<Usuario>(url);
  }

  createUsuario(usuario: Usuario): Observable<Usuario> {
    const url = `${this.apiUsuario}/create`;
    return this.http.post<Usuario>(url, usuario);
  }

  updateUsuario(usuario: Usuario): Observable<Usuario> {
    const url = `${this.apiUsuario}/update/${usuario.id}`;
    return this.http.put<Usuario>(url, usuario);
  }

  deleteUsuario(id: number): Observable<Usuario> {
    const url = `${this.apiUsuario}/delete/${id}`;
    return this.http.delete<Usuario>(url);
  }
}

