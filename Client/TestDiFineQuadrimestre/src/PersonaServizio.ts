import { Persona } from './Persona';
export class PersonaServizio {
    
    async CreaPersona(persona: Persona) {
        const risposta = await fetch(`http://localhost:7272/api/persone`, {
            method: `POST`,
            body: JSON.stringify(persona)
        });
        if (!risposta.ok) {
            throw new Error(`Errore durante la creazione della persona: ${risposta.statusText}`);
        }
    }

    async GetPersone() {
        const risposta = await fetch(`http://localhost:7272/api/persone`);
        if (!risposta.ok) {
            throw new Error(`Errore durante la ricerca delle persone: ${risposta.statusText}`);
        }
        return await risposta.json();     
    }

    async GetPersonaById(id: number) {
        const risposta = await fetch(`http://localhost:7272/api/persone/${id}`);
        if (!risposta.ok) {
            throw new Error(`Errore durante la ricerca della persona: ${risposta.statusText}`);
        }
        return await risposta.json();
    }

    
    async ModificaPersona(persona: Persona) {
        const risposta = await fetch(`http://localhost:7272/api/persone/${persona.id}`, {
            method: `PUT`,
            body: JSON.stringify(persona)
        });
        if (!risposta.ok) {
            throw new Error(`Errore durante la modifica della persona: ${risposta.statusText}`);
        }
    }

    
    async EliminaPersona(id: number) {
        const risposta = await fetch(`http://localhost:7272/api/persone/${id}`, {
            method: `DELETE`
        });
        if (!risposta.ok) {
            throw new Error(`Errore durante la eliminazione della persona: ${risposta.statusText}`);
        }
    }

    
    



}

