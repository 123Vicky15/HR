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
  candidato: any; // Los datos del candidato
  empleadoDto: any = {}; // El DTO para el empleado

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
      this.obtenerCandidato(this.candidatoId);
    });
  }

  obtenerCandidato(id: number) {
    this.candidatoService.getCandiatoById(id).subscribe({
      next: (response) => {
        this.candidato = response;
        this.llenarDatosCandidato();
      },
      error: (error) => console.error('Error al obtener candidato:', error)
    });
  }

  llenarDatosCandidato() {
    // Solo copiar los datos que comparten entre candidato y empleado
    this.empleadoDto.nombre = this.candidato.nombre;
    this.empleadoDto.cedula = this.candidato.cedula;
    //this.empleadoDto.puesto = this.puestosService.
    // Los demás campos quedan vacíos para ser llenados manualmente
  }

  convertirAEmpleado() {
    if (this.validarFormulario()) {
      this.empleadoService.convertirCandidatoAEmpleado(this.candidatoId, this.empleadoDto).subscribe({
        next: (response) => {
          alert('Candidato convertido en empleado con éxito');
          this.router.navigate(['/empleados']); // Redirigir a la lista de empleados
        },
        error: (error) => console.error('Error al convertir candidato:', error)
      });
    }
  }

  validarFormulario(): boolean {
    return this.empleadoDto.departamento && this.empleadoDto.puesto && this.empleadoDto.salarioMensual && this.empleadoDto.estado;
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
