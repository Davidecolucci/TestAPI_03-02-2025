using Microsoft.AspNetCore.Mvc;
using TestDiFineQuadrimestre2.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestDiFineQuadrimestre2.Controllers;

[Route("api/persone")]
[ApiController] 
public class PersonaController : ControllerBase
{

    List<Persona> ListaPersone = new List<Persona>();


    // GET: api/<PersonaController>
    [HttpGet]
    public IEnumerable<Persona> GetPersone()
    {
        return ListaPersone;
    }

    // GET api/<PersonaController>/5
    [HttpGet("{id}")]
    public IActionResult GetPersonaFromId(Guid id)
    {
        var persona = ListaPersone.FirstOrDefault(p => p.Id == id);
        if (persona == null)
        {
            return NotFound("Persona non trovata");
        }

        return Ok(persona);
    }

    // POST api/<PersonaController>
    [HttpPost]
    public bool PostCreaPersona(Persona persona)
    {
        ListaPersone.Add(persona);
        return true;
    }

    // PUT api/<PersonaController>/5
    [HttpPut("{id}")]
    public IActionResult PutAggiornaPersona(Guid id, [FromBody] Persona personaAggiornata)
    {
        // Cerchiamo la persona per ID
        var personaDaAggiornare = ListaPersone.FirstOrDefault(p => p.Id == id);

        if (personaDaAggiornare == null)
        {            
            return NotFound("Persona non trovata");
        }

        // Aggiornamento dei dati della persona trovata
        personaDaAggiornare.Nome = personaAggiornata.Nome;
        personaDaAggiornare.Cognome = personaAggiornata.Cognome;
        personaDaAggiornare.DataDiNascita = personaAggiornata.DataDiNascita;
        personaDaAggiornare.Email = personaAggiornata.Email;

        return Ok("Persona aggiornata con successo");
    }


    // DELETE api/<PersonaController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var personaDaEliminare = ListaPersone.FirstOrDefault(p => p.Id == id);

        if (personaDaEliminare == null)
        {
            return NotFound("Persona non trovata");
        }

        ListaPersone.Remove(personaDaEliminare);

        return Ok("Persona eliminata con successo");
    }
}

