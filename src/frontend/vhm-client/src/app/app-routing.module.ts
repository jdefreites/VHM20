import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from './helpers';
import {
  HomeComponent,
  LoginComponent,
  PlacaComponent,
  SolicitudComponent,
  VehiculoComponent
} from './components';

const clienteModule = () => import('./components/cliente/cliente.module').then(i=>i.ClienteModule);

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'clientes', loadChildren: clienteModule },
  { path: 'placas', component: PlacaComponent, canActivate: [AuthGuard] },
  { path: 'solicitudes', component: SolicitudComponent, canActivate: [AuthGuard] },
  { path: 'vehiculos', component: VehiculoComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
