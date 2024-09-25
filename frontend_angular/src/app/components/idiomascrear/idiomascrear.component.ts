import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute, RouterLink } from '@angular/router';
import { Idiomas } from '../../models/class/Idiomas';
import { IdiomaService } from '../../services/idioma.service';
import { NgForm } from '@angular/forms';



@Component({
  selector: 'app-idiomascrear',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './idiomascrear.component.html',
  styleUrl: './idiomascrear.component.css'
})
export class IdiomascrearComponent implements OnInit{

  idiomaObj: Idiomas = new Idiomas();
  idiomaList: Idiomas[] = [];
  
  idiomaService = inject(IdiomaService);

  onEstadoChange(value: any) {
    this.idiomaObj.estado = value === 'true';  // Asegura que el valor sea booleano
  }

  onCreateIdioma(form: NgForm) {
    this.idiomaService.createIdioma(this.idiomaObj).subscribe({
      next: (res: any) => {
        console.log('Capacitación creada:', res);
        this.idiomaList.push(res); // Añade la nueva capacitación a la lista
        form.resetForm(); // Resetea los campos del formulario
        this.idiomaObj = new Idiomas();
      },
      error: (err) => {
        console.error('Error al crear la capacitación:', err);
      }
    });
  }

  
  ngOnInit(): void {
    // Inicialización si es necesario
   
  }
}