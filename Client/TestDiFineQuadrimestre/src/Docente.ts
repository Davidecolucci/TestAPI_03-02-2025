import { Dominio, Persona } from './Persona';

export class Docente extends Persona {

     specializzazione= Dominio.Docente;

     override getDati(): string { 
        return (`Identificativo: ${this.id} 
            \n ${this.specializzazione}: ${this.nome} ${this.cognome} 
            \n Età: ${this.CalcolaEta()} 
            \n Email: ${this.email}`);
        }
    
}