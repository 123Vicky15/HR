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

  constructor(private puestosService: PuestosService) {}

  ngOnInit(): void {
    this.getPuestos();
  }

  getPuestos() {
    this.puestosService.getPuestos().subscribe((puestos) => {
      this.puestosList = puestos;
    });
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
      // Lógica para solicitar el puesto
      console.log(`Puesto seleccionado: ${this.selectedPuestoId}`);
      // Aquí puedes agregar la lógica para enviar la solicitud del puesto al servidor
    } else {
      alert('Debes seleccionar un puesto.');
    }
  }
}
