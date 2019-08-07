import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { ClienteService } from '../core/cliente.service';

@Component({
  selector: 'app-editar-cliente',
  templateUrl: './editar-cliente.component.html',
  styleUrls: ['./editar-cliente.component.scss']
})
export class EditarClienteComponent implements OnInit {
  editForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private router: Router, private clienteService: ClienteService) { }

  ngOnInit() {
    const clienteId = window.localStorage.getItem('editarClienteId');

    if (!clienteId) {
      alert('Ação inválida.');
      this.router.navigate(['listar-cliente']);
      return;
    }
    this.editForm = this.formBuilder.group({
      id: [''],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      cpf: ['', Validators.required],
      email: ['', Validators.required]
    });

    this.clienteService.obterClientePorId(+clienteId)
      .subscribe(data => {
        this.editForm.setValue(data);
      });
  }

  onSubmit() {
    this.clienteService.alterarCliente(this.editForm.value)
      .pipe(first())
      .subscribe(
        data => {
          if (data) {
            alert('Cliente atualizado com sucesso.');
            this.router.navigate(['listar-cliente']);
          } else {
            alert(data.message);
          }
        },
        error => {
          alert(error);
        });
  }
}
