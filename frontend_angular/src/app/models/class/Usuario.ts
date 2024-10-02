export class Usuario {
    id: number;
    nombre: string;
    contraseña: string;
    rol: string;  // "Empleado" o "Candidato"

    constructor(id: number, nombre: string, contraseña: string, rol: string) {
        this.id = id;
        this.nombre = nombre;
        this.contraseña = contraseña;
        this.rol = rol;
    }
}
