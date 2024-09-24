import { Routes } from '@angular/router';
import { CandidatosComponent } from './components/candidatos/candidatos.component';
import { EmpleadosComponent } from './components/empleados/empleados.component';
import { CompetenciasComponent } from './components/competencias/competencias.component';
import { IdiomasComponent } from './components/idiomas/idiomas.component';
import { CapacitacionesComponent } from './components/capacitacioness/capacitaciones.component';
import { PuestosComponent } from './components/puestos/puestos.component';
import { CapacitacionesformComponent } from './components/capacitacionesform/capacitacionesform.component';
import { CapacitacionesformcrearComponent } from './components/capacitacionesformcrear/capacitacionesformcrear.component';
import { CompetenciasformcrearComponent } from './components/competenciasformcrear/competenciasformcrear.component';
import { CompetenciasformeditarComponent } from './components/competenciasformeditar/competenciasformeditar.component';




export const routes: Routes = [
  // Rutas accesibles solo por empleados de HR
// {
 //   path: 'hr-dashboard',
 //   component: HrDashboardComponent,
   // canActivate: [AuthGuard],
//data: { roles: ['HR'] }
  //},
  { path: 'competenciasformeditar/:id', 
    component: CompetenciasformeditarComponent },
  {
    path: 'competenciasformcrear',
    component: CompetenciasformcrearComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  {
    path: 'competenciasformeditar',
    component: CompetenciasformeditarComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  {
    path: 'capacitacionesformcrear',
    component: CapacitacionesformcrearComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  {
    path: 'capacitacionesform/:id',
    component: CapacitacionesformComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  {
    path: 'candidatos',
    component: CandidatosComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  {
    path: 'empleados',
    component: EmpleadosComponent,
 //   canActivate: [AuthGuard],
 //   data: { roles: ['HR'] }
  },
  {
    path: 'competencias',
    component: CompetenciasComponent,
//    canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  {
    path: 'idiomas',
    component: IdiomasComponent,
 //   canActivate: [AuthGuard],
//    data: { roles: ['HR'] }
  },
  {
    path: 'capacitaciones',
    component: CapacitacionesComponent,
  //  canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  {
    path: 'puestos',
    component: PuestosComponent,
  //  canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  
  // Rutas accesibles solo por candidatos
//  {
  //  path: 'candidato-dashboard',
 //   component: CandidatoDashboardComponent,
 //   canActivate: [AuthGuard],
 //   data: { roles: ['Candidato'] }
 // },
 // {
  //  path: 'puestos-disponibles',
  //  component: PuestosComponent,
 //   canActivate: [AuthGuard],
 //   data: { roles: ['Candidato'] }
 // },

  // Ruta de página de inicio o default (opcional)
 // { path: '', redirectTo: '/login', pathMatch: 'full' },
  // Ruta para manejo de páginas no encontradas
 //// { path: '**', redirectTo: '/login' }
];
