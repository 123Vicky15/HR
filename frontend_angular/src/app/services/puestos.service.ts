import { Puestos } from '../models/class/Puestos';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PuestosService {
  private apiUrl = 'https://localhost:7021/api/Puestos'; 
  constructor(private http: HttpClient) {}

  getPuestos(): Observable<Puestos[]> {
    return this.http.get<Puestos[]>(this.apiUrl);
  }

  // Obtener una puestos por ID
  getPuestoById(id: number): Observable<Puestos> {
    return this.http.get<Puestos>(`${this.apiUrl}/${id}`);
  }

  // Crear una nueva puestos
  createPuesto(candidato: Puestos): Observable<Puestos> {
    return this.http.post<Puestos>(this.apiUrl, candidato);
  }

  // Editar una candidato Puestos
  updatePuesto(id: number, puestos: Puestos): Observable<Puestos> {
    return this.http.put<Puestos>(`${this.apiUrl}/${id}`, puestos);
  }

  // Eliminar una Puestos
  deletePuesto(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
