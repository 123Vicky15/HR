import { Routes } from '@angular/router';
import { CandidatosComponent } from './components/candidatos/candidatos.component';
import { EmpleadosComponent } from './components/empleados/empleados.component';
import { CompetenciasComponent } from './components/competencias/competencias.component';
import { CapacitacionesComponent } from './components/capacitacioness/capacitaciones.component';
import { CapacitacionesformComponent } from './components/capacitacionesform/capacitacionesform.component';
import { CapacitacionesformcrearComponent } from './components/capacitacionesformcrear/capacitacionesformcrear.component';
import { CompetenciasformcrearComponent } from './components/competenciasformcrear/competenciasformcrear.component';
import { CompetenciasformeditarComponent } from './components/competenciasformeditar/competenciasformeditar.component';
import { IdiomaseditarComponent } from './components/idiomaseditar/idiomaseditar.component';
import { IdiomasComponent } from './components/idiomas/idiomas.component';
import { IdiomascrearComponent } from './components/idiomascrear/idiomascrear.component';
import { ExperienciaLaboralCrearComponent } from './components/experiencia-laboralcrear/experiencia-laboralcrear.component';
import { CandidatoscrearComponent } from './components/candidatoscrear/candidatoscrear.component';
import { PuestosComponent } from './components/puestos/puestos.component';
import { PuestoeditarComponent } from './components/puestoeditar/puestoeditar.component';
import { PuestosCrearComponent } from './components/puestoscrear/puestoscrear.component';
import { PuestosverComponent } from './components/puestosver/puestosver.component';
import { EmpleadosdetallesComponent } from './components/empleadosdetalles/empleadosdetalles.component';
import { MastercandidatosComponent } from './components/mastercandidatos/mastercandidatos.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { LoginComponent } from './components/login/login.component';
import { MasterComponent } from './components/master/master.component';




export const routes: Routes = [
  {
    path: '',
    component: MasterComponent,
    children: [
      {
        path: 'candidatoscrear',
        component: CandidatoscrearComponent,
     //   canActivate: [AuthGuard],
      //  data: { roles: ['User'] }
      },
    ]
 //   canActivate: [AuthGuard],
  //  data: { roles: ['User'] }
  },
  {
    path: 'register',
    component: RegistrationComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['User'] }
  },
  {
    path: 'login',
    component: LoginComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['User'] }
  },
  {
    path: 'mastercandidatos',
    component: MastercandidatosComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['User'] }
  },
  {
    path: 'experiencia-laboralcrear',
    component: ExperienciaLaboralCrearComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['User'] }
  },

  // Rutas accesibles solo por empleados de HR
// {
 //   path: 'hr-dashboard',
 //   component: HrDashboardComponent,
   // canActivate: [AuthGuard],
//data: { roles: ['HR'] }
  //},
  {
    path: 'idiomaseditar',
    component: IdiomaseditarComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },  
  {
    path: 'idiomascrear',
    component: IdiomascrearComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  { 
    path: 'idiomaseditar/:id', 
    component: IdiomaseditarComponent, 
      //  data: { roles: ['HR'] }

  },
  { 
    path: 'puestoseditarcomponent/:id', 
    component: PuestoeditarComponent, 
      //  data: { roles: ['HR'] }

  },
  { 
    path: 'competenciasformeditar/:id', 
    component: CompetenciasformeditarComponent,
      //  data: { roles: ['HR'] }

  },
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
  //  data: { roles: ['User'] }
  },
  {
    path: 'capacitacionesform/:id',
    component: CapacitacionesformComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  {
    path: 'candidatos/:id',
    component: CandidatosComponent,
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
    path: 'empleadosdetalles/:id',
    component: EmpleadosdetallesComponent,
 //   canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
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
  //  data: { roles: ['User'] }
  },
  {
    path: 'puestos',
    component: PuestosComponent,
  //  canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  {
    path: 'puestosvercomponent',
    component: PuestosverComponent,
  //  canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  {
    path: 'puestoseditarcomponent',
    component: PuestoeditarComponent,
  //  canActivate: [AuthGuard],
  //  data: { roles: ['HR'] }
  },
  {
    path: 'puestoscrearcomponent',
    component: PuestosCrearComponent,
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
