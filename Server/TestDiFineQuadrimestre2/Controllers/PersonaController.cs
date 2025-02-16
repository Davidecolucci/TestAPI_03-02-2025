﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestDiFineQuadrimestre2.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestDiFineQuadrimestre2.Controllers;

[Route("api/persone")]
[ApiController] 
public class PersonaController : ControllerBase
{

    private readonly string filePath = "persone.json";
    private List<Persona> ListaPersone = new List<Persona>();

    public PersonaController()
    {
        CaricaPersoneDalFile();
    }

    public void CaricaPersoneDalFile()
    {
        if (System.IO.File.Exists(filePath))
        {
            var json = System.IO.File.ReadAllText(filePath);
            ListaPersone = JsonSerializer.Deserialize<List<Persona>>(json) ?? new List<Persona>();
        }
    }

    private void SalvaPersoneSuFile()
    {
        var json = JsonSerializer.Serialize(ListaPersone, new JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(filePath, json);
    }


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
        SalvaPersoneSuFile();
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

        SalvaPersoneSuFile();

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

        SalvaPersoneSuFile();

        return Ok("Persona eliminata con successo");
    }
}

