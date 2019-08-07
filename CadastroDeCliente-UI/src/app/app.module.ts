import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AdicionarClienteComponent } from './adicionar-cliente/adicionar-cliente.component';
import { EditarClienteComponent } from './editar-cliente/editar-cliente.component';
import { ListarClienteComponent } from './listar-cliente/listar-cliente.component';
import { ClienteService } from './core/cliente.service';
import { ReactiveFormsModule } from '@angular/forms';
import { routing } from './app.routing';
import { HttpClientModule, /* other http imports */ } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    AdicionarClienteComponent,
    EditarClienteComponent,
    ListarClienteComponent
  ],
  imports: [
    BrowserModule,
    routing,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [ClienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
