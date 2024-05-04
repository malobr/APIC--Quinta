using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Cliente
{


    public Cliente(string nome, string cpf, bool vip){
        
        Nome = nome;
        Cpf = cpf;
        Vip = vip;
    }



    [Required(ErrorMessage = "Este campo é obrigatório!")]
    public string? Nome {get; set;}
    [Required(ErrorMessage = "Este campo é obrigatório!")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas 11 dígitos numéricos.")]    
    public string? Cpf {get; set;}
    public bool? Vip {get; set;}


}