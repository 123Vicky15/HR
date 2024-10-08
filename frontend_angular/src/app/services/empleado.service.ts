import { Empleado } from '../models/class/Empleado';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {
  private apiUrl = 'https://localhost:7021/api/Empleados';  

  constructor(private http: HttpClient) {}

  getEmpleados(): Observable<any> {
    return this.http.get<any[]>(`${this.apiUrl}`);
  }
  convertirCandidatoAEmpleado(candidatoId: number, empleadoData: any): Observable<any> {
    const body = {
      ...empleadoData,
      candidatoId,
    };
    return this.http.post(`${this.apiUrl}/convertir`, body);
  }
}
