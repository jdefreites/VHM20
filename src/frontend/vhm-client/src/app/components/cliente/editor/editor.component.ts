import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { ClienteService } from '@app/services';
import * as moment from 'momnet';

@Component({ templateUrl: './editor.component.html' })
export class EditorComponent implements OnInit {
  form!: FormGroup;
  id?: number;
  title!: string;
  loading = false;
  submitting = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private clienteService: ClienteService
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];

    this.form = this.formBuilder.group({
      id: 0,
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      documentoIdentidad: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
    });

    this.title = 'Crear Cliente';
    if (this.id) {
      // edit mode
      this.title = 'Editar Cliente';
      this.loading = true;
      this.clienteService
        .getById(this.id)
        .pipe(first())
        .subscribe((result) => {
          this.form.patchValue(result);
          this.form
            .get('fechaNacimiento')
            ?.patchValue(moment(result.fechaNacimiento).format('YYYY-MM-DD'));
          this.loading = false;
        });
    }
  }

  get f() {
    return this.form.controls;
  }

  onSubmit() {
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    this.submitting = true;
    console.log(this.form.value);
    this.save()
      .pipe(first())
      .subscribe({
        next: (response) => {
          console.log(response);
          this.router.navigateByUrl('/clientes');
        },
        error: (error) => {
          console.log('ERROR:=>', error);
          this.submitting = false;
        },
      });
  }
  private save() {
    return this.id
      ? this.clienteService.update(this.id!, this.form.value)
      : this.clienteService.create(this.form.value);
  }
}
