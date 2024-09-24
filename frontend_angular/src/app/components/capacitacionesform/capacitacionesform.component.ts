import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CapacitacionService } from '../../services/capacitacion.service';
import { Capacitaciones } from '../../models/class/Capacitaciones';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-capacitacionesform',
  templateUrl: './capacitacionesform.component.html',
  standalone: true,
  imports: [FormsModule],
  styleUrls: ['./capacitacionesform.component.css']
})
export class CapacitacionesformComponent implements OnInit {
  capacitacionesObj: any;
  capacitacionesService = inject(CapacitacionService);
  id: number = 0;

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    if (this.id) {
      // Assuming you're fetching the data by ID, format the dates when loading the object
      this.capacitacionesService.getCapacitacionById(this.id).subscribe((res: Capacitaciones) => {
        this.capacitacionesObj = res;

        this.capacitacionesObj.fechaDesde = new Date(this.capacitacionesObj.fechaDesde).toISOString().split('T')[0];
        this.capacitacionesObj.fechaHasta = new Date(this.capacitacionesObj.fechaHasta).toISOString().split('T')[0];

      });
    }
  }

  onUpdateCapacitacion(form: any): void {
    if (form.valid) {
      this.capacitacionesService.updateCapacitacion(this.id, this.capacitacionesObj).subscribe(
        res => {
          console.log('Capacitación actualizada exitosamente');
          this.router.navigate(['/capacitaciones']);
        },
        error => {
          console.error('Error al actualizar capacitación', error);
        }
      );
    }
  }
}
