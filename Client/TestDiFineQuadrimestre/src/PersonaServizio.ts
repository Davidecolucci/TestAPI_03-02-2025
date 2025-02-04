import { Persona } from './Persona';
class PersonaServizio {
    async CreaPersona(persona: Persona) {
        const risposta = await fetch(`http://localhost:7272/api/persone`, {
            method: `POST`,
            body: JSON.stringify(persona)
        });
        if (!risposta.ok) {
            throw new Error(`Errore durante la creazione della persona: ${risposta.statusText}`);
        }
    }

}

