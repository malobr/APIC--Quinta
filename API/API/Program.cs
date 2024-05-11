using System.ComponentModel.DataAnnotations;
using API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
builder.Services.AddControllers();
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




// GET: http://localhost:5096/cliente/listar
app.MapGet("/cliente/listar", ([FromServices] AppDataContext ctx) => {

    if (ctx.tabClientes.Any())
    {
        return Results.Ok(ctx.tabClientes.ToList());
    }
        return Results.BadRequest("No momento, não há clientes no sistema...");
});


// GET: http://localhost:5096/funcionario/listar
app.MapGet("/funcionario/listar", ([FromServices] AppDataContext ctx) => {

    if (ctx.tabFuncionarios.Any())
    {
        return Results.Ok(ctx.tabFuncionarios.ToList());
    }
        return Results.BadRequest("Sem funcionários cadastrados no momento...");
});

// GET: http://localhost:5096/eventos/listar
app.MapGet("/eventos/listar", ([FromServices] AppDataContext ctx) => {

    if (ctx.tabEventos.Any())
    {
        return Results.Ok(ctx.tabEventos.ToList());
    }
        return Results.BadRequest("Aguardando eventos...");
});




//Exclusão de clientes, funcionarios e eventos
app.MapDelete("/cliente/excluir/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) => {

    Cliente? c = ctx.tabClientes.FirstOrDefault(x => x.Id == id);
    if (c is null)
    {
        return Results.NotFound("Cliente não encontrado!");
    }
    ctx.tabClientes.Remove(c);
    ctx.SaveChanges();
    return Results.Ok("Cliente deletado!");

});

//
app.MapDelete("/funcionario/excluir/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) => {

    Funcionario? f = ctx.tabFuncionarios.FirstOrDefault(x => x.Id == id);
        if (f is null)
        {
            return Results.NotFound("Funcionário não encontrado!");
        }
        ctx.tabFuncionarios.Remove(f);
        ctx.SaveChanges();
        return Results.Ok("Funcionário deletado!");
});

//
app.MapDelete("/eventos/excluir/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) => {

    Eventos? e = ctx.tabEventos.FirstOrDefault(x => x.Id == id);
    if(e is null){
        return Results.NotFound("Evento não encontrado!");
    }
    ctx.tabEventos.Remove(e);
    ctx.SaveChanges();
    return Results.Ok("Evento deletado!");

});

app.Run();