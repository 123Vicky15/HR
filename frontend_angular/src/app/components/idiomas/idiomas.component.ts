import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Idiomas } from '../../models/class/Idiomas';
import { Router, RouterLink } from '@angular/router';
import { IdiomascrearComponent } from '../idiomascrear/idiomascrear.component';

@Component({
  selector: 'app-idiomas',
  standalone: true,
  imports: [FormsModule,CommonModule, RouterLink,IdiomascrearComponent],
  templateUrl: './idiomas.component.html',
  styleUrl: './idiomas.component.css'
})
export class IdiomasComponent implements OnInit {

  constructor(private router: Router) { }

  idiomasList: Idiomas [] = [];
  http = inject(HttpClient);

  ngOnInit(): void {
    this.getAllIdiomas();
  }

  getAllIdiomas(){
    this.http.get("https://localhost:7021/api/Idioma").subscribe({
      next: (res: any) => {
        console.log(res)
        this.idiomasList = res; // Adjust based on actual structure
      },
      error: (err) => {
        console.error('Error fetching capacitaciones:', err);
      }
      
    });
  }
  
  goToEditForm(id: number) {
    this.router.navigate(['/idiomaseditar', id])
  }

  // Método para eliminar una capacitación
  deleteIdiomas(id: number) {
    const confirmDelete = window.confirm('¿Estás seguro de que deseas eliminar este Idioma?');
    if (confirmDelete) {
      this.http.delete(`https://localhost:7021/api/Idioma/${id}`).subscribe({
        next: () => {
          // Filtra la capacitación eliminada de la lista
          this.idiomasList = this.idiomasList.filter(item => item.id !== id);
          console.log(`Idioma con ID ${id} eliminado`);
        },
        error: (err) => {
          console.error('Error deleting Idioma:', err);
        }
      });
    }
}
}
