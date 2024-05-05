using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Funcionario
{
public Funcionario(){}


    public Funcionario(string nome, string cpf, string funcao){
    
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Cpf = cpf;
        Funcao = funcao;
    }


    public string Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório!")]
    public string? Nome {get; set;}
    [Required(ErrorMessage = "Este campo é obrigatório!")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas 11 dígitos numéricos.")]    
    
    public string? Cpf {get; set;}
    [Required(ErrorMessage = "Este campo é obrigatório!")]
    public string? Funcao {get; set;}


}