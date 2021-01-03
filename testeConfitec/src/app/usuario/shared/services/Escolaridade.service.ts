import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Escolaridade } from '../model/Escolaridade.model';


@Injectable()
export class EscolaridadeService {

  constructor(private http: HttpClient) { }

  public apiEscolaridade = `${environment.urlApi}/escolaridade`;

  getEscolaridade(): Observable<Escolaridade[]> {
    const url = `${this.apiEscolaridade}`;
    return this.http.get<Escolaridade[]>(url);

  }
  getEscolaridadebyId(id: number): Observable<Escolaridade> {
    const url = `${this.apiEscolaridade}/${id}`;
    return this.http.get<Escolaridade>(url);
  }

}
