import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ICapacitaciones } from '../../models/interface/Capacitaciones';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-capacitaciones',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './capacitaciones.component.html',
  styleUrl: './capacitaciones.component.css'
})
export class CapacitacionesComponent implements OnInit {
  capacitacionesList: ICapacitaciones [] = [];
  http = inject(HttpClient);

  ngOnInit(): void {
    this.getAllCapacitaciones();
  }

  getAllCapacitaciones(){
    this.http.get("https://localhost:7021/api/Capacitacion").subscribe({
      next: (res: any) => {
        console.log(res)
        this.capacitacionesList = res; // Adjust based on actual structure
      },
      error: (err) => {
        console.error('Error fetching capacitaciones:', err);
      }
      
    });
  }
  
}
