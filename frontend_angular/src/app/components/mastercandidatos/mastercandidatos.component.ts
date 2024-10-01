import { Component } from '@angular/core';
import { CandidatosComponent } from '../candidatos/candidatos.component';
import { PuestosComponent } from '../puestos/puestos.component';
import { EmpleadosComponent } from '../empleados/empleados.component';
import { CapacitacionesComponent } from '../capacitacioness/capacitaciones.component';
import { IdiomasComponent } from '../idiomas/idiomas.component';
import { CompetenciasComponent } from '../competencias/competencias.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-mastercandidatos',
  standalone: true,
  imports: [CandidatosComponent, PuestosComponent, EmpleadosComponent, CapacitacionesComponent, IdiomasComponent, CompetenciasComponent, CommonModule, RouterModule],
  templateUrl: './mastercandidatos.component.html',
  styleUrl: './mastercandidatos.component.css'
})
export class MastercandidatosComponent {

}
