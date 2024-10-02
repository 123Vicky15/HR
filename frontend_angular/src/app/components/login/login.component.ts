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
  credentials = {
    username: '',
    password: ''
  };

  constructor(private authService: AuthguardService) { }

  login() {
    const usuario = new Usuario(0, this.credentials.username, this.credentials.password, '');
    this.authService.login(usuario).subscribe(
      response => {
        console.log('Login exitoso:', response);
      },
      error => {
        console.error('Error en el login:', error);
      }
    );
  }
}