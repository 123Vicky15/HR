import { ExperienciaLaboral } from '../class/ExperienciaLaboral';

export class Candidato {
    id: number;
    cedula: string;
    nombre: string;
    puestoAspira: string;
    departamento: string;
    salarioAspira: number; 
    principalesCompetencias: string; 
    principalesCapacitaciones: string; 
    experienciaLaboral: ExperienciaLaboral[];
    recomendadoPor: string;

    constructor(experienciaLaboral: ExperienciaLaboral[]) {
        this.id = 0;
        this.cedula = '';
        this.nombre = '';
        this.puestoAspira = '';
        this.departamento = '';
        this.salarioAspira = 0;
        this.principalesCompetencias = '';
        this.principalesCapacitaciones = '';
        this.experienciaLaboral = experienciaLaboral;
        this.recomendadoPor = '';
    }
}