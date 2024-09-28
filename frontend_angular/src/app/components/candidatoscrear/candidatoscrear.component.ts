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
@Component({
  selector: 'app-candidatoscrear',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterLink],
  templateUrl: './candidatoscrear.component.html',
  styleUrls: ['./candidatoscrear.component.css'] // Cambiado de styleUrl a styleUrls
})
export class CandidatoscrearComponent implements OnInit {
  candidatolObj: Candidato = new Candidato();
  candidatosList: Candidato[] = [];
  
  candidatoService = inject(CandidatoService);
  id: number = 0;

  constructor(private route: ActivatedRoute, private router: Router) {}
  onCreateCandidato(form: NgForm) {
    
    this.candidatoService.createCandidato(this.candidatolObj).subscribe({
      next: (res: any) => {
        console.log('Candidato creado:', res);
        this.candidatosList.push(res); // Añade el nuevo candidato a la lista
        form.resetForm(); // Resetea los campos del formulario
        this.candidatolObj = new Candidato(); // Reinicia el objeto candidato
      },
      error: (err) => {
        console.error('Error al crear el candidato:', err);
      }
    });
  }

ngOnInit(): void {
  // Inicialización si es necesario
}
}
