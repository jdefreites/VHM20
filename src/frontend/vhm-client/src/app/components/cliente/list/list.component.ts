import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { Cliente } from '@app/models/Cliente';
import { ClienteService } from '@app/services';

@Component({ templateUrl: './list.component.html' })
export class ListComponent implements OnInit {
  clientes?: Cliente[] = [];

  constructor(private clienteService: ClienteService) {}

  ngOnInit() {
    this.clienteService
      .getAll()
      .pipe(first())
      .subscribe((clientes) => (this.clientes = clientes));
  }

  deleteCliente(id: number) {
    //const cliente = this.clientes!.find((x) => x.id === id);
    //cliente.isDeleting = true;
    this.clienteService
      .delete(id)
      .pipe(first())
      .subscribe(
        () => (this.clientes = this.clientes!.filter((x) => x.id !== id))
      );
  }
}
