import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ExperienciaLaboral } from '../../models/class/ExperienciaLaboral';
import { ExperienciaLaboralService } from '../../services/experiencia-laboral.service';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-experiencia-laboral-crear',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './experiencia-laboralcrear.component.html',
  styleUrls: ['./experiencia-laboralcrear.component.css']
})
export class ExperienciaLaboralCrearComponent implements OnInit {
  experienciaLaboralObj: ExperienciaLaboral = new ExperienciaLaboral();
  experienciaLaboralList: ExperienciaLaboral[] = [];
  
  experienciaLaboralService = inject(ExperienciaLaboralService);
  id: number = 0;

  constructor(private route: ActivatedRoute, private router: Router) {}

  onCreateExperienciaLaboral(form: NgForm) {
    this.experienciaLaboralService.createExperienciaLaboral(this.experienciaLaboralObj).subscribe({
      next: (res: any) => {
        console.log('Experiencia Laboral creada:', res);
        this.experienciaLaboralList.push(res); // Añade la nueva experiencia a la lista
        form.resetForm(); // Resetea los campos del formulario
        this.experienciaLaboralObj = new ExperienciaLaboral();
      },
      error: (err) => {
        console.error('Error al crear la Experiencia Laboral:', err);
      }
    });
  }



  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    if (this.id) {
      // Assuming you're fetching the data by ID, format the dates when loading the object
      this.experienciaLaboralService.getExperienciaLaboralById(this.id).subscribe((res: ExperienciaLaboral) => {
        this.experienciaLaboralObj = res;

        this.experienciaLaboralObj.fechaDesde = new Date(this.experienciaLaboralObj.fechaDesde).toISOString().split('T')[0];
        this.experienciaLaboralObj.fechaHasta = new Date(this.experienciaLaboralObj.fechaHasta).toISOString().split('T')[0];

      });
    }
  }
}
