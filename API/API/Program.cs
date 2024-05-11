using System.ComponentModel.DataAnnotations;
using API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "API Gerenciadora de Balada");



// POST: http://localhost:5096/cliente/cadastrar
app.MapPost("/cliente/cadastrar", ([FromBody] Cliente c, [FromServices] AppDataContext ctx) => {
    
    List<ValidationResult> erros = new List<ValidationResult>();
    if(!Validator.TryValidateObject(c, new ValidationContext(c), erros, true)){
        return Results.BadRequest(erros);
    }

    Cliente? clienteEncontrado = ctx.tabClientes.FirstOrDefault(x => x.Cpf == c.Cpf);
    if (clienteEncontrado is null)
    {
        ctx.tabClientes.Add(c);
        ctx.SaveChanges();
        return Results.Created("", c);
    }
    return Results.BadRequest("Este cliente já está no sistema!");

});


// POST: http://localhost:5096/funcionario/cadastrar
app.MapPost("/funcionario/cadastrar", ([FromBody] Funcionario f, [FromServices] AppDataContext ctx) => {
    
    List<ValidationResult> erros = new List<ValidationResult>();
    if(!Validator.TryValidateObject(f, new ValidationContext(f), erros, true)){
        return Results.BadRequest(erros);
    }

    Funcionario? funcionarioEncontrado = ctx.tabFuncionarios.FirstOrDefault(x => x.Cpf == f.Cpf);
    if (funcionarioEncontrado is null)
    {
        ctx.tabFuncionarios.Add(f);
        ctx.SaveChanges();
        return Results.Created("", f);
    }
    return Results.BadRequest("Este funcionário já está no sistema!");

});

// POST: http://localhost:5096/eventos/cadastrar
app.MapPost("/eventos/cadastrar", ([FromBody] Eventos e, [FromServices] AppDataContext ctx) => {
    
    List<ValidationResult> erros = new List<ValidationResult>();
    if(!Validator.TryValidateObject(e, new ValidationContext(e), erros, true)){
        return Results.BadRequest(erros);
    }

    Eventos? eventoEncontrado = ctx.tabEventos.FirstOrDefault(x => x.Nome == e.Nome);
    if (eventoEncontrado is null)
    {
        ctx.tabEventos.Add(e);
        ctx.SaveChanges();
        return Results.Created("", e);
    }
    return Results.BadRequest("Este Evento já está no sistema!");

});

app.Run();