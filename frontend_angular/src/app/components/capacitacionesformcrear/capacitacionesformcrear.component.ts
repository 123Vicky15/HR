import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ICapacitaciones } from '../../models/interface/Capacitaciones';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute, RouterLink } from '@angular/router';
import { Capacitaciones } from '../../models/class/Capacitaciones';
import { CapacitacionService } from '../../services/capacitacion.service';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-capacitacionesformcrear',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './capacitacionesformcrear.component.html',
  styleUrl: './capacitacionesformcrear.component.css'
})
export class CapacitacionesformcrearComponent implements OnInit{
  capacitacionesObj: Capacitaciones = new Capacitaciones();
  capacitacionesList: Capacitaciones[] = [];
  
  capacitacionesService = inject(CapacitacionService);

  onCreateCapacitacion(form: NgForm) {
    this.capacitacionesService.createCapacitacion(this.capacitacionesObj).subscribe({
      next: (res: any) => {
        console.log('Capacitación creada:', res);
        this.capacitacionesList.push(res); // Añade la nueva capacitación a la lista
        form.resetForm(); // Resetea los campos del formulario
        this.capacitacionesObj = new Capacitaciones();
      },
      error: (err) => {
        console.error('Error al crear la capacitación:', err);
      }
    });
  }

  
  ngOnInit(): void {
    // Inicialización si es necesario
   
  }
}
