
import { PersonaServizio } from "./PersonaServizio";
import { Studente } from "./Studente";

const studente1 = new Studente(1,"Michele", "Sette", new Date(2001/12/5));

const personeServizio = new PersonaServizio();

personeServizio.CreaPersona(studente1);

personeServizio.GetPersone();