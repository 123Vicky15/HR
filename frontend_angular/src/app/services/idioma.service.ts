import { Idiomas } from '../models/class/Idiomas';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IdiomaService {
  private apiUrl = 'https://localhost:7021/api/Idioma'; 
  constructor(private http: HttpClient) {}

  getIdioma(): Observable<Idiomas[]> {
    return this.http.get<Idiomas[]>(this.apiUrl);
  }

  // Obtener una capacitación por ID
  getIdiomaById(id: number): Observable<Idiomas> {
    return this.http.get<Idiomas>(`${this.apiUrl}/${id}`);
  }

  // Crear una nueva capacitación
  createIdioma(idioma: Idiomas): Observable<Idiomas> {
    return this.http.post<Idiomas>(this.apiUrl, idioma);
  }

  // Editar una capacitación existente
  updateIdioma(id: number, idioma: Idiomas): Observable<Idiomas> {
    return this.http.put<Idiomas>(`${this.apiUrl}/${id}`, idioma);
  }

  // Eliminar una capacitación
  deleteIdioma(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
