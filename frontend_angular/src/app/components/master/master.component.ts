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
  selector: 'app-master',
  standalone: true,
  imports: [CandidatosComponent, PuestosComponent, EmpleadosComponent, CapacitacionesComponent, IdiomasComponent, CompetenciasComponent, CommonModule, RouterModule],
  templateUrl: './master.component.html',
  styleUrl: './master.component.css'
})
export class MasterComponent {
 currentComponent: string = "Empleados";

 changeTap(tabName: string){
  this.currentComponent = tabName;
 }
}
