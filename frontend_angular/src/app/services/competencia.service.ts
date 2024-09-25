import { Competencias } from '../models/class/Competencias';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompetenciaService {
  private apiUrl = 'https://localhost:7021/api/Competencia'; 
  constructor(private http: HttpClient) {}

  getCompetencia(): Observable<Competencias[]> {
    return this.http.get<Competencias[]>(this.apiUrl);
  }

  // Obtener una capacitación por ID
  getCompetenciaById(id: number): Observable<Competencias> {
    return this.http.get<Competencias>(`${this.apiUrl}/${id}`);
  }

  // Crear una nueva capacitación
  createCompetencia(competencia: Competencias): Observable<Competencias> {
    return this.http.post<Competencias>(this.apiUrl, competencia);
  }

  // Editar una capacitación existente
  updateCompetencia(id: number, competencia: Competencias): Observable<Competencias> {
    return this.http.put<Competencias>(`${this.apiUrl}/${id}`, competencia);
  }

  // Eliminar una capacitación
  deleteCompetencia(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
