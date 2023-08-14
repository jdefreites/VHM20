import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import {
  NgbAlertModule,
  NgbDatepickerModule,
} from '@ng-bootstrap/ng-bootstrap';

import { ClienteComponent } from './cliente.component';
import { ListComponent } from './list/list.component';
import { ClienteRoutes } from './cliente.routing';
import { EditorComponent } from './editor/editor.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgbDatepickerModule,
    NgbAlertModule,
    ClienteRoutes,
  ],
  declarations: [ClienteComponent, ListComponent, EditorComponent],
})
export class ClienteModule {}
