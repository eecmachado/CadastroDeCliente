import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClienteModel } from '../model/cliente-model';
import { CadastrarClienteModel } from '../model/cadastrarCliente-model';
import { Observable } from 'rxjs/index';
import { ClienteResponse } from '../model/cliente.response';

@Injectable()
export class ClienteService {


  constructor(private http: HttpClient) {
  }

  baseUrl = 'https://localhost:5001/api/Cliente/';

  obterClientes(): Observable<ClienteResponse> {
    return this.http.get<ClienteResponse>(this.baseUrl);
  }

  obterClientePorId(id: number): Observable<ClienteResponse> {
    return this.http.get<ClienteResponse>(this.baseUrl + id);
  }

  adicionarCliente(body: CadastrarClienteModel): Observable<ClienteResponse> {
    return this.http.post<ClienteResponse>(this.baseUrl, body);
  }

  alterarCliente(body: ClienteModel): Observable<ClienteResponse> {
    return this.http.put<ClienteResponse>(this.baseUrl, body);
  }

  deletarCliente(id: number): Observable<ClienteResponse> {
    return this.http.delete<ClienteResponse>(this.baseUrl + id);
  }
}
