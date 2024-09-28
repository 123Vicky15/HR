export class Puestos{
id:number;
nombre:string;
nivelRiegos:string;
nivelMinimoSalario:number;
nivelMaximoSalario:number;
estado:boolean

constructor(){
    this.id = 0;
    this.nombre = '';
    this.nivelRiegos = '';
    this.nivelMaximoSalario = 0;
    this.nivelMinimoSalario = 0;
    this.estado = true
}
}
