import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from '@environments/environment';
import { Cliente } from '@app/models/Cliente';

const baseUrl = `${environment.API_URL}/cliente`;
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};
@Injectable({
  providedIn: 'root',
})
export class ClienteService {
  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<Cliente[]>(baseUrl);
  }

  getById(id: number) {
    return this.http.get<Cliente>(`${baseUrl}/${id}`);
  }

  create(params: any) {
    return this.http.post(baseUrl, params, httpOptions);
  }

  update(id: number, params: any) {
    return this.http.put(`${baseUrl}/${id}`, params, httpOptions);
  }

  delete(id: number) {
    return this.http.delete(`${baseUrl}/${id}`);
  }
}
