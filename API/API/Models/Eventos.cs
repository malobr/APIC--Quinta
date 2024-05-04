using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Eventos
{


    public Eventos(string nomeDoEvento, string organizacao, string local, string estiloMusical){
        
        Nome = nomeDoEvento;
        Organizacao = organizacao;
        Local = local;
        EstiloMusical = estiloMusical;
    }



    [Required(ErrorMessage = "O nome do evento é obrigatório!")]
    public string? Nome {get; set;}
    [Required(ErrorMessage = "A organizacao e obrigatoria")]
    
    public string? Organizacao {get; set;}
    [Required(ErrorMessage = "O local e obrigatorio")]
    public string? Local {get; set;}
    [Required(ErrorMessage = "O estilo musical e obrigatorio")]
    public string? EstiloMusical {get; set;}



}
    public enum EstiloMusical{
        Rock,
        Pop,
        Eletronica,
        Classica,
        Rap,
        Outro
    }