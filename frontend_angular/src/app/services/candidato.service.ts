import { Candidato } from '../models/class/Candidatos';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CandidatoService {
  private apiUrl = 'https://localhost:7021/api/Candidatos'; 
  constructor(private http: HttpClient) {}

  getCandidatos(): Observable<Candidato[]> {
    return this.http.get<Candidato[]>(this.apiUrl);
  }

  // Obtener una candidato por ID
  getCandiatoById(id: number): Observable<Candidato> {
    return this.http.get<Candidato>(`${this.apiUrl}/${id}`);
  }

  // Crear una nueva candidato
  createCandidato(candidatoData: any): Observable<any> {
    const body = {
      ...candidatoData
    };
    return this.http.post(`${this.apiUrl}`, body);
  }

  // Editar una candidato existente
  updateCandidato(id: number, candidato: Candidato): Observable<Candidato> {
    return this.http.put<Candidato>(`${this.apiUrl}/${id}`, candidato);
  }

  // Eliminar una candidato
  deleteCandidato(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
