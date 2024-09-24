export class Capacitaciones{
    id: number;
    descripcion: string;
    nivel: string;  
    fechaDesde: Date;
    fechaHasta: Date;
    institucion: string;


    constructor(){
        this.id = 0;
        this.descripcion = '';
        this.nivel = '';
        this.fechaDesde = new Date;
        this.fechaHasta = new Date;
        this.institucion = '';
    }
}
