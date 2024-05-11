using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Cliente
{
public Cliente(){
    Id = Guid.NewGuid().ToString();
}


    public string Id { get; set; }
    public string? Nome {get; set;}

    public string? Cpf {get; set;}
    public bool? Vip {get; set;} = false;


}