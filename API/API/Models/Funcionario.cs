using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Funcionario
{
public Funcionario(){
    Id = Guid.NewGuid().ToString();
}

    public string? Tipo {get; set;}

    public string? Id { get; set; }
    public string? Nome {get; set;}

    public string? Cpf {get; set;}
    public string? Funcao {get; set;}


}