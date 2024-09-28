import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Candidato } from '../../models/class/Candidatos';
import { Router, RouterLink } from '@angular/router';
import { CandidatoService } from '../../services/candidato.service';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-candidatos',
  standalone: true,
  imports: [FormsModule,CommonModule, RouterLink],
  templateUrl: './candidatos.component.html',
  styleUrl: './candidatos.component.css'
})
export class CandidatosComponent implements OnInit{

  constructor(private router: Router) { }

  candidatoObj: Candidato = new Candidato();
  candidatoList: Candidato[] = [];
  
  candidatoService = inject(CandidatoService);

  // Getandidatos(form: NgForm) {
  //   this.candidatoService.getCandidatos(this.candidatoObj).subscribe({
  //     next: (res: any) => {
  //       console.log(res)
  //       this.candidatoList = res; // Adjust based on actual structure
  //     },
  //     error: (err) => {
  //       console.error('Error fetching capacitaciones:', err);
  //     }
  // }

  // }
  verCandidato(id: number) {
    this.router.navigate(['/empleadosdetalles', id]); // Navega a la ruta /candidato/:id
  }

  eliminarCandidato(id: number) {
    // Lógica para eliminar el candidato
    if (confirm('¿Estás seguro de que quieres eliminar este candidato?')) {
      this.candidatoService.deleteCandidato(id).subscribe({
        next: () => {
          this.candidatoList = this.candidatoList.filter(c => c.id !== id); // Actualiza la lista localmente
          console.log('Candidato eliminado');
        },
        error: (err) => {
          console.error('Error eliminando candidato:', err);
        }
      });
    }
  }
  getAllCandidatos(){
    this.candidatoService.getCandidatos().subscribe({
      next: (res: any) => {
        console.log(res)
        this.candidatoList = res; // Adjust based on actual structure
      },
      error: (err) => {
        console.error('Error fetching capacitaciones:', err);
      }
      
    });
  }
  ngOnInit(): void {
    this.getAllCandidatos();
   
  }
}
