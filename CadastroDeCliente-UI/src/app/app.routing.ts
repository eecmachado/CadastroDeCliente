import { RouterModule, Routes } from '@angular/router';
import { AdicionarClienteComponent } from './adicionar-cliente/adicionar-cliente.component';
import { ListarClienteComponent } from './listar-cliente/listar-cliente.component';
import { EditarClienteComponent } from './editar-cliente/editar-cliente.component';

const routes: Routes = [
  { path: 'adicionar-cliente', component: AdicionarClienteComponent },
  { path: 'listar-cliente', component: ListarClienteComponent },
  { path: 'editar-cliente', component: EditarClienteComponent },
  { path: '', component: ListarClienteComponent }
];

export const routing = RouterModule.forRoot(routes);
