import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PuestosComponent } from './components/puestos/puestos.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, PuestosComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend_angular';
}
