import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute, RouterLink } from '@angular/router';
import { Empleado } from '../../models/class/Empleado';
import { EmpleadoService } from '../../services/empleado.service';
import { CandidatoService } from '../../services/candidato.service';
import { PuestosService } from '../../services/puestos.service';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-empleadosdetalles',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './empleadosdetalles.component.html',
  styleUrl: './empleadosdetalles.component.css'
})
export class EmpleadosdetallesComponent implements OnInit {
  candidatoId!: number;
  puestoId!: number;
  candidato: any; // Los datos del candidato
  puesto: any; // Los datos del candidato
  empleadoDto: any = {};
   // El DTO para el empleado

  constructor(
    private route: ActivatedRoute,
    private empleadoService: EmpleadoService,
    private candidatoService: CandidatoService,
    private puestosService: PuestosService,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.candidatoId = +params['id']; // Obtener el ID del candidato desde la URL
      //this.puestoId = +params['id'];
      this.obtenerCandidato(this.candidatoId);
      // this.obtenerTodosLosPuestos();
      //this.obtenerPuesto(this.puestoId);
    });
  }
  onEstadoChange(value: any) {
    this.candidato.estado = value === 'true';  // Asegura que el valor sea booleano
  }

  // obtenerTodosLosPuestos() {
  //   this.puestosService.getPuestos().subscribe({
  //     next: (response) => {
  //       this.puesto = response; // Guardar la lista de puestos
  //     },
  //     error: (error) => console.error('Error al obtener puestos:', error)
  //   });
  // }

  obtenerCandidato(id: number) {
    this.candidatoService.getCandiatoById(id).subscribe({
      next: (response) => {
        console.log('Candidato obtenido:', response);
        this.candidato = response;

      //   const puestoEncontrado = this.puesto.find(p => p.nombre === this.candidato.puestoAspira);
      // if (puestoEncontrado) {
      //   this.puestoId = puestoEncontrado.id; // Asignar el puestoId encontrado
      //   this.llenarDatosCandidato();
      // } else {
      //   console.error('No se encontró un puesto con ese nombre.');
      // }

        //this.candidato.recomendadoPor = this.candidato.puestoAspira;
        this.obtenerPuesto(this.puestoId);
        this.llenarDatosCandidato();
      },
      error: (error) => console.error('Error al obtener candidato:', error)
    });
  }
  obtenerPuesto(id: number) {
    this.puestosService.getPuestoById(id).subscribe({
      next: (response) => {
        this.puesto = response;
        this.llenarDatosCandidato();
      },
      error: (error) => console.error('Error al obtener Puesto:', error)
    });
  }

  llenarDatosCandidato() {
    // Solo copiar los datos que comparten entre candidato y empleado
    this.empleadoDto.nombre = this.candidato.nombre;
    this.empleadoDto.cedula = this.candidato.cedula;
    this.empleadoDto.departamento = this.candidato.departamento;
    this.empleadoDto.puesto = this.candidato.puestoAspira;
    //this.empleadoDto.puesto = this.puestosService.

  }

  convertirAEmpleado() {
    if (this.validarFormulario()) {
      const convertirCandidatoRequest = {
        SalarioMensual: this.empleadoDto.salarioMensual,
        Departamento: this.candidato.departamento,  // Asegúrate de incluir el departamento
        FechaIngreso: this.empleadoDto.fechaIngreso,
        Estado: this.empleadoDto.estado  // Incluye el estado
      };
  
      this.empleadoService.convertirCandidatoAEmpleado(this.candidatoId, convertirCandidatoRequest).subscribe({
        next: (response) => {
          alert('Candidato convertido en empleado con éxito');
          this.router.navigate(['/empleados']); 
        },
        error: (error) => console.error('Error al convertir candidato:', error)
      });
    }
  }

  validarFormulario(): boolean {
    return (
      this.empleadoDto.departamento &&
      this.empleadoDto.salarioMensual > 0 && 
      this.empleadoDto.fechaIngreso &&
      this.empleadoDto.estado !== undefined 
    );
  }

  actualizarCandidatoEstado() {
    if (confirm('¿Estás seguro de convertirlo a Empleado?')) {
      this.candidatoService.deleteCandidato(this.candidatoId).subscribe({
        next: () => {
          alert('Empleado Agregado');
          this.router.navigate(['/empleados']); // Redirigir a la lista de candidatos
        },
        error: (error) => console.error('Error al convertir candidato:', error)
      });
    }
  }

  eliminarCandidato() {
    if (confirm('¿Estás seguro de eliminar este candidato?')) {
      this.candidatoService.deleteCandidato(this.candidatoId).subscribe({
        next: () => {
          alert('Candidato eliminado');
          this.router.navigate(['/candidatos']); // Redirigir a la lista de candidatos
        },
        error: (error) => console.error('Error al eliminar candidato:', error)
      });
    }
  }
}