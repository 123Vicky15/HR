import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../models/class/Usuario';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthguardService {
  private apiUrl = 'https://localhost:7021/api/User';
  user: Usuario = <Usuario>{};

  constructor(private http: HttpClient, private router: Router) { }

  login(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.apiUrl}/login`, usuario)
      .pipe(
        tap((res: Usuario) => {
          this.user = res;
          if (res.rol === 'Empleado') {
            this.router.navigate(['/master']);
          } else if (res.rol === 'Candidato') {
            this.router.navigate(['/mastercandidatos']);
          }
        })
      );
  }

  register(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.apiUrl}/register`, usuario);
  }
}