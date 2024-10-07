import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Candidato } from '../../models/class/Candidatos';
import { CandidatoService } from '../../services/candidato.service';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { IdiomaService } from '../../services/idioma.service';  // Servicio para obtener los idiomas
import { CompetenciaService } from '../../services/competencia.service'; // Servicio para competencias
import { CapacitacionService } from '../../services/capacitacion.service';
import { PuestosService } from '../../services/puestos.service';
import { ExperienciaLaboralService } from '../../services/experiencia-laboral.service';  // Servicio para obtener los idiomas
import { Idiomas } from '../../models/class/Idiomas';
import { Competencias } from '../../models/class/Competencias';
import { Capacitaciones } from '../../models/class/Capacitaciones';
import { ExperienciaLaboral } from '../../models/class/ExperienciaLaboral';
import { Puestos } from '../../models/class/Puestos';

@Component({
  selector: 'app-candidatoscrear',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterLink],
  templateUrl: './candidatoscrear.component.html',
  styleUrls: ['./candidatoscrear.component.css'] // Cambiado de styleUrl a styleUrls
})
export class CandidatoscrearComponent implements OnInit {
  candidatoObj: Candidato = new Candidato();
  puestoObj: Puestos = new Puestos();
  idiomasList: Idiomas[] = [];              // Lista de idiomas
  competenciasList: Competencias[] = [];         // Lista de competencias
  capacitacionesList: Capacitaciones[] = [];       // Lista de capacitaciones
  experienciaLaboralList: ExperienciaLaboral[] = [];       // Lista de Experiencia
  candidatosList: Candidato[] = [];
  id: number = 0;

  constructor(
    private idiomaService: IdiomaService,
    private competenciaService: CompetenciaService,
    private capacitacionService: CapacitacionService,
    private experienciaLaboralService: ExperienciaLaboralService,
    private candidatoService: CandidatoService,
    private puestoService: PuestosService,
    private route: ActivatedRoute, 
    private router: Router
    
  ) {}

  ngOnInit(): void {
    this.getIdiomas();
    this.getCompetencias();
    this.getCapacitaciones();
    this.getExperienciaLaboral();

    this.id = this.route.snapshot.params['id'];
    if (this.id) {
      this.puestoService.getPuestoById(this.id).subscribe((res: Puestos) => {
        this.puestoObj = res;
      });
    }
  }

  
  getIdiomas(): void {
    this.idiomaService.getIdioma().subscribe({
      next: (res: Idiomas[]) => {
        this.idiomasList = res;
      },
      error: (err) => {
        console.error('Error al obtener idiomas:', err);
      }
    });
  }
  getExperienciaLaboral(): void {
    this.experienciaLaboralService.getExperienciaLaboral().subscribe({
      next: (res: ExperienciaLaboral[]) => {
        this.experienciaLaboralList = res;
      },
      error: (err) => {
        console.error('Error al obtener experiencia laboral:', err);
      }
    });
  }
  // Función para obtener las competencias de la base de datos
  getCompetencias(): void {
    this.competenciaService.getCompetencia().subscribe({
      next: (res: Competencias[]) => {
        this.competenciasList = res;
      },
      error: (err) => {
        console.error('Error al obtener competencias:', err);
      }
    });
  }

  // Función para obtener las capacitaciones de la base de datos
  getCapacitaciones(): void {
    this.capacitacionService.getCapacitaciones().subscribe({
      next: (res: Capacitaciones[]) => {
        this.capacitacionesList = res;
      },
      error: (err) => {
        console.error('Error al obtener capacitaciones:', err);
      }
    });
  }


onCreateCandidato(form: NgForm): void {
  const candidatoData = {
    cedula: this.candidatoObj.cedula,
    nombre: this.candidatoObj.nombre,
    puestoAspira: this.candidatoObj.puestoAspira,
    departamento: this.candidatoObj.departamento,
    salarioAspira: this.candidatoObj.salarioAspira,
    principalesCompetencias: this.candidatoObj.principalesCompetencias,
    principalesCapacitaciones: this.candidatoObj.principalesCapacitaciones,
    recomendadoPor: this.candidatoObj.recomendadoPor,
    experienciaLaboralDto: this.candidatoObj.experienciaLaboral 
  };

  // Llama a la función para crear el candidato
  this.candidatoService.createCandidato(candidatoData).subscribe({
    next: (response) => {
      console.log('Candidato creado:', response);
      form.resetForm(); // Reinicia el formulario tras la creación exitosa
      this.candidatoObj = new Candidato(); // Reinicia el objeto candidato
    },
    error: (err) => {
      console.error('Error al crear el candidato:', err);
    }
  });
}

}