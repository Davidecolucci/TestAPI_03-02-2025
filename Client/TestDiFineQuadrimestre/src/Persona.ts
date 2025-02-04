export enum Dominio {
    Studente = "studente",
    Docente = "docente"
}

export abstract class Persona{
    public abstract specializzazione : Dominio;

    constructor( public id : number, public nome : string, public cognome : string, public dataDiNascita : Date){}
    
    get email() {
        return (`${this.nome.charAt(0).toLowerCase()}${this.cognome.toLowerCase()}@${Dominio}.com`);
    }

    CalcolaEta() {
        const today = new Date();
        const diffTime = Math.abs(today.getTime() - this.dataDiNascita.getTime());
        const age = Math.floor(diffTime / (1000 * 60 * 60 * 24 * 365.25));
        return `L'età è: ${age}`;
    }

    getDati() {
        return (`Identificativo: ${this.id} 
            \n Nominativo: ${this.nome} ${this.cognome} 
            \n Età: ${this.CalcolaEta()} 
            \n Email: ${this.email} 
            \n specializzazione: ${Dominio}`);
    }
        
    
}