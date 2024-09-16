import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-puestos',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './puestos.component.html',
  styleUrl: './puestos.component.css'
})
export class PuestosComponent {
id: number = 1
nombre: string = 'Fran'
nivelRiesgo: string = 'Alto'
nivelMinimoSalario: number = 61
nivelMaximoSalario: number = 80
estado: boolean = false
}
