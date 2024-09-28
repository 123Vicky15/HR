import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Puestos } from '../../models/class/Puestos'; 
import { PuestosService } from '../../services/puestos.service'; 
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { PuestosCrearComponent } from '../puestoscrear/puestoscrear.component';



@Component({
  selector: 'app-puestosver',
  standalone: true,
  imports: [FormsModule,CommonModule, RouterLink,PuestosCrearComponent],
  templateUrl: './puestosver.component.html',
  styleUrl: './puestosver.component.css'
})
export class PuestosverComponent implements OnInit {

  constructor(private router: Router) { }

  puestoObj: Puestos = new Puestos(); // Instancia vacía de Puesto
  puestoList: Puestos[] = []; // Lista de puestos existentes

  puestoService = inject(PuestosService);
  ngOnInit(): void {
    this.getAllPuestos();
  }

  getAllPuestos(){
    this.puestoService.getPuestos().subscribe({
      next: (res: any) => {
        console.log(res)
        this.puestoList = res; // Adjust based on actual structure
      },
      error: (err) => {
        console.error('Error fetching Puestos:', err);
      }
      
    });
  }
  
  goToEditForm(id: number) {
    this.router.navigate(['/puestoeditar', id])
  }

  // Método para eliminar una capacitación
  deletePuestos(id: number) {
    const confirmDelete = window.confirm('¿Estás seguro de que deseas eliminar este Puesto?');
    if (confirmDelete) {
      this.puestoService.deletePuesto(id).subscribe({
        next: () => {
          // Filtra la Puesto eliminada de la lista
          this.puestoList = this.puestoList.filter(item => item.id !== id);
          console.log(`Puesto con ID ${id} eliminado`);
        },
        error: (err) => {
          console.error('Error deleting Puesto:', err);
        }
      });
    }
}
}
