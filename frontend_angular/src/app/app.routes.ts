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
import { EsperaComponent } from './components/espera/espera.component';




export const routes: Routes = [
  {
    path: 'espera',
    component: EsperaComponent,
  },
  {
    path: 'register',
    component: RegistrationComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    component: MasterComponent,
    children: [
      {
        path: 'candidatoscrear',
        component: CandidatoscrearComponent,
      },
      { path: 'candidatoscrear/:id', 
        component: CandidatoscrearComponent 
      },
      {
        path: 'mastercandidatos',
        component: MastercandidatosComponent,
      },
      {
        path: 'experiencia-laboralcrear',
        component: ExperienciaLaboralCrearComponent,
      },
      {
        path: 'idiomaseditar',
        component: IdiomaseditarComponent,
      },  
      {
        path: 'idiomascrear',
        component: IdiomascrearComponent,
      },
      { 
        path: 'idiomaseditar/:id', 
        component: IdiomaseditarComponent, 
      },
      { 
        path: 'puestoseditarcomponent/:id', 
        component: PuestoeditarComponent, 
      },
      { 
        path: 'competenciasformeditar/:id', 
        component: CompetenciasformeditarComponent,
      },
      {
        path: 'competenciasformcrear',
        component: CompetenciasformcrearComponent,
      },
      {
        path: 'competenciasformeditar',
        component: CompetenciasformeditarComponent,
      },
      {
        path: 'capacitacionesformcrear',
        component: CapacitacionesformcrearComponent,
      },
      {
        path: 'capacitacionesform/:id',
        component: CapacitacionesformComponent,
      },
      {
        path: 'candidatos/:id',
        component: CandidatosComponent,
      },
      {
        path: 'candidatos',
        component: CandidatosComponent,
      },
      {
        path: 'empleados',
        component: EmpleadosComponent,
      },
      {
        path: 'empleadosdetalles/:id',
        component: EmpleadosdetallesComponent,
      },
      {
        path: 'competencias',
        component: CompetenciasComponent,
      },
      {
        path: 'idiomas',
        component: IdiomasComponent,
      },
      {
        path: 'capacitaciones',
        component: CapacitacionesComponent,
      },
      {
        path: 'puestos',
        component: PuestosComponent,
      },
      {
        path: 'puestosvercomponent',
        component: PuestosverComponent,
      },
      {
        path: 'puestoseditarcomponent',
        component: PuestoeditarComponent,
      },
      {
        path: 'puestoscrearcomponent',
        component: PuestosCrearComponent,
      }
    ]
  },
  {
    path: '**',
    redirectTo: 'login',
    pathMatch: 'full'
  }
];

