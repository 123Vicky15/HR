import { IExperienciaLaboral } from './ExperienciaLaboral';

export interface ICandidato {
    id: number;
    cedula: string;
    nombre: string;
    puestoAspira: string;
    departamento: string;
    salarioAspira: number;
    principalesCompetencias: string;
    principalesCapacitaciones: string;
    experienciaLaboral: IExperienciaLaboral[]; 
    recomendadoPor: string;
  }