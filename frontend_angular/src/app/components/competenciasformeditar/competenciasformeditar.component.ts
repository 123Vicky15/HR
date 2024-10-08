import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CompetenciaService } from '../../services/competencia.service';
import { Competencias } from '../../models/class/Competencias';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-competenciasformeditar',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './competenciasformeditar.component.html',
  styleUrl: './competenciasformeditar.component.css'
})
export class CompetenciasformeditarComponent implements OnInit {

  competenciasObj: Competencias = new Competencias();
  competenciasService = inject(CompetenciaService);
  id: number = 0;

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    if (this.id) {
      // Assuming you're fetching the data by ID, format the dates when loading the object
      this.competenciasService.getCompetenciaById(this.id).subscribe((res: Competencias) => {
        this.competenciasObj = res;
      });
    }
  }

  onEstadoChange(value: boolean) {
    this.competenciasObj.estado = value;  // Asignar el valor booleano directamente
    console.log("Estado cambiado a:", this.competenciasObj.estado);  // Imprimir para verificar
  }
  onUpdateCompetencia(form: any): void {
    if (form.valid) {
      this.competenciasService.updateCompetencia(this.id, this.competenciasObj).subscribe(
        res => {
          console.log('Competencia actualizada exitosamente');
          this.router.navigate(['/competencias']);
        },
        error => {
          console.error('Error al actualizar la competencia', error);
        }
      );
    }
  }
}