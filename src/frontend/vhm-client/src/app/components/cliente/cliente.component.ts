import { Component, OnInit } from '@angular/core';
import { DecimalPipe, NgFor } from '@angular/common';

@Component({
  selector: 'app-clientes-list',
  standalone: true,
	imports: [NgFor, DecimalPipe],
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
