import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { ClienteModel } from '../model/cliente-model';
import { ClienteService } from '../core/cliente.service';

@Component({
  selector: 'app-listar-cliente',
  templateUrl: './listar-cliente.component.html',
  styleUrls: ['./listar-cliente.component.scss']
})
export class ListarClienteComponent implements OnInit {

  clientes: ClienteModel[];

  constructor(private router: Router, private clienteService: ClienteService) { }

  ngOnInit() {
    this.clienteService.obterClientes()
      .subscribe((resp: any) => {
        if (resp) {
          this.clientes = resp;
        }
      });
  }

  deletarCliente(cliente: ClienteModel): void {
    this.clienteService.deletarCliente(cliente.id)
      .subscribe(data => {
        this.clientes = this.clientes.filter(u => u !== cliente);
      });
  }

  alterarCliente(cliente: ClienteModel): void {
    window.localStorage.removeItem('editarClienteId');
    window.localStorage.setItem('editarClienteId', cliente.id.toString());
    this.router.navigate(['editar-cliente']);
  }

  adicionarCliente(): void {
    this.router.navigate(['adicionar-cliente']);
  }
}
