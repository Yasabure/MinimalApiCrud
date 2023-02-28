using Microsoft.AspNetCore.Mvc;
using MinimalApiCrud.Interfaces;
using MinimalApiCrud.Repositories;
using MinimalApiCrud.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IChampionRepository, ChampionRepository>();

var app = builder.Build();

app.MapGet("/v1/champ", ([FromServices]IChampionRepository repository ) => 
{
    return repository.GetChampions();
});

app.MapPost("/v1/champ", ([FromServices]IChampionRepository repository, ChampionLancamentos champion) =>
{
    var result = repository.InsertChampion(champion);

    return (result ?
    Results.Ok($"Champion {champion} inserido")
    :
    Results.BadRequest("Não foi Possivel inserir o Carro")
    );
});

app.MapPut("/v1/champ", ([FromServices]IChampionRepository repository, int id, string funcao)=>
{
    var result = repository.UpdateFuncao(funcao, id);
    return (result ?
    Results.Ok($"Funão Alterada Com sucesso")
    :
    Results.BadRequest("Não foi Possivel Alterar a Função")
    );
});

app.MapDelete("/v1/champ", ([FromServices]IChampionRepository repository, int id)=>
{
    var result = repository.Delete(id);
    return (result ?
    Results.Ok($"Champion Deletado")
    :
    Results.BadRequest("Não foi Deletar o Champion")
    );
});



app.Run();
