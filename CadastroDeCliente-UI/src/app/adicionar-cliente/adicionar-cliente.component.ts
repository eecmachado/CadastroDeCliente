import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClienteService } from '../core/cliente.service';

@Component({
  selector: 'app-adicionar-cliente',
  templateUrl: './adicionar-cliente.component.html',
  styleUrls: ['./adicionar-cliente.component.scss']
})

export class AdicionarClienteComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private router: Router, private clienteService: ClienteService) { }

  addForm: FormGroup;

  ngOnInit() {
    this.addForm = this.formBuilder.group({
      id: [],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      cpf: ['', Validators.required],
      email: ['', Validators.required]
    });
  }

  onSubmit() {
    this.clienteService.adicionarCliente(this.addForm.value)
      .subscribe(data => {
        this.router.navigate(['listar-cliente']);
      });
  }
}

