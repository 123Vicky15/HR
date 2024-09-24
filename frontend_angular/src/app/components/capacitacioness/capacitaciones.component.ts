import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ICapacitaciones } from '../../models/interface/Capacitaciones';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { CapacitacionesformcrearComponent } from '../capacitacionesformcrear/capacitacionesformcrear.component';


@Component({
  selector: 'app-capacitaciones',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterLink, CapacitacionesformcrearComponent],
  templateUrl: './capacitaciones.component.html',
  styleUrl: './capacitaciones.component.css'
})
export class CapacitacionesComponent implements OnInit {

  constructor(private router: Router) { }

  capacitacionesList: ICapacitaciones [] = [];
  http = inject(HttpClient);

  ngOnInit(): void {
    this.getAllCapacitaciones();
  }

  getAllCapacitaciones(){
    this.http.get("https://localhost:7021/api/Capacitacion").subscribe({
      next: (res: any) => {
        console.log(res)
        this.capacitacionesList = res; // Adjust based on actual structure
      },
      error: (err) => {
        console.error('Error fetching capacitaciones:', err);
      }
      
    });
  }
  
  goToEditForm(id: number) {
    this.router.navigate(['/capacitacionesform/', id])
  }

  // Método para eliminar una capacitación
  deleteCapacitacion(id: number) {
    const confirmDelete = window.confirm('¿Estás seguro de que deseas eliminar esta capacitación?');
    if (confirmDelete) {
      this.http.delete(`https://localhost:7021/api/Capacitacion/${id}`).subscribe({
        next: () => {
          // Filtra la capacitación eliminada de la lista
          this.capacitacionesList = this.capacitacionesList.filter(item => item.id !== id);
          console.log(`Capacitación con ID ${id} eliminada`);
        },
        error: (err) => {
          console.error('Error deleting capacitacion:', err);
        }
      });
    }
}
}