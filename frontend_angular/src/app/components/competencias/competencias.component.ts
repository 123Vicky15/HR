import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ICompetencias } from '../../models/interface/Competencias';
import { Router, RouterLink } from '@angular/router';
import { CompetenciasformcrearComponent } from '../competenciasformcrear/competenciasformcrear.component';

@Component({
  selector: 'app-competencias',
  standalone: true,
  imports: [FormsModule,CommonModule, RouterLink,CompetenciasformcrearComponent],
  templateUrl: './competencias.component.html',
  styleUrl: './competencias.component.css'
})
export class CompetenciasComponent implements OnInit {

  constructor(private router: Router) { }

  competenciasList: ICompetencias [] = [];
  http = inject(HttpClient);

  ngOnInit(): void {
    this.getAllCompetencias();
  }

  getAllCompetencias(){
    this.http.get("https://localhost:7021/api/Competencia").subscribe({
      next: (res: any) => {
        console.log(res)
        this.competenciasList = res; // Adjust based on actual structure
      },
      error: (err) => {
        console.error('Error fetching capacitaciones:', err);
      }
      
    });
  }
  
  goToEditForm(id: number) {
    this.router.navigate(['/competenciasformeditar', id])
  }

  // Método para eliminar una capacitación
  deleteCompetencias(id: number) {
    const confirmDelete = window.confirm('¿Estás seguro de que deseas eliminar esta Competencia?');
    if (confirmDelete) {
      this.http.delete(`https://localhost:7021/api/Competencia/${id}`).subscribe({
        next: () => {
          // Filtra la capacitación eliminada de la lista
          this.competenciasList = this.competenciasList.filter(item => item.id !== id);
          console.log(`Competencia con ID ${id} eliminada`);
        },
        error: (err) => {
          console.error('Error deleting competencia:', err);
        }
      });
    }
}
}