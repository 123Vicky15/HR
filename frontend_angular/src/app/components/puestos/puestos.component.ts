import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Puestos } from '../../models/class/Puestos'; 
import { PuestosService } from '../../services/puestos.service'; 
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';


@Component({
  selector: 'app-puestos',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterLink],
  templateUrl: './puestos.component.html',
  styleUrl: './puestos.component.css'
})
export class PuestosComponent implements OnInit {
 
  puestosList: Puestos[] = [];
  selectedPuestoId: number | null = null;
  filtroRiesgo: string = '';
  puestosFiltrados: Puestos[] = [];
  constructor(private puestosService: PuestosService, private router: Router) {}

  ngOnInit(): void {
    this.getPuestos();
  }

  getPuestos(): void {
    this.puestosService.getPuestos().subscribe({
      next: (res: Puestos[]) => {
        this.puestosList = res.filter(puesto => puesto.estado === true);
        this.puestosFiltrados = this.puestosList;  
      },
      error: (err) => {
        console.error('Error al obtener los puestos:', err);
      }
    });
  }
  
  

  filtrarPuestosPorRiesgo(): void {
    if (this.filtroRiesgo === '') {
      this.puestosFiltrados = this.puestosList;
    } else {
      this.puestosFiltrados = this.puestosList.filter(puesto => puesto.nivelRiesgo === this.filtroRiesgo);
    }
  }
  
  
  selectPuesto(puestoId: number) {
    if (this.selectedPuestoId === puestoId) {
      this.selectedPuestoId = null; // Deseleccionar si ya está seleccionado
    } else {
      this.selectedPuestoId = puestoId;
    }
  }

  solicitarPuesto() {
    if (this.selectedPuestoId !== null) {
      console.log(`Puesto seleccionado: ${this.selectedPuestoId}`);
      this.router.navigate(['/candidatoscrear', this.selectedPuestoId]);
    } else {
      alert('Debes seleccionar un puesto.');
    }
  }
}
