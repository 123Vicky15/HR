import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICapacitaciones } from '../models/interface/Capacitaciones';

@Injectable({
  providedIn: 'root',
})
export class CapacitacionService {
  private apiUrl = 'https://localhost:7021/api/Capacitacion'; // Reemplaza con tu URL de la API

  constructor(private http: HttpClient) {}

  // Obtener todas las capacitaciones
  getCapacitaciones(): Observable<ICapacitaciones[]> {
    return this.http.get<ICapacitaciones[]>(this.apiUrl);
  }

  // Obtener una capacitación por ID
  getCapacitacionById(id: number): Observable<ICapacitaciones> {
    return this.http.get<ICapacitaciones>(`${this.apiUrl}/${id}`);
  }

  // Crear una nueva capacitación
  createCapacitacion(capacitacion: ICapacitaciones): Observable<ICapacitaciones> {
    return this.http.post<ICapacitaciones>(this.apiUrl, capacitacion);
  }

  // Editar una capacitación existente
  updateCapacitacion(id: number, capacitacion: ICapacitaciones): Observable<ICapacitaciones> {
    return this.http.put<ICapacitaciones>(`${this.apiUrl}/${id}`, capacitacion);
  }

  // Eliminar una capacitación
  deleteCapacitacion(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
