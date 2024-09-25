export class ExperienciaLaboral {
    id: number;
    empresa: string;
    puestoOcupado: string;
    fechaDesde: Date;
    fechaHasta: Date;
    salario: number;

    constructor() {
        this.id = 0;
        this.empresa = '';
        this.puestoOcupado = '';
        this.fechaDesde = new Date;
        this.fechaHasta = new Date;
        this.salario = 0;
    }
}