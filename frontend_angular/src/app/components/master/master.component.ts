import { Component, inject, OnInit } from '@angular/core';
import { CandidatosComponent } from '../candidatos/candidatos.component';
import { PuestosComponent } from '../puestos/puestos.component';
import { EmpleadosComponent } from '../empleados/empleados.component';
import { CapacitacionesComponent } from '../capacitacioness/capacitaciones.component';
import { IdiomasComponent } from '../idiomas/idiomas.component';
import { PuestosCrearComponent } from '../puestoscrear/puestoscrear.component';
import { CompetenciasComponent } from '../competencias/competencias.component';
import { CommonModule } from '@angular/common';
import { RouterModule, Router  } from '@angular/router';
import { AuthguardService } from '../../services/authguard.service';
import { Usuario } from '../../models/class/Usuario';

@Component({
  selector: 'app-master',
  standalone: true,
  imports: [PuestosCrearComponent,CandidatosComponent, PuestosComponent, EmpleadosComponent, CapacitacionesComponent, IdiomasComponent, CompetenciasComponent, CommonModule, RouterModule],
  templateUrl: './master.component.html',
  styleUrl: './master.component.css'
})
export class MasterComponent implements OnInit {
  constructor(private router: Router) {}
  rolUsuario: string = '';

  cerrarSesion() {
    // Redirige al login
    this.router.navigate(['/login']);
  }
 currentComponent: string = "Empleados";
 usuario: Usuario = {} as Usuario;
 private autservice = inject(AuthguardService);
 changeTap(tabName: string){
  this.currentComponent = tabName;
 }

 ngOnInit(): void {
  // Obtener el rol del usuario del localStorage o de algún servicio
  this.rolUsuario = localStorage.getItem('rolUsuario') || ''; 

  // Si no hay rol, redirigir al login
  if (!this.rolUsuario) {
    this.router.navigate(['/login']);
  }
}
}
