import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { IdiomaService } from '../../services/idioma.service';
import { Idiomas } from '../../models/class/Idiomas';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-idiomaseditar',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './idiomaseditar.component.html',
  styleUrl: './idiomaseditar.component.css'
})
export class IdiomaseditarComponent implements OnInit {

  idiomasObj: Idiomas = new Idiomas();
  idiomaService = inject(IdiomaService);
  id: number = 0;

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    if (this.id) {
      // Suponiendo que estás obteniendo los datos por ID, formatea las fechas al cargar el objeto
      this.idiomaService.getIdiomaById(this.id).subscribe((res: Idiomas) => {
        this.idiomasObj = res;
      });
    }
  }
  
  onEstadoChange(value: any) {
    this.idiomasObj.estado = value === 'true';  // Asegura que el valor sea booleano
  }
  
  onUpdateIdioma(form: any): void {
    if (form.valid) {
      this.idiomaService.updateIdioma(this.id, this.idiomasObj).subscribe(
        res => {
          console.log('Idioma actualizado exitosamente');
          this.router.navigate(['/idiomas']);
        },
        error => {
          console.error('Error al actualizar el Idioma', error);
        }
      );
    }
  }
}
