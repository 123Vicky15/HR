import { ExperienciaLaboral } from '../models/class/ExperienciaLaboral';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExperienciaLaboralService {
  private apiUrl = 'https://localhost:7021/api/ExperienciaLaboral'; 
  constructor(private http: HttpClient) {}

  getExperienciaLaboral(): Observable<ExperienciaLaboral[]> {
    return this.http.get<ExperienciaLaboral[]>(this.apiUrl);
  }

  // Obtener una capacitación por ID
  getExperienciaLaboralById(id: number): Observable<ExperienciaLaboral> {
    return this.http.get<ExperienciaLaboral>(`${this.apiUrl}/${id}`);
  }

  // Crear una nueva capacitación
  createExperienciaLaboral(competencia: ExperienciaLaboral): Observable<ExperienciaLaboral> {
    return this.http.post<ExperienciaLaboral>(this.apiUrl, competencia);
  }

  // Editar una capacitación existente
  updateExperienciaLaboral(id: number, competencia: ExperienciaLaboral): Observable<ExperienciaLaboral> {
    return this.http.put<ExperienciaLaboral>(`${this.apiUrl}/${id}`, competencia);
  }

  // Eliminar una capacitación
  deleteExperienciaLaboral(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
