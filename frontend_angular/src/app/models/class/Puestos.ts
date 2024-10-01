export class Puestos{
id:number;
nombre:string;
nivelRiesgo:string;
nivelMinimoSalario:number;
nivelMaximoSalario:number;
estado:boolean

constructor(){
    this.id = 0;
    this.nombre = '';
    this.nivelRiesgo = '';
    this.nivelMaximoSalario = 0;
    this.nivelMinimoSalario = 0;
    this.estado = true
}
}
