namespace TestDiFineQuadrimestre2.Dto;

public class Persona
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Cognome { get; set; }
    public DateTime DataDiNascita { get; set; }
    public Dominio Dominio { get; set; }
    public string? Email { get; set; }

    //public Persona(Guid id, string nome, string cognome, DateTime dataDiNascita, Dominio dominio, string email)
    //{
    //    Id = id;
    //    Nome = nome;
    //    Cognome = cognome;
    //    DataDiNascita = dataDiNascita;
    //    Dominio = dominio;
    //    Email = email;
    //}

}

