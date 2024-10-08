import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Puestos } from '../../models/class/Puestos'; 
import { PuestosService } from '../../services/puestos.service'; // Servicio para manejar los puestos
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-puestosformcrear',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './puestoscrear.component.html',
  styleUrl: './puestoscrear.component.css'
})
export class PuestosCrearComponent implements OnInit {
  puestoObj: Puestos = new Puestos(); // Instancia vacía de Puesto
  puestoList: Puestos[] = []; // Lista de puestos existentes

  puestoService = inject(PuestosService); // Inyecta el servicio de Puesto

  // Cambia el estado de booleano a Activo o Inactivo
  onEstadoChange(value: boolean) {
    this.puestoObj.estado = value;  // Asignar el valor booleano directamente
    console.log("Estado cambiado a:", this.puestoObj.estado);  // Imprimir para verificar
  }

  // Método para crear un nuevo puesto
  onCreatePuesto(form: NgForm) {
    this.puestoService.createPuesto(this.puestoObj).subscribe({
      next: (res: any) => {
        console.log('Puesto creado:', res);
        this.puestoList.push(res); // Añade el nuevo puesto a la lista
        form.resetForm(); // Resetea los campos del formulario
        this.puestoObj = new Puestos(); // Reinicia el objeto de puesto
      },
      error: (err) => {
        console.error('Error al crear el puesto:', err);
      }
    });
  }

  salario() { 
    // Validar que el salario mínimo no sea mayor que el salario máximo
    if (this.puestoObj.nivelMinimoSalario > this.puestoObj.nivelMaximoSalario) {
      alert('El salario mínimo no puede ser mayor que el salario máximo.');
      return;
    }
  
    console.log('Los salarios están correctamente ingresados.');
  }
  // Inicialización del componente (si es necesario)
  ngOnInit(): void {
    // Lógica adicional para inicialización si es necesario
  }
}
