export class ExperienciaLaboral {
    id: number;
    empresa: string;
    puestoOcupado: string;
    fechaDesde: string; // Cambiar a string para manejar fechas como ISO
    fechaHasta: string; // Cambiar a string para manejar fechas como ISO
    salario: number;

    constructor(
        id: number = 0,
        empresa: string = '',
        puestoOcupado: string = '',
        fechaDesde: string = new Date().toISOString().split('T')[0], // Fecha actual en formato ISO
        fechaHasta: string = new Date().toISOString().split('T')[0], // Fecha actual en formato ISO
        salario: number = 0
    ) {
        this.id = id;
        this.empresa = empresa;
        this.puestoOcupado = puestoOcupado;
        this.fechaDesde = fechaDesde;
        this.fechaHasta = fechaHasta;
        this.salario = salario;
    }
}
