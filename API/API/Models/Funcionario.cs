using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Funcionario
{


    public Funcionario(string nome, string cpf, string funcao){
        
        Nome = nome;
        Cpf = cpf;
        Funcao = funcao;
    }



    [Required(ErrorMessage = "Este campo é obrigatório!")]
    public string? Nome {get; set;}
    [Required(ErrorMessage = "Este campo é obrigatório!")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas 11 dígitos numéricos.")]    
    
    public string? Cpf {get; set;}
    [Required(ErrorMessage = "Este campo é obrigatório!")]
    public string? Funcao {get; set;}


}