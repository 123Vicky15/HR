import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Puestos } from '../../models/class/Puestos'; 
import { PuestosService } from '../../services/puestos.service'; 
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-puestoeditar',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterLink],
  templateUrl: './puestoeditar.component.html',
  styleUrl: './puestoeditar.component.css'
})
export class PuestoeditarComponent implements OnInit {

  puestoObj: Puestos = new Puestos();
  puestosService = inject(PuestosService);
  id: number = 0;

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    if (this.id) {
      this.puestosService.getPuestoById(this.id).subscribe((res: Puestos) => {
        this.puestoObj = res;
      });
    }
  }

  onEstadoChange(value: boolean) {
    this.puestoObj.estado = value;  // Asignar el valor booleano directamente
    console.log("Estado cambiado a:", this.puestoObj.estado);  // Imprimir para verificar
  }
  
  // onEstadoChange(value: any) {
  //   this.puestoObj.estado = value === 'true';  // Asegura que el valor sea booleano
  // }

  salario() { 
    // Validar que los salarios no sean menores o iguales a 0
    if (this.puestoObj.nivelMinimoSalario <= 0 || this.puestoObj.nivelMaximoSalario <= 0) {
      console.error('El salario mínimo y máximo deben ser mayores que cero.');
      return;
    }
  
    // Validar que el salario mínimo no sea mayor que el salario máximo
    if (this.puestoObj.nivelMinimoSalario > this.puestoObj.nivelMaximoSalario) {
      console.error('El salario mínimo no puede ser mayor que el salario máximo.');
      return;
    }
  
    console.log('Los salarios están correctamente ingresados.');
  }
  
  onUpdatePuesto(form: any): void {
    if (form.valid) {
      this.puestosService.updatePuesto(this.id, this.puestoObj).subscribe(
        res => {
          console.log('Puesto actualizado exitosamente');
          this.router.navigate(['/puestosver']);
        },
        error => {
          if (error.status === 404) {
            alert('Error: El puesto con este ID no existe.');
          } else if (error.status === 500) {
            // Este caso maneja el ArgumentException
            alert('Error: ' + error.error);  // Muestra el mensaje de error del backend
          } else {
            alert('Error: Ha ocurrido un error inesperado.');
          }
        }
      );
    }
  }
}