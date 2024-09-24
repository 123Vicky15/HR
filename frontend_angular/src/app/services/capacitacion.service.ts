import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Capacitaciones } from '../models/class/Capacitaciones';

@Injectable({
  providedIn: 'root',
})
export class CapacitacionService {
  private apiUrl = 'https://localhost:7021/api/Capacitacion'; // Reemplaza con tu URL de la API

  constructor(private http: HttpClient) {}

  // Obtener todas las capacitaciones
  getCapacitaciones(): Observable<Capacitaciones[]> {
    return this.http.get<Capacitaciones[]>(this.apiUrl);
  }

  // Obtener una capacitación por ID
  getCapacitacionById(id: number): Observable<Capacitaciones> {
    return this.http.get<Capacitaciones>(`${this.apiUrl}/${id}`);
  }

  // Crear una nueva capacitación
  createCapacitacion(capacitacion: Capacitaciones): Observable<Capacitaciones> {
    return this.http.post<Capacitaciones>(this.apiUrl, capacitacion);
  }

  // Editar una capacitación existente
  updateCapacitacion(id: number, capacitacion: Capacitaciones): Observable<Capacitaciones> {
    return this.http.put<Capacitaciones>(`${this.apiUrl}/${id}`, capacitacion);
  }

  // Eliminar una capacitación
  deleteCapacitacion(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
