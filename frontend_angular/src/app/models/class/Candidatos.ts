export class Candidato {
    id: number;
    cedula: string;
    // correo: string;
    // urlFotoPerfil: string;
    nombre: string;
    puestoAspira: string;
    departamento: string;
    salarioAspira: number; 
    principalesCompetencias: string; 
    principalesCapacitaciones: string; 
    //experienciaLaboral: ExperienciaLaboral[]; 
    recomendadoPor: string;

    constructor() {
        this.id = 0;
        this.cedula = '';
        // this.correo = '';
        // this.urlFotoPerfil = '';
        this.nombre = '';
        this.puestoAspira = '';
        this.departamento = '';
        this.salarioAspira = 0;
        this.principalesCompetencias = '';
        this.principalesCapacitaciones = '';
        //this.experienciaLaboral = experienciaLaboral; // Si no se pasa como parámetro, será un array vacío
        this.recomendadoPor = '';
    }
}
