import { Router, RouterLink } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthguardService } from '../../services/authguard.service';  
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule, CommonModule, RouterLink],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent implements OnInit {

  registerForm!: FormGroup;
  
  constructor(private formBuilder: FormBuilder,private authguardService: AuthguardService, private router: Router) {}

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, { validator: this.passwordMatchValidator });
  }

  passwordMatchValidator(form: FormGroup) {
    return form.get('password')?.value === form.get('confirmPassword')?.value
      ? null : { mismatch: true };
  }

  onSubmit() {
    if (this.registerForm.valid) {
      // Excluir confirmPassword del objeto a enviar al backend
      const { confirmPassword, ...userData } = this.registerForm.value;
  
      this.authguardService.register(userData).subscribe({
        next: (response) => {
          console.log('Usuario registrado:', response);
          // Puedes redirigir o mostrar un mensaje de éxito
          this.router.navigate(['/login']);
        },
        error: (error) => {
          console.error('Error en el registro:', error);
        }
      });
    }
  }  
}