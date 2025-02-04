import { Dominio, Persona } from './Persona';

export class Studente extends Persona {

     specializzazione= Dominio.Studente;

    override getDati(): string { 
        return (`Identificativo: ${this.id} 
            \n ${this.specializzazione}: ${this.nome} ${this.cognome} 
            \n Età: ${this.CalcolaEta()} 
            \n Email: ${this.email}`);
        }
}