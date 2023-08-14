import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClienteComponent } from './cliente.component';
import { ListComponent } from './list/list.component';
import { AuthGuard } from '@app/helpers';
import { EditorComponent } from './editor/editor.component';

const routes: Routes = [
  {
    path: '',
    component: ClienteComponent,
    children: [
      { path: '', component: ListComponent, canActivate: [AuthGuard] },
      { path: 'add', component: EditorComponent, canActivate: [AuthGuard] },
      {
        path: 'edit/:id',
        component: EditorComponent,
        canActivate: [AuthGuard],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClienteRoutes {}
