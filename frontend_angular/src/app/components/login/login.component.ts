import { AuthguardService } from '../../services/authguard.service';  // Servicio para obtener los idiomas
import { Router, RouterLink } from '@angular/router';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Usuario } from '../../models/class/Usuario';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule,CommonModule, RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginData = {
    username: '',
    password: ''
  };

  errorMessage: string | null = null;

  constructor(private authguardService: AuthguardService, private router: Router) {}

  onSubmit() {
    this.errorMessage = null; // Resetea el mensaje de error

    this.authguardService.login(this.loginData)
      .subscribe({
        next: (response) => {
          console.log('Login exitoso', response);
          // Redirige al dashboard u otra ruta
          //this.router.navigate(['/mastercandidatos']);
        },
        error: (error) => {
          console.error('Error en el login', error);
          this.errorMessage = 'Usuario o contraseña incorrectos';
        }
      });
  }
}