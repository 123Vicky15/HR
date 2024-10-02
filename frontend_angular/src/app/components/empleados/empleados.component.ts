import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute, RouterLink } from '@angular/router';
import { Empleado } from '../../models/class/Empleado';
import { EmpleadoService } from '../../services/empleado.service';
import { NgForm } from '@angular/forms';
import { jsPDF } from 'jspdf'; // Importa jsPDF para generar el PDF


@Component({
  selector: 'app-empleados',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './empleados.component.html',
  styleUrl: './empleados.component.css'
})
export class EmpleadosComponent implements OnInit {
  empleados: any[] = []; // Almacena todos los empleados
  empleadosFiltrados: any[] = []; // Almacena los empleados filtrados
  fechaDesde!: string; // Fecha de inicio del filtro
  fechaHasta!: string; // Fecha de fin del filtro

  constructor(private empleadoService: EmpleadoService) {}

  ngOnInit() {
    this.obtenerEmpleados();
  }

  obtenerEmpleados() {
    this.empleadoService.getEmpleados().subscribe({
      next: (response) => {
        this.empleados = response;
        this.empleadosFiltrados = response; // Inicialmente muestra todos los empleados
      },
      error: (error) => console.error('Error al obtener empleados:', error)
    });
  }

  filtrarEmpleados() {
    if (!this.fechaDesde || !this.fechaHasta) {
      alert('Por favor selecciona ambas fechas.');
      return;
    }
    this.empleadosFiltrados = this.empleados.filter(empleado => {
      const fechaIngreso = new Date(empleado.fechaIngreso).getTime();
      const desde = new Date(this.fechaDesde).getTime();
      const hasta = new Date(this.fechaHasta).getTime();
      return fechaIngreso >= desde && fechaIngreso <= hasta;
    });
  }

  generarReporte() {
    const doc = new jsPDF();
  
    // Agregar título
    doc.setFontSize(18);
    doc.text('Reporte de Empleados', 10, 10);
  
    // Agregar subtítulo
    doc.setFontSize(12);
    doc.text(`Desde: ${this.fechaDesde} Hasta: ${this.fechaHasta}`, 10, 20);
  
    // Configurar tabla
    let y = 30;
    doc.setFontSize(10);
    doc.text('Nombre', 10, y);
    doc.text('Salario Mensual', 80, y);  // Cambié 'Correo' a 'Salario Mensual'
    doc.text('Fecha de Ingreso', 150, y);
  
    // Rellenar la tabla con los empleados filtrados
    y += 10;
    this.empleadosFiltrados.forEach(empleado => {
      doc.text(empleado.nombre, 10, y);
      doc.text(empleado.salarioMensual.toString(), 80, y);  // Convertir salario a cadena
      doc.text(new Date(empleado.fechaIngreso).toLocaleDateString(), 150, y);
      y += 10;
    });
  
    // Descargar el PDF
    doc.save('reporte-empleados.pdf');
  }
  
}
