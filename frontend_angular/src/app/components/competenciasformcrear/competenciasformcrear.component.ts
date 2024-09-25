import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Competencias } from '../../models/class/Competencias';
import { CompetenciaService } from '../../services/competencia.service';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-competenciasformcrear',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './competenciasformcrear.component.html',
  styleUrl: './competenciasformcrear.component.css'
})
export class CompetenciasformcrearComponent implements OnInit{
  competenciasObj: Competencias = new Competencias();
  competenciasList: Competencias[] = [];
  
  competenciasService = inject(CompetenciaService);

  onEstadoChange(value: any) {
    this.competenciasObj.estado = value === 'true';  // Asegura que el valor sea booleano
  }

  onCreateCompetencia(form: NgForm) {
    this.competenciasService.createCompetencia(this.competenciasObj).subscribe({
      next: (res: any) => {
        console.log('Capacitación creada:', res);
        this.competenciasList.push(res); // Añade la nueva capacitación a la lista
        form.resetForm(); // Resetea los campos del formulario
        this.competenciasObj = new Competencias();
      },
      error: (err) => {
        console.error('Error al crear la capacitación:', err);
      }
    });
  }

  
  ngOnInit(): void {
    // Inicialización si es necesario
   
  }
}