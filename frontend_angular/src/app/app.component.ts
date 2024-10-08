import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { MasterComponent } from './components/master/master.component';
import { CandidatosComponent } from "./components/candidatos/candidatos.component";
import { PuestosComponent } from './components/puestos/puestos.component';
import { EmpleadosComponent } from './components/empleados/empleados.component';
import { CapacitacionesComponent } from './components/capacitacioness/capacitaciones.component';
import { IdiomasComponent } from './components/idiomas/idiomas.component';
import { CompetenciasComponent } from './components/competencias/competencias.component';
import { MastercandidatosComponent } from "./components/mastercandidatos/mastercandidatos.component";
import { LoginComponent } from "./components/login/login.component";
import { EsperaComponent } from "./components/espera/espera.component";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,EsperaComponent, MasterComponent, CandidatosComponent, PuestosComponent, EmpleadosComponent, CapacitacionesComponent, IdiomasComponent, CompetenciasComponent, RouterLink, MastercandidatosComponent, LoginComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend_angular';
}
