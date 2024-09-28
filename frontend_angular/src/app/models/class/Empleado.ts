export class Empleado{
id: number;
cedula: string;
nombre: string;
fechaIngreso: string;
departamento: string;
puesto: string;
salarioMensual: number;
estado: boolean;

constructor(){
    this.id = 0,
    this.cedula = '',
    this.nombre = '',
    this.departamento = '',
    this.fechaIngreso = new Date().toISOString().split('T')[0],
    this.puesto = '',
    this.salarioMensual = 0,
    this.estado = true
}
}
