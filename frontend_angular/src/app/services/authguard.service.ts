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


  login(loginData : { username: string; password: string }): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, loginData).pipe(
      tap(response => {
        if (loginData.username === 'empleadoHR') {

          response.rol = 'empleado';
        }  
        localStorage.setItem('rolUsuario', response.rol);

        this.router.navigate(['/']);
      })
    );
  }

  register(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.apiUrl}/register`, usuario);
  }
}