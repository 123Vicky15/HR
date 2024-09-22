import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-competencias',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './competencias.component.html',
  styleUrl: './competencias.component.css'
})
export class CompetenciasComponent implements OnInit {
  roleList: any [] = [];
  http = inject(HttpClient);
  ngOnInit(): void {
    
  }
  getAllCompetencias(){
    this.http.get("")
  }
}
